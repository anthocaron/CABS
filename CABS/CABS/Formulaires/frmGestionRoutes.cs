using CABS.BaseDonnees;
using CABS.Outils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CABS.Formulaires
{
    public partial class frmGestionRoutes : Formulaire
    {
        private static string RequeteNonClasses = "SELECT p.* FROM personne p INNER JOIN inscriptionservice i ON p.perId = i.perId INNER JOIN inscriptionpopoteroulante ip ON p.perId = ip.perId LEFT JOIN beneficiaireroutepopoteroulante b ON ip.perId = b.perId WHERE i.insSuspendu = 0 AND b.perId IS NULL GROUP BY p.perId ORDER BY p.perNom, p.perPrenom, p.perDateNaissance;";
        private static string FormatRequeteBeneficiairesRoute = "SELECT p.*, b.rprId, b.brprOrdre FROM personne p INNER JOIN inscriptionservice i ON p.perId = i.perId INNER JOIN inscriptionpopoteroulante ip ON p.perId = ip.perId INNER JOIN beneficiaireroutepopoteroulante b ON ip.perId = b.perId WHERE i.insSuspendu = 0 AND b.rprId = {0} GROUP BY p.perId ORDER BY b.brprOrdre;";
        private static string FormatOrdreMaximum = "SELECT max(brprOrdre) AS brprOrdre FROM beneficiaireroutepopoteroulante WHERE rprId = {0};";
        private static string FormatNomAdresseBeneficiaire = "{0}, {1} ({2} {3}, {4}, {5})";

        public frmGestionRoutes()
            : base(true, true)
        {
            InitializeComponent();
        }

        public override void EntrerPage()
        {
            base.EntrerPage();

            Table beneficiaires = Global.BaseDonneesCABS.EnvoyerRequeteSelectionDirect("Beneficiaire", RequeteNonClasses);
            lbBeneficiaires.Items.Clear();

            foreach (LigneTable beneficiaire in beneficiaires.Lignes)
            {
                lbBeneficiaires.Items.Add(new ComboBoxItem(GetNomAdresseBeneficiaire(beneficiaire), beneficiaire));
            }

            RequeteSelection reqSel = new RequeteSelection(NomTable.routepopoteroulante);
            reqSel.AjouterTri("rprNom");

            Table routes = Global.BaseDonneesCABS.EnvoyerRequeteSelection(reqSel);

            tvRoutesBeneficiaires.Nodes.Clear();

            foreach (LigneTable route in routes.Lignes)
            {
                int indexRoute = route.GetValeurChamp<int>("rprId");

                TreeNode nouveauNoeudRoute = new TreeNode(route.GetValeurChamp<string>("rprNom"));
                nouveauNoeudRoute.Tag = indexRoute;

                Table beneficiairesRoute = Global.BaseDonneesCABS.EnvoyerRequeteSelectionDirect("Beneficiaire", String.Format(FormatRequeteBeneficiairesRoute, indexRoute));

                foreach (LigneTable beneficiaire in beneficiairesRoute.Lignes)
                {
                    TreeNode nouveauNoeudBeneficiaire = new TreeNode(GetNomAdresseBeneficiaire(beneficiaire));
                    nouveauNoeudBeneficiaire.Tag = beneficiaire;
                    nouveauNoeudRoute.Nodes.Add(nouveauNoeudBeneficiaire);
                }

                tvRoutesBeneficiaires.Nodes.Add(nouveauNoeudRoute);
            }

            MettreAJourAccesControles();
        }

        private string GetNomAdresseBeneficiaire(LigneTable beneficiaire)
        {
            string nom = beneficiaire.GetValeurChamp<string>("perNom");
            string prenom = beneficiaire.GetValeurChamp<string>("perPrenom");
            int noCivique = beneficiaire.GetValeurChamp<int>("perNoCivique");
            string rue = beneficiaire.GetValeurChamp<string>("perRue");
            string ville = beneficiaire.GetValeurChamp<string>("perVille");
            string codePostal = beneficiaire.GetValeurChamp<string>("perCodePostal");

            return String.Format(FormatNomAdresseBeneficiaire, nom, prenom, noCivique, rue, ville, codePostal);
        }

        private void txtNouvelleRoute_TextChanged(object sender, EventArgs e)
        {
            btnAjouter.Enabled = txtNouvelleRoute.Text != "";
        }

        private void lbBeneficiaires_SelectedIndexChanged(object sender, EventArgs e)
        {
            MettreAJourAccesControles();
        }

        private void tvRoutesBeneficiaires_AfterSelect(object sender, TreeViewEventArgs e)
        {
            MettreAJourAccesControles();
        }

        private void MettreAJourAccesControles()
        {
            TreeNode noeudSelectionne = tvRoutesBeneficiaires.SelectedNode;

            btnInclure.Enabled = lbBeneficiaires.SelectedIndex >= 0 && noeudSelectionne != null && noeudSelectionne.Parent == null;
            btnRetirer.Enabled = noeudSelectionne != null && noeudSelectionne.Parent != null;
            btnMonter.Enabled = noeudSelectionne != null && noeudSelectionne.Parent != null && noeudSelectionne.Index != 0;
            btnBaisser.Enabled = noeudSelectionne != null && noeudSelectionne.Parent != null && noeudSelectionne.Index != noeudSelectionne.Parent.Nodes.Count - 1;
            btnSupprimer.Enabled = noeudSelectionne != null && noeudSelectionne.Parent == null;
        }

        private void tvRoutesBeneficiaires_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            if (e.Node == null)
                return;

            if ((e.State & TreeNodeStates.Selected) == TreeNodeStates.Selected)
            {
                Font nodeFont = e.Node.NodeFont;
                if (nodeFont == null) nodeFont = ((TreeView)sender).Font;

                e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
                TextRenderer.DrawText(e.Graphics, e.Node.Text, nodeFont, e.Bounds, SystemColors.HighlightText, TextFormatFlags.GlyphOverhangPadding);
            }
            else
            {
                e.DrawDefault = true;
            }
        }

        private void btnInclure_Click(object sender, EventArgs e)
        {
            ComboBoxItem beneficiaire = (lbBeneficiaires.SelectedItem as ComboBoxItem);
            LigneTable ligneBeneficiaire = beneficiaire.Value is LigneTable ? (LigneTable)beneficiaire.Value : new LigneTable("beneficiaire");
            TreeNode noeudRoute = tvRoutesBeneficiaires.SelectedNode;

            LigneTable beneficiaireRoute = new LigneTable("beneficiaireroutepopoteroulante");

            beneficiaireRoute.AjouterChamp("perId", ligneBeneficiaire.GetValeurChamp<int>("perId"));
            beneficiaireRoute.AjouterChamp("rprId", noeudRoute.Tag);

            Table ordreMax = Global.BaseDonneesCABS.EnvoyerRequeteSelectionDirect("beneficiaireroutepopoteroulante", String.Format(FormatOrdreMaximum, noeudRoute.Tag));

            if (ordreMax.EstVide)
                beneficiaireRoute.AjouterChamp("brprOrdre", 1);
            else
                beneficiaireRoute.AjouterChamp("brprOrdre", ordreMax.Lignes[0].GetValeurChamp<int>("brprOrdre") + 1);
            

            RequeteAjout reqAjout = new RequeteAjout(NomTable.beneficiaireroutepopoteroulante, beneficiaireRoute);

            if (Global.BaseDonneesCABS.EnvoyerRequeteAjout(reqAjout) < 0)
            {
                Journal.AfficherMessage("Une erreur est survenue lors de l'inclusion du bénéficiaire à la route. L'action a été annulée.", TypeMessage.ERREUR, true);
                return;
            }

            ligneBeneficiaire.AjouterChamp(beneficiaireRoute.GetChamp("rprId"));
            ligneBeneficiaire.AjouterChamp(beneficiaireRoute.GetChamp("brprOrdre"));

            TreeNode nouveauNoeudBeneficiaire = new TreeNode(beneficiaire.Text);
            nouveauNoeudBeneficiaire.Tag = ligneBeneficiaire;
            noeudRoute.Nodes.Add(nouveauNoeudBeneficiaire);
            noeudRoute.Expand();

            lbBeneficiaires.Items.Remove(beneficiaire);
        }

        private void btnRetirer_Click(object sender, EventArgs e)
        {
            TreeNode noeudBeneficiaire = tvRoutesBeneficiaires.SelectedNode;
            TreeNode noeudRoute = noeudBeneficiaire.Parent;

            if (noeudBeneficiaire == null || noeudRoute == null)
            {
                Journal.EcrireMessage("frmGestionRoutes : Bouton Retirer enabled sans devoir l'être");
                return;
            }

            LigneTable beneficiaire = noeudBeneficiaire.Tag is LigneTable ? (LigneTable)noeudBeneficiaire.Tag : new LigneTable("beneficiaire");

            ConditionRequete cond = new ConditionRequete(Operateur.EGAL, "perId", beneficiaire.GetChamp("perId").ValeurSQL);
            cond.LierCondition(new ConditionRequete(Operateur.EGAL, "rprId", noeudRoute.Tag.ToString()), true);

            RequeteSuppression reqSup = new RequeteSuppression(NomTable.beneficiaireroutepopoteroulante, cond);

            if (Global.BaseDonneesCABS.EnvoyerRequeteSuppression(reqSup) < 0)
            {
                Journal.AfficherMessage("Une erreur est survenue lors du retirement du bénéficiaire de la route. L'action a été annulée.", TypeMessage.ERREUR, true);
                return;
            }

            noeudRoute.Nodes.Remove(noeudBeneficiaire);
            tvRoutesBeneficiaires_AfterSelect(tvRoutesBeneficiaires, new TreeViewEventArgs(noeudRoute));

            lbBeneficiaires.Items.Add(new ComboBoxItem(noeudBeneficiaire.Text, beneficiaire));
        }

        private void btnMonter_Click(object sender, EventArgs e)
        {
            TreeNode noeudSelectionne = tvRoutesBeneficiaires.SelectedNode;
            TreeNode noeudParent = noeudSelectionne != null ? noeudSelectionne.Parent : null;
            TreeNode noeudPrecedent = noeudParent != null ? noeudParent.Nodes[noeudSelectionne.Index - 1] : null;

            LigneTable beneficiaire1 = noeudSelectionne != null && noeudSelectionne.Tag is LigneTable ? (LigneTable)noeudSelectionne.Tag : null;
            LigneTable beneficiaire2 = noeudPrecedent != null && noeudPrecedent.Tag is LigneTable ? (LigneTable)noeudPrecedent.Tag : null;

            if (noeudSelectionne == null || noeudParent == null || noeudPrecedent == null || beneficiaire1 == null || beneficiaire2 == null)
            {
                Journal.AfficherMessage("Une erreur est survenue lors du changement d'ordre des bénéficiaires. L'action a été annulée.", TypeMessage.ERREUR, true);
                return;
            }

            Global.BaseDonneesCABS.CommencerTransaction();

            ConditionRequete cond1 = new ConditionRequete(Operateur.EGAL, beneficiaire1.GetChamp("perId"));
            ConditionRequete cond2 = new ConditionRequete(Operateur.EGAL, beneficiaire2.GetChamp("perId"));
            RequeteModification reqModif1 = new RequeteModification(NomTable.beneficiaireroutepopoteroulante, cond1, beneficiaire2.GetChamp("brprOrdre"));
            RequeteModification reqModif2 = new RequeteModification(NomTable.beneficiaireroutepopoteroulante, cond2, beneficiaire1.GetChamp("brprOrdre"));

            if (Global.BaseDonneesCABS.EnvoyerRequeteModification(reqModif1) < 0)
            {
                Journal.AfficherMessage("Une erreur est survenue lors du changement d'ordre des bénéficiaires. L'action a été annulée.", TypeMessage.ERREUR, true);

                Global.BaseDonneesCABS.AnnulerTransaction();
                return;
            }

            if (Global.BaseDonneesCABS.EnvoyerRequeteModification(reqModif2) < 0)
            {
                Journal.AfficherMessage("Une erreur est survenue lors du changement d'ordre des bénéficiaires. L'action a été annulée.", TypeMessage.ERREUR, true);

                Global.BaseDonneesCABS.AnnulerTransaction();
                return;
            }

            Global.BaseDonneesCABS.ConfirmerTransaction();

            int temp = beneficiaire1.GetValeurChamp<int>("brprOrdre");
            beneficiaire1.GetChamp("brprOrdre").Valeur = beneficiaire2.GetValeurChamp<int>("brprOrdre");
            beneficiaire2.GetChamp("brprOrdre").Valeur = temp;

            noeudParent.Nodes.Remove(noeudSelectionne);
            noeudParent.Nodes.Insert(noeudPrecedent.Index, noeudSelectionne);

            tvRoutesBeneficiaires.SelectedNode = noeudSelectionne;
        }

        private void btnBaisser_Click(object sender, EventArgs e)
        {
            TreeNode noeudSelectionne = tvRoutesBeneficiaires.SelectedNode;
            TreeNode noeudParent = noeudSelectionne.Parent;
            TreeNode noeudSuivant = noeudParent.Nodes[noeudSelectionne.Index + 1];

            LigneTable beneficiaire1 = noeudSelectionne != null && noeudSelectionne.Tag is LigneTable ? (LigneTable)noeudSelectionne.Tag : null;
            LigneTable beneficiaire2 = noeudSuivant != null && noeudSuivant.Tag is LigneTable ? (LigneTable)noeudSuivant.Tag : null;

            if (noeudSelectionne == null || noeudParent == null || noeudSuivant == null || beneficiaire1 == null || beneficiaire2 == null)
                return;

            Global.BaseDonneesCABS.CommencerTransaction();

            ConditionRequete cond1 = new ConditionRequete(Operateur.EGAL, beneficiaire1.GetChamp("perId"));
            ConditionRequete cond2 = new ConditionRequete(Operateur.EGAL, beneficiaire2.GetChamp("perId"));
            RequeteModification reqModif1 = new RequeteModification(NomTable.beneficiaireroutepopoteroulante, cond1, beneficiaire2.GetChamp("brprOrdre"));
            RequeteModification reqModif2 = new RequeteModification(NomTable.beneficiaireroutepopoteroulante, cond2, beneficiaire1.GetChamp("brprOrdre"));

            if (Global.BaseDonneesCABS.EnvoyerRequeteModification(reqModif1) < 0)
            {
                Journal.AfficherMessage("Une erreur est survenue lors du changement d'ordre des bénéficiaires. L'action a été annulée.", TypeMessage.ERREUR, true);
                Global.BaseDonneesCABS.AnnulerTransaction();
                return;
            }

            if (Global.BaseDonneesCABS.EnvoyerRequeteModification(reqModif2) < 0)
            {
                Journal.AfficherMessage("Une erreur est survenue lors du changement d'ordre des bénéficiaires. L'action a été annulée.", TypeMessage.ERREUR, true);
                Global.BaseDonneesCABS.AnnulerTransaction();
                return;
            }

            Global.BaseDonneesCABS.ConfirmerTransaction();

            int temp = beneficiaire1.GetValeurChamp<int>("brprOrdre");
            beneficiaire1.GetChamp("brprOrdre").Valeur = beneficiaire2.GetValeurChamp<int>("brprOrdre");
            beneficiaire2.GetChamp("brprOrdre").Valeur = temp;

            noeudParent.Nodes.Remove(noeudSelectionne);
            noeudParent.Nodes.Insert(noeudSuivant.Index + 1, noeudSelectionne);

            tvRoutesBeneficiaires.SelectedNode = noeudSelectionne;
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            Champ nom = new Champ(NomTable.routepopoteroulante.ToString(), "rprNom", txtNouvelleRoute.Text);

            RequeteSelection reqSel = new RequeteSelection(NomTable.routepopoteroulante);
            reqSel.Condition = new ConditionRequete(Operateur.COMME, nom);

            if (!Global.BaseDonneesCABS.EnvoyerRequeteSelection(reqSel).EstVide && !OutilsForms.PoserQuestion("Confirmation d'ajout", "Une route portant le même nom existe déjà. Voulez-vous quand même ajouter celle-ci?"))
            {
                return;
            }

            RequeteAjout reqAjout = new RequeteAjout(NomTable.routepopoteroulante, nom);
            int nouvelIndex;

            if ((nouvelIndex = Global.BaseDonneesCABS.EnvoyerRequeteAjout(reqAjout)) < 0)
            {
                Journal.AfficherMessage("Une erreur est survenue lors de l'ajout d'une route. L'action a été annulée.", TypeMessage.ERREUR, true);
                return;
            }

            TreeNode nouveauNoeudRoute = new TreeNode(txtNouvelleRoute.Text);
            nouveauNoeudRoute.Tag = nouvelIndex;

            tvRoutesBeneficiaires.Nodes.Add(nouveauNoeudRoute);
            txtNouvelleRoute.Text = "";
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            TreeNode noeudRoute = tvRoutesBeneficiaires.SelectedNode;

            if (noeudRoute == null)
            {
                Journal.EcrireMessage("frmGestionRoutes : Bouton Supprimer enabled sans devoir l'être");
                btnSupprimer.Enabled = false;
                return;
            }
            
            if(!OutilsForms.PoserQuestion("Confirmation suppression", "Voulez-vous vraiment supprimer cette route? Cette action va retirer tous les bénéficiaires associer à celle-ci."))
                return;

            ConditionRequete cond = new ConditionRequete(Operateur.EGAL, "rprId", noeudRoute.Tag.ToString());
            RequeteSuppression reqSup = new RequeteSuppression(NomTable.routepopoteroulante, cond);

            if (Global.BaseDonneesCABS.EnvoyerRequeteSuppression(reqSup) < 0)
            {
                Journal.AfficherMessage("Une erreur est survenue lors de la suppression d'une route. L'action a été annulée.", TypeMessage.ERREUR, true);
                return;
            }

            foreach (TreeNode noeudBeneficiaire in noeudRoute.Nodes)
            {
                lbBeneficiaires.Items.Add(new ComboBoxItem(noeudBeneficiaire.Text, noeudBeneficiaire.Tag));
            }

            tvRoutesBeneficiaires.Nodes.Remove(noeudRoute);
            tvRoutesBeneficiaires_AfterSelect(tvRoutesBeneficiaires, new TreeViewEventArgs(null));
        }
    }
}
