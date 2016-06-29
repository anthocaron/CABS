using CABS.Outils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using System.Drawing;

namespace CABS.Formulaires
{
    public partial class frmPrincipal : Form
    {
        private const string FORMAT_DUMP_MYSQL = "/c \"mysqldump --user={0} --password={1} --skip-opt {2} > {3}";
        private const double INTERVAL_CHARGEMENT = 1000;

        private CABS.Outils.Menu MenuFormulaires;
        private List<string> HistoriqueFormulaires;
        private int PositionHistorique;
        private bool AjoutHistoriqueActive;

        public frmPrincipal()
        {
            InitializeComponent();

            EtatConnexionChange(this, new StateChangeEventArgs(ConnectionState.Closed, Global.BaseDonneesCABS.EcouterConnexion(EtatConnexionChange)));
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            MenuFormulaires = Global.GenererMenu("data/menu.xml");
            HistoriqueFormulaires = new List<string>();
            PositionHistorique = 0;
            AjoutHistoriqueActive = true;

            tvSections.Nodes.AddRange(CreerNoeuds(MenuFormulaires.Sections));
            tvSections.ExpandAll();
        }

        private void EtatConnexionChange(object sender, StateChangeEventArgs e)
        {
            if (e.CurrentState == ConnectionState.Open)
            {
                tsslConnexion.Text = "BD connectée";
                return;
            }

            tsslConnexion.Text = "BD déconnectée";
        }

        private TreeNode[] CreerNoeuds(List<Section> sections)
        {
            List<TreeNode> noeuds = new List<TreeNode>();

            foreach (Section s in sections)
            {
                TreeNode nouveauNoeud = new TreeNode(s.Nom);
                nouveauNoeud.Nodes.AddRange(CreerNoeuds(s.Sections));

                noeuds.Add(nouveauNoeud);
            }

            return noeuds.ToArray();
        }

        private void tvSections_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (tbcFormulaires.SelectedTab is Page && !((Page)tbcFormulaires.SelectedTab).Contenu.QuitterPage())
            {
                e.Cancel = true;
                return;
            }

            tbcFormulaires.TabPages.Clear();

            List<Page> pages = MenuFormulaires.TrouverPages(e.Node.Text);

            if (pages.Count == 0)
                return;

            pages.ForEach(p => tbcFormulaires.TabPages.Add(p));
            ((Page)tbcFormulaires.SelectedTab).Contenu.EntrerPage();

            if (AjoutHistoriqueActive)
                AjouterHistorique(pages[0].Name);
        }

        private void ChangerFormulaireInterne(string nomFormulaire, bool ajoutHistorique, params object[] messages)
        {
            Section sectionFormulaire = MenuFormulaires.TrouverSection(nomFormulaire);

            if (sectionFormulaire == null)
            {
                Journal.EcrireMessage("Demande de changement vers un formulaire inexistant");
                return;
            }

            if (sectionFormulaire.Nom != tvSections.SelectedNode.Text)
            {
                TreeNode noeud = TrouverNoeud(sectionFormulaire.Nom, tvSections.Nodes);

                if (noeud != null)
                    tvSections.SelectedNode = noeud;
            }

            for (int i = 0; i < tbcFormulaires.TabPages.Count; ++i)
            {
                if(!(tbcFormulaires.TabPages[i] is Page))
                    break;

                Page p = (Page)tbcFormulaires.TabPages[i];

                if (p.Name == nomFormulaire)
                {
                    if(messages != null)
                        p.Contenu.EnvoyerMessages(messages);

                    tbcFormulaires.SelectTab(p);
                    break;
                }
            }
        }

        public void ChangerFormulaire(string nomFormulaire, params object[] messages)
        {
            ChangerFormulaireInterne(nomFormulaire, true, messages);
            AjouterHistorique(nomFormulaire);
        }

