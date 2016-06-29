using CABS.BaseDonnees;
using CABS.Outils;
using System;

namespace CABS.Formulaires.Inscription
{
    public partial class frmInscriptionViactive : Formulaire
    {
        private int IndexBeneficiaireCourant;

        public frmInscriptionViactive()
            : base(true, false)
        {
            InitializeComponent();
        }

        public override void EnvoyerMessages(params object[] messages)
        {
            if (messages.Length == 1 && messages[0] is int)
            {
                IndexBeneficiaireCourant = (int)messages[0];

                RequeteSelection reqSel = new RequeteSelection(NomTable.inscriptionviactive);
                reqSel.Condition = new ConditionRequete(Operateur.EGAL, "perId", IndexBeneficiaireCourant.ToString());

                Table inscriptionClubMarche = Global.BaseDonneesCABS.EnvoyerRequeteSelection(reqSel);

                if (!inscriptionClubMarche.EstVide)
                {
                    LigneTable infosInscription = inscriptionClubMarche.Lignes[0];

                    rbProblemeCardiaqueOui.Checked = infosInscription.GetValeurChamp<bool>("ivProblemeCardiaque");
                    rbDouleurPoitrineOui.Checked = infosInscription.GetValeurChamp<bool>("ivDouleurPoitrine");
                    rbProblemesOsseuxOui.Checked = infosInscription.GetValeurChamp<bool>("ivProblemesOsseux");

                    rbRestrictionPhysiqueOui.Checked = infosInscription.GetValeurChamp<bool>("ivRestrictionPhysique");
                    txtRestrictionPhysiqueSpecifier.Text = infosInscription.GetValeurChamp<string>("ivDetailsRestrictionPhysique");

                    rbProblemeSanteOui.Checked = infosInscription.GetValeurChamp<bool>("ivProblemeSante");
                    txtProblemeSanteSpecifier.Text = infosInscription.GetValeurChamp<string>("ivDetailsProblemeSante");
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

            rbProblemeCardiaqueNon.Checked = rbDouleurPoitrineNon.Checked = rbProblemesOsseuxNon.Checked = rbRestrictionPhysiqueNon.Checked = rbProblemeSanteNon.Checked = true;
            txtRestrictionPhysiqueSpecifier.Text = txtProblemeSanteSpecifier.Text = "";
        }

        public override void ChangerAccesControle(ModeFormulaire mode)
        {
            base.ChangerAccesControle(mode);

            rbProblemeCardiaqueOui.Enabled = rbDouleurPoitrineOui.Enabled = rbProblemesOsseuxOui.Enabled = rbRestrictionPhysiqueOui.Enabled = rbProblemeSanteOui.Enabled = 
            rbProblemeCardiaqueNon.Enabled = rbDouleurPoitrineNon.Enabled = rbProblemesOsseuxNon.Enabled = rbRestrictionPhysiqueNon.Enabled = rbProblemeSanteNon.Enabled = Mode != ModeFormulaire.CONSULTATION;

            txtRestrictionPhysiqueSpecifier.Enabled = Mode != ModeFormulaire.CONSULTATION && rbRestrictionPhysiqueOui.Checked;
            txtProblemeSanteSpecifier.Enabled = Mode != ModeFormulaire.CONSULTATION && rbProblemeSanteOui.Checked;
        }

        public override bool Enregistrer()
        {
            if (!base.Enregistrer())
                return false;

            LigneTable inscriptionViactive = new LigneTable("InscriptionViactive");

            inscriptionViactive.AjouterChamp("ivProblemeCardiaque", rbProblemeCardiaqueOui.Checked);
            inscriptionViactive.AjouterChamp("ivDouleurPoitrine", rbDouleurPoitrineOui.Checked);
            inscriptionViactive.AjouterChamp("ivProblemesOsseux", rbProblemesOsseuxOui.Checked);

            inscriptionViactive.AjouterChamp("ivRestrictionPhysique", rbRestrictionPhysiqueOui.Checked);
            inscriptionViactive.AjouterChamp("ivDetailsRestrictionPhysique", txtRestrictionPhysiqueSpecifier.Text);

            inscriptionViactive.AjouterChamp("ivProblemeSante", rbProblemeSanteOui.Checked);
            inscriptionViactive.AjouterChamp("ivDetailsProblemeSante", txtProblemeSanteSpecifier.Text);

            if (Mode == ModeFormulaire.AJOUT)
            {
                inscriptionViactive.AjouterChamp("perId", IndexBeneficiaireCourant);
                RequeteAjout reqAjout = new RequeteAjout(NomTable.inscriptionviactive, inscriptionViactive);

                if (Global.BaseDonneesCABS.EnvoyerRequeteAjout(reqAjout) < 0)
                {
                    Journal.AfficherMessage("Une erreur est survenue lors de l'inscription à Viactive. L'action a été annulée.", TypeMessage.ERREUR, true);
                    return false;
                }
            }
            else if (Mode == ModeFormulaire.EDITION)
            {
                RequeteModification reqModif = new RequeteModification(NomTable.inscriptionviactive,
                                                                       new ConditionRequete(Operateur.EGAL, "perId", IndexBeneficiaireCourant.ToString()),
                                                                       inscriptionViactive);

                if (Global.BaseDonneesCABS.EnvoyerRequeteModification(reqModif) < 0)
                {
                    Journal.AfficherMessage("Une erreur est survenue lors de la modification de l'inscription à Viactive. L'action a été annulée.", TypeMessage.ERREUR, true);
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
            RequeteSuppression reqSupInscription = new RequeteSuppression(NomTable.inscriptionviactive, condBeneficiaire);

            if (Global.BaseDonneesCABS.EnvoyerRequeteSuppression(reqSupInscription) < 0)
            {
                Journal.AfficherMessage("Une erreur est survenue lors de la suppression de l'inscription à Viactive. L'action a été annulée.", TypeMessage.ERREUR, true);
                return false;
            }

            return true;
        }

        private void rbRestrictionPhysiqueOui_CheckedChanged(object sender, EventArgs e)
        {
            if (!rbRestrictionPhysiqueOui.Checked)
                txtRestrictionPhysiqueSpecifier.Text = "";
            else
                txtRestrictionPhysiqueSpecifier.Enabled = Mode != ModeFormulaire.CONSULTATION;
        }

        private void rbProblemeSanteOui_CheckedChanged(object sender, EventArgs e)
        {
            if (!rbProblemeSanteOui.Checked)
                txtProblemeSanteSpecifier.Text = "";
            else
                txtProblemeSanteSpecifier.Enabled = Mode != ModeFormulaire.CONSULTATION;
        }
    }
}
