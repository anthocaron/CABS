using CABS.BaseDonnees;
using CABS.Outils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CABS.Formulaires.Inscription
{
    public partial class frmInscriptionServicesBeneficiaires : Formulaire
    {
        private LigneTable BeneficiaireCourant;
        private Formulaire FormulaireCourant;

        public frmInscriptionServicesBeneficiaires()
            : base(true, true)
        {
            InitializeComponent();
            BeneficiaireCourant = null;
            FormulaireCourant = null;

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

            if(cmbService.Items.Count > 0)
                cmbService.SelectedIndex = 0;
        }

        public override void EnvoyerMessages(params object[] messages)
        {
            foreach (object m in messages)
            {
                if(m is LigneTable)
                {
                    ChargerBeneficiaire((LigneTable)m);
                }
                else if (m is int)
                {
                    for (int i = 0; i < cmbService.Items.Count; ++i)
                    {
                        if ((int)((ComboBoxItem)cmbService.Items[i]).Value == (int)m)
                        {
                            cmbService.SelectedIndex = i;
                            break;
                        }
                    }
                }
            }
        }

        private void btnChoisirBeneficiaire_Click(object sender, EventArgs e)
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

            Table beneficiaires = Global.BaseDonneesCABS.EnvoyerRequeteSelectionDirect("Personne", "SELECT p.* FROM Personne p INNER JOIN Beneficiaire b ON p.perId = b.perId WHERE p.staId=" + indexStatutActif + " ORDER BY perNom, perPrenom, perDateNaissance;");
            frmSelectionTable choixBeneficiaire = new frmSelectionTable("Choisir un bénéficiaire...", beneficiaires, new List<string> { "perNom", "perPrenom", "perDateNaissance" }, "perId");

            if (choixBeneficiaire.AfficherDialogue(this))
            {
                ChargerBeneficiaire(choixBeneficiaire.LigneChoisie);
            }
        }

        private void ChargerBeneficiaire(LigneTable ligneTable)
        {
            if (ligneTable == null)
                return;

            BeneficiaireCourant = ligneTable;
            lblPrenomValeur.Text = ligneTable.GetValeurChamp<string>("perPrenom");
            lblNomValeur.Text = ligneTable.GetValeurChamp<string>("perNom");
            RafraichirService();
        }

        private void cmbService_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BeneficiaireCourant == null)
                return;

            if (FormulaireCourant.Name != Global.GetNomFormulaireInscription(cmbService.Text))
                RafraichirService();
        }

        private void RafraichirService()
        {
            ConditionRequete condReqSel = new ConditionRequete(Operateur.EGAL, "perId", BeneficiaireCourant.GetChamp("perId").ValeurSQL);
            condReqSel.LierCondition(new ConditionRequete(Operateur.EGAL, "serId", (cmbService.SelectedItem as ComboBoxItem).Value.ToString()), true);

            RequeteSelection reqSel = new RequeteSelection(NomTable.inscriptionservice);
            reqSel.Condition = condReqSel;

            Table inscription = Global.BaseDonneesCABS.EnvoyerRequeteSelection(reqSel);
            string nomFormulaire = Global.GetNomFormulaireInscription(cmbService.Text);

            panFormulaireInscription.Controls.Clear();

            Type typeFormulaire = Type.GetType(nomFormulaire);

            try
            {
                FormulaireCourant = (Formulaire)Activator.CreateInstance(typeFormulaire);
            }
            catch (Exception)
            {
                FormulaireCourant = null;
                return;
            }

            if (!inscription.EstVide)
            {
                ChangerAccesControle(ModeFormulaire.CONSULTATION);

                LigneTable infosInscription = inscription.Lignes[0];

                dtpDateDemande.Value = infosInscription.GetValeurChamp<DateTime>("insDateDemande");
                cbSuspendu.Checked = infosInscription.GetValeurChamp<bool>("insSuspendu");
                txtCommentaires.Text = infosInscription.GetValeurChamp<string>("insCommentaires");
            }
            else
            {
                ChangerAccesControle(ModeFormulaire.AJOUT);
                Vider();
                FormulaireCourant.Vider();
            }

            FormulaireCourant.Name = nomFormulaire;
            FormulaireCourant.Dock = DockStyle.Fill;
            FormulaireCourant.TopLevel = false;
            FormulaireCourant.AutoScroll = true;
            FormulaireCourant.EnvoyerMessages(BeneficiaireCourant.GetValeurChamp<int>("perId"));

            panFormulaireInscription.Controls.Add(FormulaireCourant);
            FormulaireCourant.Show();
        }

        public override void Vider()
        {
            base.Vider();

            dtpDateDemande.Value = DateTime.Now;
            cbSuspendu.Checked = false;
            txtCommentaires.Text = "";

            if (FormulaireCourant != null)
                FormulaireCourant.Vider();
        }

        private void btnInscrireService_Click(object sender, EventArgs e)
        {
            if (Enregistrer())
                ChangerAccesControle(ModeFormulaire.CONSULTATION);
        }

        public override bool Enregistrer()
        {
            Global.BaseDonneesCABS.CommencerTransaction();

            if (!base.Enregistrer() || !ValiderDonnees() || FormulaireCourant == null || !FormulaireCourant.Enregistrer())
            {
                Global.BaseDonneesCABS.AnnulerTransaction();
                return false;
            }

            LigneTable inscription = new LigneTable("InscriptionService");
            inscription.AjouterChamp("insDateDemande", dtpDateDemande.Value);
            inscription.AjouterChamp("insCommentaires", txtCommentaires.Text);

            if (Mode == ModeFormulaire.AJOUT)
            {
                inscription.AjouterChamp("perId", BeneficiaireCourant.GetValeurChamp<int>("perId"));
                inscription.AjouterChamp("serId", (cmbService.SelectedItem as ComboBoxItem).Value);

                RequeteAjout reqAjout = new RequeteAjout(NomTable.inscriptionservice, inscription);
                if (Global.BaseDonneesCABS.EnvoyerRequeteAjout(reqAjout) < 0)
                {
                    Journal.AfficherMessage("Une erreur est survenue lors de l'inscription du service. L'action a été annulée", TypeMessage.ERREUR, true);
                    Global.BaseDonneesCABS.AnnulerTransaction();
                    return false;
                }
            }
            else if (Mode == ModeFormulaire.EDITION)
            {
                ConditionRequete condModif = new ConditionRequete(Operateur.EGAL, "perId", BeneficiaireCourant.GetChamp("perId").ValeurSQL);
                condModif.LierCondition(new ConditionRequete(Operateur.EGAL, "serId", (cmbService.SelectedItem as ComboBoxItem).Value.ToString()), true);

                RequeteModification reqModif = new RequeteModification(NomTable.inscriptionservice, condModif, inscription);

                if (Global.BaseDonneesCABS.EnvoyerRequeteModification(reqModif) < 0)
                {
                    Journal.AfficherMessage("Une erreur est survenue lors de la modification des infos d'inscription. L'action a été annulée", TypeMessage.ERREUR, true);
                    Global.BaseDonneesCABS.AnnulerTransaction();
                    return false;
                }
            }

            Global.BaseDonneesCABS.ConfirmerTransaction();
            return true;
        }

        public override bool ValiderDonnees()
        {
            if (!base.ValiderDonnees())
                return false;

            if (!OutilsForms.VerifierCondition(dtpDateDemande.Value > DateTime.Now, "Veuillez entrer une date de demande valide"))
                return false;

            return true;
        }

        private void btnDesinscrireService_Click(object sender, EventArgs e)
        {
            if (!OutilsForms.PoserQuestion("Confirmation désinscription", "Voulez-vous vraiment désinscrire le bénéficiaire de ce service?"))
                return;

            if (Supprimer())
            {
                Vider();
                ChangerAccesControle(ModeFormulaire.AJOUT);
            }
        }

        public override bool Supprimer()
        {
            Global.BaseDonneesCABS.CommencerTransaction();

            if (!base.Supprimer() || FormulaireCourant == null || !FormulaireCourant.Supprimer())
            {
                Global.BaseDonneesCABS.AnnulerTransaction();
                return false;
            }

            ConditionRequete condSup = new ConditionRequete(Operateur.EGAL, "perId", BeneficiaireCourant.GetChamp("perId").ValeurSQL);
            condSup.LierCondition(new ConditionRequete(Operateur.EGAL, "serId", (cmbService.SelectedItem as ComboBoxItem).Value.ToString()), true);

            RequeteSuppression reqSup = new RequeteSuppression(NomTable.inscriptionservice, condSup);
            if (Global.BaseDonneesCABS.EnvoyerRequeteSuppression(reqSup) < 0)
            {
                Global.BaseDonneesCABS.AnnulerTransaction();
                Journal.AfficherMessage("Une erreur est survenue lors de la désincription du service. L'action a été annulée", TypeMessage.ERREUR, true);
                return false;
            }

            Global.BaseDonneesCABS.ConfirmerTransaction();
            return true;
        }

        private void btnModifierInscription_Click(object sender, EventArgs e)
        {
            ChangerAccesControle(ModeFormulaire.EDITION);
        }

        private void btnEnregistrerModification_Click(object sender, EventArgs e)
        {
            if (Enregistrer())
                ChangerAccesControle(ModeFormulaire.CONSULTATION);
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            RafraichirService();
        }

        public override void ChangerAccesControle(ModeFormulaire mode)
        {
            base.ChangerAccesControle(mode);

            dtpDateDemande.Enabled = txtCommentaires.Enabled = Mode != ModeFormulaire.CONSULTATION && !(FormulaireCourant is frmInscriptionIndisponible);

            btnDesinscrire.Enabled = btnModifierInfos.Enabled = Mode == ModeFormulaire.CONSULTATION;
            btnInscrire.Enabled = Mode == ModeFormulaire.AJOUT && !(FormulaireCourant is frmInscriptionIndisponible);
            btnEnregistrer.Enabled = btnAnnuler.Enabled = Mode == ModeFormulaire.EDITION;
            btnFicheBeneficiaire.Enabled = Mode == ModeFormulaire.AJOUT || Mode == ModeFormulaire.CONSULTATION;

            cbSuspendu.Enabled = Mode != ModeFormulaire.AJOUT && !(FormulaireCourant is frmInscriptionIndisponible);

            FormulaireCourant.ChangerAccesControle(Mode);
        }

        private void cbSuspendu_CheckedChanged(object sender, EventArgs e)
        {
            ConditionRequete condModif = new ConditionRequete(Operateur.EGAL, "perId", BeneficiaireCourant.GetChamp("perId").ValeurSQL);
            condModif.LierCondition(new ConditionRequete(Operateur.EGAL, "serId", (cmbService.SelectedItem as ComboBoxItem).Value.ToString()), true);

            Champ suspendu = new Champ("inscriptionservice", "insSuspendu", cbSuspendu.Checked);
            RequeteModification reqModif = new RequeteModification(NomTable.inscriptionservice, condModif, suspendu);

            if (Global.BaseDonneesCABS.EnvoyerRequeteModification(reqModif) < 0)
            {
                Journal.AfficherMessage("Une erreur est survenue lors de la suspension du service. L'action a été annulée", TypeMessage.ERREUR, true);
                cbSuspendu.Checked = !cbSuspendu.Checked;
            }
        }

        private void btnFicheBeneficiaire_Click(object sender, EventArgs e)
        {
            if (ParentForm is frmPrincipal)
                ((frmPrincipal)ParentForm).ChangerFormulaire("CABS.Formulaires.frmFichesPersonnes", BeneficiaireCourant);
        }
    }
}