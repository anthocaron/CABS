using CABS.BaseDonnees;
using CABS.Outils;

namespace CABS.Formulaires.Inscription
{
    public partial class frmInscriptionLifeline : Formulaire
    {
        private int IndexBeneficiaireCourant;

        public frmInscriptionLifeline()
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

                RequeteSelection reqSel = new RequeteSelection(NomTable.inscriptiontelesurveillancelifeline);
                reqSel.Condition = new ConditionRequete(Operateur.EGAL, "perId", IndexBeneficiaireCourant.ToString());

                Table inscriptionLifeline = Global.BaseDonneesCABS.EnvoyerRequeteSelection(reqSel);

                if (!inscriptionLifeline.EstVide)
                {
                    LigneTable infosInscription = inscriptionLifeline.Lignes[0];
                    txtNoUnite.Text = infosInscription.GetValeurChamp<string>("itlNoUnite");
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
            txtNoUnite.Text = "";
        }

        public override void ChangerAccesControle(ModeFormulaire mode)
        {
            base.ChangerAccesControle(mode);
            txtNoUnite.Enabled = Mode != ModeFormulaire.CONSULTATION;
        }

        public override bool Enregistrer()
        {
            if(!base.Enregistrer())
                return false;

            LigneTable inscriptionLifeline = new LigneTable("InscriptionTelesurveillanceLifeline");
            inscriptionLifeline.AjouterChamp("itlNoUnite", txtNoUnite.Text);

            if (Mode == ModeFormulaire.AJOUT)
            {
                inscriptionLifeline.AjouterChamp("perId", IndexBeneficiaireCourant);
                RequeteAjout reqAjout = new RequeteAjout(NomTable.inscriptiontelesurveillancelifeline, inscriptionLifeline);

                if (Global.BaseDonneesCABS.EnvoyerRequeteAjout(reqAjout) < 0)
                {
                    Journal.AfficherMessage("Une erreur est survenue lors de l'inscription à la télésurveillance Lifeline. L'action a été annulée.", TypeMessage.ERREUR, true);
                    return false;
                }
            }
            else if (Mode == ModeFormulaire.EDITION)
            {
                RequeteModification reqModif = new RequeteModification(NomTable.inscriptiontelesurveillancelifeline, 
                                                                       new ConditionRequete(Operateur.EGAL, "perId", IndexBeneficiaireCourant.ToString()), 
                                                                       inscriptionLifeline);

                if (Global.BaseDonneesCABS.EnvoyerRequeteModification(reqModif) < 0)
                {
                    Journal.AfficherMessage("Une erreur est survenue lors de la modification de l'inscription à la télésurveillance Lifeline. L'action a été annulée.", TypeMessage.ERREUR, true);
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
            RequeteSuppression reqSupInscription = new RequeteSuppression(NomTable.inscriptiontelesurveillancelifeline, condBeneficiaire);

            if (Global.BaseDonneesCABS.EnvoyerRequeteSuppression(reqSupInscription) < 0)
            {
                Journal.AfficherMessage("Une erreur est survenue lors de la suppression de l'inscription à la télésurveillance Lifeline. L'action a été annulée.", TypeMessage.ERREUR, true);
                return false;
            }

            return true;
        }
    }
}