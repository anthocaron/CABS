using CABS.BaseDonnees;
using CABS.Outils;
using System;

namespace CABS.Formulaires.Inscription
{
    public partial class frmInscriptionTransComm : Formulaire
    {
        private int IndexBeneficiaireCourant;

        public frmInscriptionTransComm()
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

                RequeteSelection reqSel = new RequeteSelection(NomTable.inscriptiontransportcommunautaire);
                reqSel.Condition = new ConditionRequete(Operateur.EGAL, "perId", IndexBeneficiaireCourant.ToString());

                Table inscriptionLifeline = Global.BaseDonneesCABS.EnvoyerRequeteSelection(reqSel);

                if (!inscriptionLifeline.EstVide)
                {
                    LigneTable infosInscription = inscriptionLifeline.Lignes[0];
                    cbVuDDN.Checked = infosInscription.GetValeurChamp<bool>("itcVuDDN");
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

            LigneTable inscriptionLifeline = new LigneTable("InscriptionTransportCommunautaire");
            inscriptionLifeline.AjouterChamp("itcVuDDN", cbVuDDN.Checked);

            if (Mode == ModeFormulaire.AJOUT)
            {
                inscriptionLifeline.AjouterChamp("perId", IndexBeneficiaireCourant);
                RequeteAjout reqAjout = new RequeteAjout(NomTable.inscriptiontransportcommunautaire, inscriptionLifeline);

                if (Global.BaseDonneesCABS.EnvoyerRequeteAjout(reqAjout) < 0)
                {
                    Journal.AfficherMessage("Une erreur est survenue lors de l'inscription au transport communautaire. L'action a été annulée.", TypeMessage.ERREUR, true);
                    return false;
                }
            }
            else if (Mode == ModeFormulaire.EDITION)
            {
                RequeteModification reqModif = new RequeteModification(NomTable.inscriptiontransportcommunautaire, 
                                                                       new ConditionRequete(Operateur.EGAL, "perId", IndexBeneficiaireCourant.ToString()), 
                                                                       inscriptionLifeline);

                if (Global.BaseDonneesCABS.EnvoyerRequeteModification(reqModif) < 0)
                {
                    Journal.AfficherMessage("Une erreur est survenue lors de la modification de l'inscription au transport communautaire. L'action a été annulée.", TypeMessage.ERREUR, true);
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
            RequeteSuppression reqSupInscription = new RequeteSuppression(NomTable.inscriptiontransportcommunautaire, condBeneficiaire);

            if (Global.BaseDonneesCABS.EnvoyerRequeteSuppression(reqSupInscription) < 0)
            {
                Journal.AfficherMessage("Une erreur est survenue lors de la suppression de l'inscription au transport communautaire. L'action a été annulée.", TypeMessage.ERREUR, true);
                return false;
            }

            return true;
        }
    }
}