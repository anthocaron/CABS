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

namespace CABS.Formulaires.Inscription
{
    public partial class frmDisponibiliteServicesBenevoles : Formulaire
    {
        private LigneTable BenevoleCourant;

        public frmDisponibiliteServicesBenevoles()
            : base(true, true)
        {
            InitializeComponent();
            BenevoleCourant = null;

            cmbService.MouseWheel += new MouseEventHandler(cmbService_MouseWheel);
        }

        private void cmbService_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        public override void EntrerPage()
        {
            base.EntrerPage();

            RequeteSelection reqSel = new RequeteSelection(NomTable.service);
            reqSel.AjouterTri("serNom");
            Table services = Global.BaseDonneesCABS.EnvoyerRequeteSelection(reqSel);

            ComboBoxItem itemService;
            cmbService.Items.Clear();

            foreach (LigneTable service in services.Lignes)
            {
                itemService = new ComboBoxItem(service.GetValeurChamp<string>("serNom"), service.GetValeurChamp<int>("serId"));
                cmbService.Items.Add(itemService);
            }

            if (cmbService.Items.Count > 0)
                cmbService.SelectedIndex = 0;
        }

        public override void EnvoyerMessages(params object[] messages)
        {
            if (messages.Length == 1 && messages[0] is LigneTable)
                ChargerBenevole((LigneTable)messages[0]);
        }

        private void btnChoisirBenevole_Click(object sender, EventArgs e)
        {
            RequeteSelection reqSel = new RequeteSelection(NomTable.statut, "staId");
            reqSel.Condition = new ConditionRequete(Operateur.COMME, "staNom", "'Actif'");

            Table statutActif = Global.BaseDonneesCABS.EnvoyerRequeteSelection(reqSel);

            if (statutActif.EstVide || statutActif.NombreLignes > 1)
            {
                Journal.AfficherMessage("La table des statuts est inexistante ou corrompue. L'action a été annulée.", TypeMessage.ERREUR, true);
                return;
            }

            int indexStatutActif = statutActif.Lignes[0].GetValeurChamp<int>("staId");

            Table benevoles = Global.BaseDonneesCABS.EnvoyerRequeteSelectionDirect("Personne", "SELECT p.* FROM Personne p INNER JOIN Benevole b ON p.perId = b.perId WHERE p.staId=" + indexStatutActif + " ORDER BY perNom, perPrenom, perDateNaissance;");
            frmSelectionTable choixBenevole = new frmSelectionTable("Choisir un bénévole...", benevoles, new List<string> { "perNom", "perPrenom", "perDateNaissance" }, "perId");

            if (choixBenevole.AfficherDialogue(this))
                ChargerBenevole(choixBenevole.LigneChoisie);
        }

        private void ChargerBenevole(LigneTable ligneTable)
        {
            if (ligneTable == null)
                return;

            BenevoleCourant = ligneTable;
            lblPrenomValeur.Text = ligneTable.GetValeurChamp<string>("perPrenom");
            lblNomValeur.Text = ligneTable.GetValeurChamp<string>("perNom");
            RafraichirService();
        }

        private void cmbService_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BenevoleCourant != null)
                RafraichirService();
        }

        private void RafraichirService()
        {
            ConditionRequete condReqSel = new ConditionRequete(Operateur.EGAL, "perId", BenevoleCourant.GetChamp("perId").ValeurSQL);
            condReqSel.LierCondition(new ConditionRequete(Operateur.EGAL, "serId", (cmbService.SelectedItem as ComboBoxItem).Value.ToString()), true);

            RequeteSelection reqSel = new RequeteSelection(NomTable.disponibiliteservice);
            reqSel.Condition = condReqSel;

            Table disponibilite = Global.BaseDonneesCABS.EnvoyerRequeteSelection(reqSel);

            if (!disponibilite.EstVide)
                ChangerAccesControle(ModeFormulaire.CONSULTATION);
            else
                ChangerAccesControle(ModeFormulaire.AJOUT);
        }

        private void btnEntrerDispo_Click(object sender, EventArgs e)
        {
            if (Enregistrer())
                ChangerAccesControle(ModeFormulaire.CONSULTATION);
        }

        public override bool Enregistrer()
        {
            if (!base.Enregistrer())
                return false;

            LigneTable inscription = new LigneTable("DisponibiliteService");
            inscription.AjouterChamp("perId", BenevoleCourant.GetValeurChamp<int>("perId"));
            inscription.AjouterChamp("serId", (cmbService.SelectedItem as ComboBoxItem).Value);

            RequeteAjout reqAjout = new RequeteAjout(NomTable.disponibiliteservice, inscription);
            if (Global.BaseDonneesCABS.EnvoyerRequeteAjout(reqAjout) < 0)
            {
                Journal.AfficherMessage("Une erreur est survenue lors de l'enregistrement de la disponibilité. L'action a été annulée", TypeMessage.ERREUR, true);
                Global.BaseDonneesCABS.AnnulerTransaction();
                return false;
            }

            return true;
        }

        private void btnRetirerDispo_Click(object sender, EventArgs e)
        {
            if(Supprimer())
                ChangerAccesControle(ModeFormulaire.AJOUT);
        }

        public override bool Supprimer()
        {
            if (!base.Supprimer())
                return false;

            ConditionRequete condSup = new ConditionRequete(Operateur.EGAL, "perId", BenevoleCourant.GetChamp("perId").ValeurSQL);
            condSup.LierCondition(new ConditionRequete(Operateur.EGAL, "serId", (cmbService.SelectedItem as ComboBoxItem).Value.ToString()), true);

            RequeteSuppression reqSup = new RequeteSuppression(NomTable.disponibiliteservice, condSup);
            if (Global.BaseDonneesCABS.EnvoyerRequeteSuppression(reqSup) < 0)
            {
                Global.BaseDonneesCABS.AnnulerTransaction();
                Journal.AfficherMessage("Une erreur est survenue lors du retirement de la disponibilité. L'action a été annulée", TypeMessage.ERREUR, true);
                return false;
            }

            return true;
        }

        public override void ChangerAccesControle(ModeFormulaire mode)
        {
            btnEntrerDispo.Enabled = mode == ModeFormulaire.AJOUT;
            btnRetirerDispo.Enabled = mode == ModeFormulaire.CONSULTATION;
        }
    }
}
