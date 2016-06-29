using CABS.BaseDonnees;
using CABS.Outils;

namespace CABS.Formulaires.Inscription
{
    public partial class frmInscriptionAtelierJouets : Formulaire
    {
        private int IndexBeneficiaireCourant;

        public frmInscriptionAtelierJouets()
            : base(true, false)
        {
            InitializeComponent();
            IndexBeneficiaireCourant = 0;
        }

        public override void EnvoyerMessages(params object[] messages)
        {
            if (messages.Length == 1 && messages[0] is int)
            {
                IndexBeneficiaireCourant = (int)messages[0];

                RequeteSelection reqSel = new RequeteSelection(NomTable.inscriptionatelierjouets);
                reqSel.Condition = new ConditionRequete(Operateur.EGAL, "perId", IndexBeneficiaireCourant.ToString());

                Table inscriptionLifeline = Global.BaseDonneesCABS.EnvoyerRequeteSelection(reqSel);

                if (!inscriptionLifeline.EstVide)
                {
                    LigneTable infosInscription = inscriptionLifeline.Lignes[0];

                    nudNbEnfants.Value = infosInscription.GetValeurChamp<int>("iajNombreEnfants");

                    txtAges.Text = infosInscription.GetValeurChamp<string>("iajAgesEnfants");
                    txtDetailsFactures.Text = infosInscription.GetValeurChamp<string>("iajDetailsFactures");
                    txtDetailsAutres.Text = infosInscription.GetValeurChamp<string>("iajDetailsAutres");

                    cbAllocationFamiliale.Checked = infosInscription.GetValeurChamp<bool>("iajAllocationFamiliale");
                    cbCarteMedicament.Checked = infosInscription.GetValeurChamp<bool>("iajCarteMedicament");
                    cbCarteAssuranceMaladie.Checked = infosInscription.GetValeurChamp<bool>("iajCarteAssuranceMaladie");
                    cbPermisConduire.Checked = infosInscription.GetValeurChamp<bool>("iajPermisConduire");
                    cbProprietaire.Checked = infosInscription.GetValeurChamp<bool>("iajProprietaire");
                    cbLocataire.Checked = infosInscription.GetValeurChamp<bool>("iajLocataire");
                    cbBail.Checked = infosInscription.GetValeurChamp<bool>("iajBail");
                    cbFactures.Checked = infosInscription.GetValeurChamp<bool>("iajFactures");
                    cbPerteEmploi.Checked = infosInscription.GetValeurChamp<bool>("iajPerteEmploi");
                    cbSeparation.Checked = infosInscription.GetValeurChamp<bool>("iajSeparation");
                    cbAccidentMaladie.Checked = infosInscription.GetValeurChamp<bool>("iajAccidentAutoMaladie");
                    cbFaibleRevenu.Checked = infosInscription.GetValeurChamp<bool>("iajFaibleRevenu");
                    cbAccidentTravail.Checked = infosInscription.GetValeurChamp<bool>("iajAccidentTravail");
                    cbDemenagement.Checked = infosInscription.GetValeurChamp<bool>("iajDemenagement");
                    cbAutres.Checked = infosInscription.GetValeurChamp<bool>("iajAutres");
                }
                else
                {
                    Vider();
                }
            }
        }

        public override void Vider()
        {
            base.Vider();

            nudNbEnfants.Value = 1;
            txtAges.Text = txtDetailsFactures.Text = txtDetailsAutres.Text = "";
            cbAllocationFamiliale.Checked = cbCarteMedicament.Checked = cbCarteAssuranceMaladie.Checked = cbPermisConduire.Checked = cbProprietaire.Checked =
            cbLocataire.Checked = cbBail.Checked = cbFactures.Checked = cbPerteEmploi.Checked = cbSeparation.Checked =
            cbAccidentMaladie.Checked = cbFaibleRevenu.Checked = cbAccidentTravail.Checked = cbDemenagement.Checked = cbAutres.Checked = false;
        }

        public override void ChangerAccesControle(ModeFormulaire mode)
        {
            base.ChangerAccesControle(mode);

            nudNbEnfants.Enabled =
            txtAges.Enabled = 
            cbAllocationFamiliale.Enabled = cbCarteMedicament.Enabled = cbCarteAssuranceMaladie.Enabled = cbPermisConduire.Enabled = cbProprietaire.Enabled =
            cbLocataire.Enabled = cbBail.Enabled = cbFactures.Enabled = cbPerteEmploi.Enabled = cbSeparation.Enabled =
            cbAccidentMaladie.Enabled = cbFaibleRevenu.Enabled = cbAccidentTravail.Enabled = cbDemenagement.Enabled = cbAutres.Enabled = Mode != ModeFormulaire.CONSULTATION;
            
            txtDetailsFactures.Enabled = Mode != ModeFormulaire.CONSULTATION && cbFactures.Checked;
            txtDetailsAutres.Enabled = Mode != ModeFormulaire.CONSULTATION && cbAutres.Checked;
        }

