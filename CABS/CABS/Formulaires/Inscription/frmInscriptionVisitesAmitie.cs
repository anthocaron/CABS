using CABS.BaseDonnees;
using CABS.Outils;

namespace CABS.Formulaires.Inscription
{
    public partial class frmInscriptionVisitesAmitie : Formulaire
    {
        private int IndexBeneficiaireCourant;

        public frmInscriptionVisitesAmitie()
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

                RequeteSelection reqSel = new RequeteSelection(NomTable.inscriptionvisitesamitie);
                reqSel.Condition = new ConditionRequete(Operateur.EGAL, "perId", IndexBeneficiaireCourant.ToString());

                Table inscriptionLifeline = Global.BaseDonneesCABS.EnvoyerRequeteSelection(reqSel);

                if (!inscriptionLifeline.EstVide)
                {
                    LigneTable infosInscription = inscriptionLifeline.Lignes[0];

                    txtMobiliteReduite.Text = infosInscription.GetValeurChamp<string>("ivaMobiliteReduite");
                    txtCapaciteAuditive.Text = infosInscription.GetValeurChamp<string>("ivaCapaciteAuditive");
                    txtCapaciteVisuelle.Text = infosInscription.GetValeurChamp<string>("ivaCapaciteVisuelle");
                    txtMemoire.Text = infosInscription.GetValeurChamp<string>("ivaMemoire");
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

            txtMobiliteReduite.Text = txtCapaciteAuditive.Text = txtCapaciteVisuelle.Text = txtMemoire.Text = "";
        }

        public override void ChangerAccesControle(ModeFormulaire mode)
        {
            base.ChangerAccesControle(mode);

            txtMobiliteReduite.Enabled = txtCapaciteAuditive.Enabled = txtCapaciteVisuelle.Enabled = txtMemoire.Enabled = Mode != ModeFormulaire.CONSULTATION;
        }

        public override bool Enregistrer()
        {
            if (!base.Enregistrer())
                return false;

            LigneTable inscriptionVisitesAmitie = new LigneTable("InscriptionVisitesAmitie");

            inscriptionVisitesAmitie.AjouterChamp("ivaMobiliteReduite", txtMobiliteReduite.Text);
            inscriptionVisitesAmitie.AjouterChamp("ivaCapaciteAuditive", txtCapaciteAuditive.Text);
            inscriptionVisitesAmitie.AjouterChamp("ivaCapaciteVisuelle", txtCapaciteVisuelle.Text);
            inscriptionVisitesAmitie.AjouterChamp("ivaMemoire", txtMemoire.Text);

            if (Mode == ModeFormulaire.AJOUT)
            {
                inscriptionVisitesAmitie.AjouterChamp("perId", IndexBeneficiaireCourant);
                RequeteAjout reqAjout = new RequeteAjout(NomTable.inscriptionvisitesamitie, inscriptionVisitesAmitie);

                if (Global.BaseDonneesCABS.EnvoyerRequeteAjout(reqAjout) < 0)
                {
                    Journal.AfficherMessage("Une erreur est survenue lors de l'inscription aux visites d'amitié. L'action a été annulée.", TypeMessage.ERREUR, true);
                    return false;
                }
            }
            else if (Mode == ModeFormulaire.EDITION)
            {
                RequeteModification reqModif = new RequeteModification(NomTable.inscriptionvisitesamitie,
                                                                       new ConditionRequete(Operateur.EGAL, "perId", IndexBeneficiaireCourant.ToString()),
                                                                       inscriptionVisitesAmitie);

                if (Global.BaseDonneesCABS.EnvoyerRequeteModification(reqModif) < 0)
                {
                    Journal.AfficherMessage("Une erreur est survenue lors de la modification de l'inscription aux visites d'amitié. L'action a été annulée.", TypeMessage.ERREUR, true);
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
            RequeteSuppression reqSupInscription = new RequeteSuppression(NomTable.inscriptionvisitesamitie, condBeneficiaire);

            if (Global.BaseDonneesCABS.EnvoyerRequeteSuppression(reqSupInscription) < 0)
            {
                Journal.AfficherMessage("Une erreur est survenue lors de la suppression de l'inscription aux visites d'amitié. L'action a été annulée.", TypeMessage.ERREUR, true);
                return false;
            }

            return true;
        }
    }
}
