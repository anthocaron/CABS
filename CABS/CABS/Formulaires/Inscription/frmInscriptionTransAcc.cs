using CABS.BaseDonnees;
using CABS.Outils;
using System;

namespace CABS.Formulaires.Inscription
{
    public partial class frmInscriptionTransAcc : Formulaire
    {
        private int IndexBeneficiaireCourant;

        public frmInscriptionTransAcc()
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

                RequeteSelection reqSel = new RequeteSelection(NomTable.inscriptiontransportaccompagement);
                reqSel.Condition = new ConditionRequete(Operateur.EGAL, "perId", IndexBeneficiaireCourant.ToString());

                Table inscriptionLifeline = Global.BaseDonneesCABS.EnvoyerRequeteSelection(reqSel);

                if (!inscriptionLifeline.EstVide)
                {
                    LigneTable infosInscription = inscriptionLifeline.Lignes[0];

                    txtNoDossierCLE.Text = infosInscription.GetValeurChamp<string>("itaNoDossierCLE").ToString();
                    txtNoDossierCSST.Text = infosInscription.GetValeurChamp<string>("itaNoDossierCSST").ToString();
                    txtNomAgent.Text = infosInscription.GetValeurChamp<string>("itaNomAgentCSST");
                    txtPrenomAgent.Text = infosInscription.GetValeurChamp<string>("itaPrenomAgentCSST");
                    mtxtTelephoneAgent.Text = infosInscription.GetValeurChamp<string>("itaTelephoneAgentCSST");
                    txtMobiliteReduite.Text = infosInscription.GetValeurChamp<string>("itaMobiliteReduite");
                    txtCapaciteAuditive.Text = infosInscription.GetValeurChamp<string>("itaCapaciteAuditive");
                    txtCapaciteVisuelle.Text = infosInscription.GetValeurChamp<string>("itaCapaciteVisuelle");
                    txtMemoire.Text = infosInscription.GetValeurChamp<string>("itaMemoire");
                    cbVuDDN.Checked = infosInscription.GetValeurChamp<bool>("itaVuDDN");
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

            cbVuDDN.Checked = false;
        }

        public override void ChangerAccesControle(ModeFormulaire mode)
        {
            base.ChangerAccesControle(mode);

            cbVuDDN.Enabled = Mode != ModeFormulaire.CONSULTATION;
        }

        public override bool Enregistrer()
        {
            if(!base.Enregistrer())
                return false;

            LigneTable inscriptionTransAcc = new LigneTable("InscriptionTransportAccompagnement");

            inscriptionTransAcc.AjouterChamp("itaNoDossierCLE", txtNoDossierCLE.Text);
            inscriptionTransAcc.AjouterChamp("itaNoDossierCSST", txtNoDossierCSST.Text);
            inscriptionTransAcc.AjouterChamp("itaNomAgentCSST", txtNomAgent.Text);
            inscriptionTransAcc.AjouterChamp("itaPrenomAgentCSST", txtPrenomAgent.Text);
            inscriptionTransAcc.AjouterChamp("itaTelephoneAgentCSST", mtxtTelephoneAgent.Text);
            inscriptionTransAcc.AjouterChamp("itaMobiliteReduite", txtMobiliteReduite.Text);
            inscriptionTransAcc.AjouterChamp("itaCapaciteAuditive", txtCapaciteAuditive.Text);
            inscriptionTransAcc.AjouterChamp("itaCapaciteVisuelle", txtCapaciteVisuelle.Text);
            inscriptionTransAcc.AjouterChamp("itaMemoire", txtMemoire.Text);
            inscriptionTransAcc.AjouterChamp("itaVuDDN", cbVuDDN.Checked);

            if (Mode == ModeFormulaire.AJOUT)
            {
                inscriptionTransAcc.AjouterChamp("perId", IndexBeneficiaireCourant);
                RequeteAjout reqAjout = new RequeteAjout(NomTable.inscriptiontransportaccompagement, inscriptionTransAcc);

                if (Global.BaseDonneesCABS.EnvoyerRequeteAjout(reqAjout) < 0)
                {
                    Journal.AfficherMessage("Une erreur est survenue lors de l'inscription au transport accompagnement. L'action a été annulée.", TypeMessage.ERREUR, true);
                    return false;
                }
            }
            else if (Mode == ModeFormulaire.EDITION)
            {
                RequeteModification reqModif = new RequeteModification(NomTable.inscriptiontransportaccompagement, 
                                                                       new ConditionRequete(Operateur.EGAL, "perId", IndexBeneficiaireCourant.ToString()), 
                                                                       inscriptionTransAcc);

                if (Global.BaseDonneesCABS.EnvoyerRequeteModification(reqModif) < 0)
                {
                    Journal.AfficherMessage("Une erreur est survenue lors de la modification de l'inscription au transport accompagnement. L'action a été annulée.", TypeMessage.ERREUR, true);
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
            RequeteSuppression reqSupInscription = new RequeteSuppression(NomTable.inscriptiontransportaccompagement, condBeneficiaire);

            if (Global.BaseDonneesCABS.EnvoyerRequeteSuppression(reqSupInscription) < 0)
            {
                Journal.AfficherMessage("Une erreur est survenue lors de la suppression de l'inscription au transport accompagnement. L'action a été annulée.", TypeMessage.ERREUR, true);
                return false;
            }

            return true;
        }
    }
}