        public override bool Enregistrer()
        {
            if (!base.Enregistrer())
                return false;

            LigneTable inscriptionAtelierJouets = new LigneTable("InscriptionAtelierJouets");

            inscriptionAtelierJouets.AjouterChamp("iajNombreEnfants", nudNbEnfants.Value);

            inscriptionAtelierJouets.AjouterChamp("iajAgesEnfants", txtAges.Text);
            inscriptionAtelierJouets.AjouterChamp("iajDetailsFactures", txtDetailsFactures.Text);
            inscriptionAtelierJouets.AjouterChamp("iajDetailsAutres", txtDetailsAutres.Text);

            inscriptionAtelierJouets.AjouterChamp("iajAllocationFamiliale", cbAllocationFamiliale.Checked);
            inscriptionAtelierJouets.AjouterChamp("iajCarteMedicament", cbCarteMedicament.Checked);
            inscriptionAtelierJouets.AjouterChamp("iajCarteAssuranceMaladie", cbCarteAssuranceMaladie.Checked);
            inscriptionAtelierJouets.AjouterChamp("iajPermisConduire", cbPermisConduire.Checked);
            inscriptionAtelierJouets.AjouterChamp("iajProprietaire", cbProprietaire.Checked);
            inscriptionAtelierJouets.AjouterChamp("iajLocataire", cbLocataire.Checked);
            inscriptionAtelierJouets.AjouterChamp("iajBail", cbBail.Checked);
            inscriptionAtelierJouets.AjouterChamp("iajFactures", cbFactures.Checked);
            inscriptionAtelierJouets.AjouterChamp("iajPerteEmploi", cbPerteEmploi.Checked);
            inscriptionAtelierJouets.AjouterChamp("iajSeparation", cbSeparation.Checked);
            inscriptionAtelierJouets.AjouterChamp("iajAccidentAutoMaladie", cbAccidentMaladie.Checked);
            inscriptionAtelierJouets.AjouterChamp("iajFaibleRevenu", cbFaibleRevenu.Checked);
            inscriptionAtelierJouets.AjouterChamp("iajAccidentTravail", cbAccidentTravail.Checked);
            inscriptionAtelierJouets.AjouterChamp("iajDemenagement", cbDemenagement.Checked);
            inscriptionAtelierJouets.AjouterChamp("iajAutres", cbAutres.Checked);

            if (Mode == ModeFormulaire.AJOUT)
            {
                inscriptionAtelierJouets.AjouterChamp("perId", IndexBeneficiaireCourant);
                RequeteAjout reqAjout = new RequeteAjout(NomTable.inscriptionatelierjouets, inscriptionAtelierJouets);

                if (Global.BaseDonneesCABS.EnvoyerRequeteAjout(reqAjout) < 0)
                {
                    Journal.AfficherMessage("Une erreur est survenue lors de l'inscription au dépannage alimentaire. L'action a été annulée.", TypeMessage.ERREUR, true);
                    return false;
                }
            }
            else if (Mode == ModeFormulaire.EDITION)
            {
                RequeteModification reqModif = new RequeteModification(NomTable.inscriptionatelierjouets,
                                                                       new ConditionRequete(Operateur.EGAL, "perId", IndexBeneficiaireCourant.ToString()),
                                                                       inscriptionAtelierJouets);

                if (Global.BaseDonneesCABS.EnvoyerRequeteModification(reqModif) < 0)
                {
                    Journal.AfficherMessage("Une erreur est survenue lors de la modification de l'inscription au dépannage alimentaire. L'action a été annulée.", TypeMessage.ERREUR, true);
                    return false;
                }
            }

            return true;
        }

        public override bool Supprimer()
        {
            if (!base.Supprimer())
                return false;

            ConditionRequete condBeneficiaire = new ConditionRequete(Operateur.EGAL, "perId", IndexBeneficiaireCourant.ToString());
            RequeteSuppression reqSupInscription = new RequeteSuppression(NomTable.inscriptionatelierjouets, condBeneficiaire);

            if (Global.BaseDonneesCABS.EnvoyerRequeteSuppression(reqSupInscription) < 0)
            {
                Journal.AfficherMessage("Une erreur est survenue lors de la suppression de l'inscription au dépannage alimentaire. L'action a été annulée.", TypeMessage.ERREUR, true);
                return false;
            }

            return true;
        }

        private void cbFactures_CheckedChanged(object sender, System.EventArgs e)
        {
            txtDetailsFactures.Enabled = cbFactures.Checked;
        }

        private void cbAutres_CheckedChanged(object sender, System.EventArgs e)
        {
            txtDetailsAutres.Enabled = cbAutres.Checked;
        }
    }
}
