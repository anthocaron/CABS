using CABS.BaseDonnees;
using CABS.Outils;
using CABS.Outils.Excel;
using System;
using System.Windows.Forms;
using System.Threading;

namespace CABS.Formulaires
{
    public partial class frmListesPersonnes : Formulaire
    {
        private const string FORMAT_REQUETE_PERSONNES = "SELECT p.perId, p.perNom, p.perPrenom, p.perDateNaissance, p.perDateDerniereMaj, s.staNom as staId, p.perSexe, p.perFumeur, e.etaNom as etaId, p.perTelephone1, p.perTelephone2, p.perTelephone3, p.perCourriel, p.perNoCivique, p.perRue, p.perNoAppart, p.perVille, p.perCasePostale, p.perCodePostal, p.perCommentaires FROM Personne p INNER JOIN {0} x ON p.perId = x.perId INNER JOIN EtatCivil e ON p.etaId = e.etaId INNER JOIN Statut s ON p.staId = s.staId {1} ORDER BY p.perNom, p.perPrenom, p.perDateNaissance";
        private const string FORMAT_JOIN_INSCRIPTION = "INNER JOIN InscriptionService i ON i.perId = p.perId WHERE i.serId = {0}";
        private const string FORMAT_JOIN_DISPONIBILITE = "INNER JOIN DisponibiliteService d ON d.perId = p.perId WHERE d.serId = {0}";
        private const string NOM_TABLE_PERSONNE = "Personne";

        private Table Services;

        public frmListesPersonnes()
            : base(true, true)
        {
            InitializeComponent();

            Services = null;

            cmbServiceBeneficiaires.MouseWheel += new MouseEventHandler(cmb_MouseWheel);
            cmbServiceBenevoles.MouseWheel += new MouseEventHandler(cmb_MouseWheel);
        }

        private void cmb_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        private void frmListesPersonnes_Load(object sender, EventArgs e)
        {
            RequeteSelection reqServices = new RequeteSelection(NomTable.service);
            reqServices.AjouterTri("serNom");

            Services = Global.BaseDonneesCABS.EnvoyerRequeteSelection(reqServices);

            foreach (LigneTable ligneService in Services.Lignes)
            {
                ComboBoxItem service = new ComboBoxItem(ligneService.GetValeurChamp<string>("serNom"), ligneService.GetValeurChamp<int>("serId"));
                cmbServiceBeneficiaires.Items.Add(service);
                cmbServiceBenevoles.Items.Add(service);
            }

            if (!Services.EstVide)
            {
                cmbServiceBeneficiaires.SelectedIndex = 0;
                cmbServiceBenevoles.SelectedIndex = 0;
            }
        }

        private void btnListeBeneficiaires_Click(object sender, EventArgs e)
        {
            if (cbBeneficiairesParServices.Checked)
                GenererListeParServices("Bénéficiaires", "Beneficiaire", FORMAT_JOIN_INSCRIPTION);
            else if (cbBeneficiairesService.Checked)
                GenererListeService("Bénéficiaires", "Beneficiaire", FORMAT_JOIN_INSCRIPTION, (ComboBoxItem)cmbServiceBeneficiaires.SelectedItem);
            else
                GenererListe("Bénéficiaires", "Beneficiaire");
        }

        private void btnListeBenevoles_Click(object sender, EventArgs e)
        {
            if (cbBenevolesParServices.Checked)
                GenererListeParServices("Bénévoles", "Benevole", FORMAT_JOIN_DISPONIBILITE);
            else if (cbBenevolesService.Checked)
                GenererListeService("Bénévoles", "Benevole", FORMAT_JOIN_DISPONIBILITE, (ComboBoxItem)cmbServiceBenevoles.SelectedItem);
            else
                GenererListe("Bénévoles", "Benevole");
        }

        private void btnListeEmployes_Click(object sender, EventArgs e)
        {
            GenererListe("Employés", "Employe");
        }

        private void GenererListeParServices(string nomFeuille, string nomTable, string requeteJoin)
        {
            Classeur document = new Classeur();

            foreach (LigneTable ligneService in Services.Lignes)
            {
                string nomService = ligneService.GetValeurChamp<string>("serNom");
                string nomInscriptionService = Global.GetNomTableService(nomService);

                if (nomService.Length > 31)
                    nomService = nomService.Substring(0, 31);

                Table personnes = Global.BaseDonneesCABS.EnvoyerRequeteSelectionDirect(NOM_TABLE_PERSONNE, String.Format(FORMAT_REQUETE_PERSONNES, nomTable, String.Format(requeteJoin, ligneService.GetValeurChamp<int>("serId"))));
                AjusterDonneesPersonnes(personnes);

                if (nomInscriptionService.Length > 0)
                {
                    Table infosService = Global.BaseDonneesCABS.EnvoyerRequeteSelectionDirect(nomInscriptionService, "SELECT * FROM " + nomInscriptionService);
                    personnes.Joindre("perId", infosService, "perId");
                }

                personnes.RetirerChamp("perId");

                Feuille feuille = new Feuille(nomService, 2);
                feuille.AjouterTableau(new Tableau(personnes, nomFeuille + " - " + nomService));

                document.AjouterFeuille(feuille);
            }

            frmPrincipal formulairePrincipal = ParentForm is frmPrincipal ? (frmPrincipal)ParentForm : null;

            if (formulairePrincipal != null)
                formulairePrincipal.AfficherIndication("Génération du document Excel");

            document.Generer();

            if (formulairePrincipal != null)
                formulairePrincipal.EffacerIndication();
        }

