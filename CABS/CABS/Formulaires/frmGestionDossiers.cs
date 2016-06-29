using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CABS.BaseDonnees;
using CABS.Outils;

namespace CABS.Formulaires
{
    public partial class frmGestionDossiers : Formulaire
    {
        private const string NomProcedurePersonnesInactives = "PersonnesInactives";

        private LigneTable PersonneCourante;
        private Table Statuts;

        public frmGestionDossiers()
            : base(true, true)
        {
            InitializeComponent();
            PersonneCourante = null;

            Statuts = Global.BaseDonneesCABS.EnvoyerRequeteSelection(new RequeteSelection(NomTable.statut));
        }

        public override void EntrerPage()
        {
            base.EntrerPage();

            Table personnesInactives = Global.BaseDonneesCABS.EnvoyerRequeteSelectionProcedure("Personne", NomProcedurePersonnesInactives, null);

            gtPersonnesInactives.Initialiser(personnesInactives, new List<string>() { "perNom", "perPrenom", "perDateNaissance" });
            gtPersonnesInactives.Charger();
        }

        public override void EnvoyerMessages(params object[] messages)
        {
            if (messages.Length == 1 && messages[0] is LigneTable)
                ChargerDossierPersonne((LigneTable)messages[0]);
        }

        private void btnChoisirPersonne_Click(object sender, EventArgs e)
        {
            RequeteSelection reqSel = new RequeteSelection(NomTable.personne);
            reqSel.AjouterTri("perNom");
            reqSel.AjouterTri("perPrenom");
            reqSel.AjouterTri("perDateNaissance");

            Table personnes = Global.BaseDonneesCABS.EnvoyerRequeteSelection(reqSel);
            frmSelectionTable choixAdresses = new frmSelectionTable("Choisir une personne...", personnes, new List<string> { "perNom", "perPrenom", "perDateNaissance" }, "perId");

            if (choixAdresses.AfficherDialogue(this))
            {
                ChargerDossierPersonne(choixAdresses.LigneChoisie);
            }
        }

        private void gtPersonnesInactives_RowDoubleClick(object sender, RowDoubleClickEventArgs e)
        {
            ChargerDossierPersonne(e.LigneCliquee);
        }

        public override void Vider()
        {
            base.Vider();

            lblPrenomValeur.Text = lblStatutValeur.Text = lblDateDerniereMajValeur.Text = lblDateOuvertureValeur.Text = lblDateInactiviteValeur.Text = lblDateFermetureValeur.Text = "";
        }

        private void ChargerDossierPersonne(LigneTable ligneTable)
        {
            PersonneCourante = ligneTable;

            if (PersonneCourante == null)
            {
                Vider();
            }
            else
            {
                lblNomValeur.Text = ligneTable.GetValeurChamp<string>("perNom");
                lblPrenomValeur.Text = ligneTable.GetValeurChamp<string>("perPrenom");

                int idStatut = ligneTable.GetValeurChamp<int>("staId");
                LigneTable ligneStatut = Statuts.Lignes.Find(l => l.GetValeurChamp<int>("staId") == idStatut);
                lblStatutValeur.Text = ligneStatut != null ? ligneStatut.GetValeurChamp<string>("staNom") : "";

                lblDateDerniereMajValeur.Text = ligneTable.GetValeurChamp<DateTime>("perDateDerniereMaj").ToShortDateString();
                lblDateOuvertureValeur.Text = ligneTable.GetValeurChamp<DateTime>("perDateOuverture").ToShortDateString();
                lblDateInactiviteValeur.Text = ligneTable.GetValeurChamp<DateTime>("perDateInactivite").ToShortDateString();
                lblDateFermetureValeur.Text = ligneTable.GetValeurChamp<DateTime>("perDateFermeture").ToShortDateString();
            }
        }

        private void cbDateSpecOuverture_CheckedChanged(object sender, EventArgs e)
        {
            dtpDateSpecOuverture.Enabled = cbDateSpecOuverture.Checked;
        }

        private void cbDateSpecInactivite_CheckedChanged(object sender, EventArgs e)
        {
            dtpDateSpecInactivite.Enabled = cbDateSpecInactivite.Checked;
        }

        private void cbDateSpecFermeture_CheckedChanged(object sender, EventArgs e)
        {
            dtpDateSpecFermeture.Enabled = cbDateSpecFermeture.Checked;
        }

