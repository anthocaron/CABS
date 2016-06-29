using CABS.BaseDonnees;
using CABS.Outils;

namespace CABS.Formulaires.Inscription
{
    public partial class frmInscriptionDepannageAlimentaire : Formulaire
    {
        private int IndexBeneficiaireCourant;

        public frmInscriptionDepannageAlimentaire()
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

                RequeteSelection reqSel = new RequeteSelection(NomTable.inscriptiondepannagealimentaire);
                reqSel.Condition = new ConditionRequete(Operateur.EGAL, "perId", IndexBeneficiaireCourant.ToString());

                Table inscriptionLifeline = Global.BaseDonneesCABS.EnvoyerRequeteSelection(reqSel);

                if (!inscriptionLifeline.EstVide)
                {
                    LigneTable infosInscription = inscriptionLifeline.Lignes[0];

                    nudNbEnfants.Value = infosInscription.GetValeurChamp<int>("idaNombreEnfants");

                    txtAges.Text = infosInscription.GetValeurChamp<string>("idaAgesEnfants");
                    txtDetailsFactures.Text = infosInscription.GetValeurChamp<string>("idaDetailsFactures");
                    txtDetailsAutres.Text = infosInscription.GetValeurChamp<string>("idaDetailsAutres");

                    cbAllocationFamiliale.Checked = infosInscription.GetValeurChamp<bool>("idaAllocationFamiliale");
                    cbCarteMedicament.Checked = infosInscription.GetValeurChamp<bool>("idaCarteMedicament");
                    cbCarteAssuranceMaladie.Checked = infosInscription.GetValeurChamp<bool>("idaCarteAssuranceMaladie");
                    cbPermisConduire.Checked = infosInscription.GetValeurChamp<bool>("idaPermisConduire");
                    cbProprietaire.Checked = infosInscription.GetValeurChamp<bool>("idaProprietaire");
                    cbLocataire.Checked = infosInscription.GetValeurChamp<bool>("idaLocataire");
                    cbBail.Checked = infosInscription.GetValeurChamp<bool>("idaBail");
                    cbFactures.Checked = infosInscription.GetValeurChamp<bool>("idaFactures");
                    cbPerteEmploi.Checked = infosInscription.GetValeurChamp<bool>("idaPerteEmploi");
                    cbSeparation.Checked = infosInscription.GetValeurChamp<bool>("idaSeparation");
                    cbAccidentMaladie.Checked = infosInscription.GetValeurChamp<bool>("idaAccidentAutoMaladie");
                    cbFaibleRevenu.Checked = infosInscription.GetValeurChamp<bool>("idaFaibleRevenu");
                    cbAccidentTravail.Checked = infosInscription.GetValeurChamp<bool>("idaAccidentTravail");
                    cbDemenagement.Checked = infosInscription.GetValeurChamp<bool>("idaDemenagement");
                    cbAutres.Checked = infosInscription.GetValeurChamp<bool>("idaAutres");
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

            LigneTable inscriptionDepannageAlimentaire = new LigneTable("InscriptionDepannageAlimentaire");

            inscriptionDepannageAlimentaire.AjouterChamp("idaNombreEnfants", nudNbEnfants.Value);

            inscriptionDepannageAlimentaire.AjouterChamp("idaAgesEnfants", txtAges.Text);
            inscriptionDepannageAlimentaire.AjouterChamp("idaDetailsFactures", txtDetailsFactures.Text);
            inscriptionDepannageAlimentaire.AjouterChamp("idaDetailsAutres", txtDetailsAutres.Text);

            inscriptionDepannageAlimentaire.AjouterChamp("idaAllocationFamiliale", cbAllocationFamiliale.Checked);
            inscriptionDepannageAlimentaire.AjouterChamp("idaCarteMedicament", cbCarteMedicament.Checked);
            inscriptionDepannageAlimentaire.AjouterChamp("idaCarteAssuranceMaladie", cbCarteAssuranceMaladie.Checked);
            inscriptionDepannageAlimentaire.AjouterChamp("idaPermisConduire", cbPermisConduire.Checked);
            inscriptionDepannageAlimentaire.AjouterChamp("idaProprietaire", cbProprietaire.Checked);
            inscriptionDepannageAlimentaire.AjouterChamp("idaLocataire", cbLocataire.Checked);
            inscriptionDepannageAlimentaire.AjouterChamp("idaBail", cbBail.Checked);
            inscriptionDepannageAlimentaire.AjouterChamp("idaFactures", cbFactures.Checked);
            inscriptionDepannageAlimentaire.AjouterChamp("idaPerteEmploi", cbPerteEmploi.Checked);
            inscriptionDepannageAlimentaire.AjouterChamp("idaSeparation", cbSeparation.Checked);
            inscriptionDepannageAlimentaire.AjouterChamp("idaAccidentAutoMaladie", cbAccidentMaladie.Checked);
            inscriptionDepannageAlimentaire.AjouterChamp("idaFaibleRevenu", cbFaibleRevenu.Checked);
            inscriptionDepannageAlimentaire.AjouterChamp("idaAccidentTravail", cbAccidentTravail.Checked);
            inscriptionDepannageAlimentaire.AjouterChamp("idaDemenagement", cbDemenagement.Checked);
            inscriptionDepannageAlimentaire.AjouterChamp("idaAutres", cbAutres.Checked);

            if (Mode == ModeFormulaire.AJOUT)
            {
                inscriptionDepannageAlimentaire.AjouterChamp("perId", IndexBeneficiaireCourant);
                RequeteAjout reqAjout = new RequeteAjout(NomTable.inscriptiondepannagealimentaire, inscriptionDepannageAlimentaire);

                if (Global.BaseDonneesCABS.EnvoyerRequeteAjout(reqAjout) < 0)
                {
                    Journal.AfficherMessage("Une erreur est survenue lors de l'inscription au dépannage alimentaire. L'action a été annulée.", TypeMessage.ERREUR, true);
                    return false;
                }
            }
            else if (Mode == ModeFormulaire.EDITION)
            {
                RequeteModification reqModif = new RequeteModification(NomTable.inscriptiondepannagealimentaire,
                                                                       new ConditionRequete(Operateur.EGAL, "perId", IndexBeneficiaireCourant.ToString()),
                                                                       inscriptionDepannageAlimentaire);

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
            RequeteSuppression reqSupInscription = new RequeteSuppression(NomTable.inscriptiondepannagealimentaire, condBeneficiaire);

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