        private TreeNode TrouverNoeud(string nomSection, TreeNodeCollection noeuds)
        {
            TreeNode noeudSection = null;

            foreach (TreeNode n in noeuds)
            {
                if (n.Text == nomSection)
                    return n;

                noeudSection = TrouverNoeud(nomSection, n.Nodes);

                if (noeudSection != null)
                    return noeudSection;
            }

            return noeudSection;
        }

        private void btnPrecedent_Click(object sender, EventArgs e)
        {
            DeplacerHistorique(1);
        }

        private void btnSuivant_Click(object sender, EventArgs e)
        {
            DeplacerHistorique(-1);
        }

        private void DeplacerHistorique(int deplacement)
        {
            PositionHistorique += deplacement;

            if (PositionHistorique < 0)
                PositionHistorique = 0;
            else if (PositionHistorique >= HistoriqueFormulaires.Count)
                PositionHistorique = HistoriqueFormulaires.Count - 1;

            btnPrecedent.Enabled = PositionHistorique < HistoriqueFormulaires.Count - 1;
            btnSuivant.Enabled = PositionHistorique > 0;

            AjoutHistoriqueActive = false;
            ChangerFormulaireInterne(HistoriqueFormulaires[PositionHistorique], false, null);
            AjoutHistoriqueActive = true;
        }

        private void AjouterHistorique(string nomFormulaire)
        {
            HistoriqueFormulaires = HistoriqueFormulaires.GetRange(PositionHistorique, HistoriqueFormulaires.Count - PositionHistorique);

            HistoriqueFormulaires.Remove(nomFormulaire);
            PositionHistorique = 0;
            HistoriqueFormulaires.Insert(PositionHistorique, nomFormulaire);

            btnPrecedent.Enabled = PositionHistorique < HistoriqueFormulaires.Count - 1;
            btnSuivant.Enabled = false;
        }

        private void tsmSauvegarderDonnees_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfdFenetre = new SaveFileDialog();
            sfdFenetre.Filter = "SQL File|*.sql";
            sfdFenetre.Title = "Sauvegarder les données";
            sfdFenetre.FileName = DateTime.Now.ToString("yyyyMMdd") + ".sql";

            DialogResult reponse = sfdFenetre.ShowDialog();

            if (reponse != System.Windows.Forms.DialogResult.OK)
                return;

            Process mysqldump = new Process();
            mysqldump.StartInfo.CreateNoWindow = true;
            mysqldump.StartInfo.FileName = "cmd.exe";
            mysqldump.StartInfo.Arguments = String.Format(FORMAT_DUMP_MYSQL, Global.GetConfiguration<string>("UTILISATEUR"),
                                                                             Global.GetConfiguration<string>("MOT_DE_PASSE"),
                                                                             Global.GetConfiguration<string>("BD"),
                                                                             "\"" + sfdFenetre.FileName + "\"");
            mysqldump.Start();
            mysqldump.WaitForExit();

            if (mysqldump.ExitCode != 0)
            {
                Journal.AfficherMessage("Une erreur s'est produite lors de la sauvegarde des données.\nLe fichier de sauvegarde n'a pas été créé ou est corrompu.",
                                        TypeMessage.ERREUR, true);
            }
        }

        private void tsmQuitter_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Page pageCourante = (Page)tbcFormulaires.SelectedTab;

            if((pageCourante == null || pageCourante.Contenu.QuitterPage()) && 
                OutilsForms.PoserQuestion("Confirmation", "Désirez-vous vraiment quitter l'application?"))
            {
                return;
            }

            e.Cancel = true;
        }

        private void tbcFormulaires_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage == null)
                return;

            if (e.TabPage is Page)
                ((Page)e.TabPage).Contenu.EntrerPage();

            if (AjoutHistoriqueActive)
                AjouterHistorique(e.TabPage.Name);
        }

        private void tbcFormulaires_Deselecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage is Page && !((Page)e.TabPage).Contenu.QuitterPage())
                e.Cancel = true;
        }

        public void AfficherIndication(string message)
        {
            tsslIndication.Text = message;
        }

        public void EffacerIndication()
        {
            tsslIndication.Text = "";
        }
    }
}