        private void GenererListeService(string nomFeuille, string nomTable, string requeteJoin, ComboBoxItem service)
        {
            string nomService = service.Text;
            string nomInscriptionService = Global.GetNomTableService(nomService);

            if (nomService.Length > 31)
                nomService = nomService.Substring(0, 31);

            Table personnes = Global.BaseDonneesCABS.EnvoyerRequeteSelectionDirect(NOM_TABLE_PERSONNE, String.Format(FORMAT_REQUETE_PERSONNES, nomTable, String.Format(requeteJoin, (int)service.Value)));
            AjusterDonneesPersonnes(personnes);

            if (nomInscriptionService.Length > 0)
            {
                Table infosService = Global.BaseDonneesCABS.EnvoyerRequeteSelectionDirect(nomInscriptionService, "SELECT * FROM " + nomInscriptionService);
                personnes.Joindre("perId", infosService, "perId");
            }

            personnes.RetirerChamp("perId");

            Feuille feuille = new Feuille(nomService, 2);
            feuille.AjouterTableau(new Tableau(personnes, nomFeuille + " - " + service.Text));

            Classeur document = new Classeur();
            document.AjouterFeuille(feuille);

            frmPrincipal formulairePrincipal = ParentForm is frmPrincipal ? (frmPrincipal)ParentForm : null;

            if (formulairePrincipal != null)
                formulairePrincipal.AfficherIndication("Génération du document Excel");

            document.Generer();

            if (formulairePrincipal != null)
                formulairePrincipal.EffacerIndication();
        }

        private void GenererListe(string nomFeuille, string nomTable)
        {
            Table personnes = Global.BaseDonneesCABS.EnvoyerRequeteSelectionDirect(NOM_TABLE_PERSONNE, String.Format(FORMAT_REQUETE_PERSONNES, nomTable, ""));
            AjusterDonneesPersonnes(personnes);

            personnes.RetirerChamp("perId");

            Feuille feuille = new Feuille(nomFeuille, 2);
            feuille.AjouterTableau(new Tableau(personnes, nomFeuille));

            Classeur document = new Classeur();
            document.AjouterFeuille(feuille);

            frmPrincipal formulairePrincipal = ParentForm is frmPrincipal ? (frmPrincipal)ParentForm : null;

            if (formulairePrincipal != null)
                formulairePrincipal.AfficherIndication("Génération du document Excel");

            document.Generer();

            if (formulairePrincipal != null)
                formulairePrincipal.EffacerIndication();
        }

        private void AjusterDonneesPersonnes(Table personnes)
        {
            personnes.Lignes.ForEach(
                l =>
                {
                    if (l.GetChamp("perSexe") != null && l.GetValeurChamp<bool>("perSexe"))
                        l.GetChamp("perSexe").Valeur = "F";
                    else
                        l.GetChamp("perSexe").Valeur = "H";

                    TimeSpan age = DateTime.Now - l.GetValeurChamp<DateTime>("perDateNaissance");
                    l.AjouterChamp("perAge", age.Days / 365, "perDateDerniereMaj");
                });

            if (cbExclureCommentaires.Checked)
                personnes.RetirerChamp("perCommentaires");
        }

        private void cbBeneficiairesParServices_CheckedChanged(object sender, EventArgs e)
        {
            if (cbBeneficiairesParServices.Checked)
                cbBeneficiairesService.Checked = false;
        }

        private void cbBeneficiairesService_CheckedChanged(object sender, EventArgs e)
        {
            if (cbBeneficiairesService.Checked)
                cbBeneficiairesParServices.Checked = false;

            cmbServiceBeneficiaires.Enabled = cbBeneficiairesService.Checked;
        }

        private void cbBenevolesParServices_CheckedChanged(object sender, EventArgs e)
        {
            if (cbBenevolesParServices.Checked)
                cbBenevolesService.Checked = false;
        }

        private void cbBenevolesService_CheckedChanged(object sender, EventArgs e)
        {
            if (cbBenevolesService.Checked)
                cbBenevolesParServices.Checked = false;

            cmbServiceBenevoles.Enabled = cbBenevolesService.Checked;
        }
    }
}