        private void btnOuvrirDossier_Click(object sender, EventArgs e)
        {
            DateTime nouvelleDateOuverture = cbDateSpecOuverture.Checked ? dtpDateSpecOuverture.Value : DateTime.Now;

            if (PersonneCourante == null || !OutilsForms.VerifierCondition(nouvelleDateOuverture > DateTime.Now, "Veuillez entrer une date d'ouverture valide."))
                return;

            PersonneCourante.AjouterChamp("perDateOuverture", nouvelleDateOuverture);
            PersonneCourante.AjouterChamp("staId", Statuts.Lignes.Find(s => s.GetValeurChamp<string>("staNom") == "Actif").GetChamp("staId").Valeur);

            if (!Enregistrer())
            {
                Journal.AfficherMessage("Une erreur s'est produite lors de l'ouverture du dossier. L'action a été annulée.", TypeMessage.ERREUR, true);
            }
            else
            {
                EntrerPage();
                ChargerDossierPersonne(PersonneCourante);
            }
        }

        private void btnRendreInactif_Click(object sender, EventArgs e)
        {
            DateTime nouvelleDateInactivite = cbDateSpecInactivite.Checked ? dtpDateSpecInactivite.Value : DateTime.Now;

            if (PersonneCourante == null || !OutilsForms.VerifierCondition(nouvelleDateInactivite > DateTime.Now, "Veuillez entrer une date d'inactivité valide."))
                return;

            PersonneCourante.AjouterChamp("perDateInactivite", nouvelleDateInactivite);
            PersonneCourante.AjouterChamp("staId", Statuts.Lignes.Find(s => s.GetValeurChamp<string>("staNom") == "Inactif").GetChamp("staId").Valeur);

            if (!Enregistrer())
            {
                Journal.AfficherMessage("Une erreur s'est produite lors de la désactivation du dossier. L'action a été annulée.", TypeMessage.ERREUR, true);
            }
            else
            {
                EntrerPage();
                ChargerDossierPersonne(PersonneCourante);
            }
        }

        private void btnFermerDossier_Click(object sender, EventArgs e)
        {
            DateTime nouvelleDateFermeture = cbDateSpecFermeture.Checked ? dtpDateSpecFermeture.Value : DateTime.Now;

            if (PersonneCourante == null || !OutilsForms.VerifierCondition(nouvelleDateFermeture > DateTime.Now, "Veuillez entrer une date de fermeture valide."))
                return;

            PersonneCourante.AjouterChamp("perDateFermeture", nouvelleDateFermeture);
            PersonneCourante.AjouterChamp("staId", Statuts.Lignes.Find(s => s.GetValeurChamp<string>("staNom") == "Fermé").GetChamp("staId").Valeur);

            if (!Enregistrer())
            {
                Journal.AfficherMessage("Une erreur s'est produite lors de la fermeture du dossier. L'action a été annulée.", TypeMessage.ERREUR, true);
            }
            else
            {
                EntrerPage();
                ChargerDossierPersonne(PersonneCourante);
            }
        }

        public override bool Enregistrer()
        {
            if (!base.Enregistrer())
                return false;

            PersonneCourante.AjouterChamp("perDateDerniereMaj", DateTime.Now);

            Champ indexPersonne = PersonneCourante.GetChamp("perId");

            LigneTable personne = new LigneTable("Personne");
            personne.AjouterChamp("perDateDerniereMaj", PersonneCourante.GetValeurChamp<DateTime>("perDateDerniereMaj"));
            personne.AjouterChamp("perDateOuverture", PersonneCourante.GetValeurChamp<DateTime>("perDateOuverture"));
            personne.AjouterChamp("perDateFermeture", PersonneCourante.GetValeurChamp<DateTime>("perDateFermeture"));
            personne.AjouterChamp("perDateInactivite", PersonneCourante.GetValeurChamp<DateTime>("perDateInactivite"));
            personne.AjouterChamp("staId", PersonneCourante.GetValeurChamp<int>("staId"));

            RequeteModification reqModif = new RequeteModification(NomTable.personne, new ConditionRequete(Operateur.EGAL, indexPersonne), personne);
            if (Global.BaseDonneesCABS.EnvoyerRequeteModification(reqModif) <= 0)
            {
                return false;
            }

            return true;
        }
    }
}