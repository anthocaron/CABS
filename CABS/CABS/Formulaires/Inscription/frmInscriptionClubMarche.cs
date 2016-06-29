using CABS.BaseDonnees;
using CABS.Outils;
using System;

namespace CABS.Formulaires.Inscription
{
    public partial class frmInscriptionClubMarche : Formulaire
    {
        private int IndexBeneficiaireCourant;

        public frmInscriptionClubMarche()
            : base(true, false)
        {
            InitializeComponent();
        }

        public override void EnvoyerMessages(params object[] messages)
        {
            if (messages.Length == 1 && messages[0] is int)
            {
                IndexBeneficiaireCourant = (int)messages[0];

                RequeteSelection reqSel = new RequeteSelection(NomTable.inscriptionclubmarche);
                reqSel.Condition = new ConditionRequete(Operateur.EGAL, "perId", IndexBeneficiaireCourant.ToString());

                Table inscriptionClubMarche = Global.BaseDonneesCABS.EnvoyerRequeteSelection(reqSel);

                if (!inscriptionClubMarche.EstVide)
                {
                    LigneTable infosInscription = inscriptionClubMarche.Lignes[0];

                    rbProblemeCardiaqueOui.Checked = infosInscription.GetValeurChamp<bool>("icmProblemeCardiaque");
                    rbDouleurPoitrineOui.Checked = infosInscription.GetValeurChamp<bool>("icmDouleurPoitrine");
                    rbProblemesOsseuxOui.Checked = infosInscription.GetValeurChamp<bool>("icmProblemesOsseux");

                    rbRestrictionPhysiqueOui.Checked = infosInscription.GetValeurChamp<bool>("icmRestrictionPhysique");
                    txtRestrictionPhysiqueSpecifier.Text = infosInscription.GetValeurChamp<string>("icmDetailsRestrictionPhysique");

                    rbProblemeSanteOui.Checked = infosInscription.GetValeurChamp<bool>("icmProblemeSante");
                    txtProblemeSanteSpecifier.Text = infosInscription.GetValeurChamp<string>("icmDetailsProblemeSante");
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

            LigneTable inscriptionClubMarche = new LigneTable("InscriptionClubMarche");

            inscriptionClubMarche.AjouterChamp("icmProblemeCardiaque", rbProblemeCardiaqueOui.Checked);
            inscriptionClubMarche.AjouterChamp("icmDouleurPoitrine", rbDouleurPoitrineOui.Checked);
            inscriptionClubMarche.AjouterChamp("icmProblemesOsseux", rbProblemesOsseuxOui.Checked);

            inscriptionClubMarche.AjouterChamp("icmRestrictionPhysique", rbRestrictionPhysiqueOui.Checked);
            inscriptionClubMarche.AjouterChamp("icmDetailsRestrictionPhysique", txtRestrictionPhysiqueSpecifier.Text);

            inscriptionClubMarche.AjouterChamp("icmProblemeSante", rbProblemeSanteOui.Checked);
            inscriptionClubMarche.AjouterChamp("icmDetailsProblemeSante", txtProblemeSanteSpecifier.Text);

            if (Mode == ModeFormulaire.AJOUT)
            {
                inscriptionClubMarche.AjouterChamp("perId", IndexBeneficiaireCourant);
                RequeteAjout reqAjout = new RequeteAjout(NomTable.inscriptionclubmarche, inscriptionClubMarche);

                if (Global.BaseDonneesCABS.EnvoyerRequeteAjout(reqAjout) < 0)
                {
                    Journal.AfficherMessage("Une erreur est survenue lors de l'inscription au club de marche. L'action a été annulée.", TypeMessage.ERREUR, true);
                    return false;
                }
            }
            else if (Mode == ModeFormulaire.EDITION)
            {
                RequeteModification reqModif = new RequeteModification(NomTable.inscriptionclubmarche,
                                                                       new ConditionRequete(Operateur.EGAL, "perId", IndexBeneficiaireCourant.ToString()),
                                                                       inscriptionClubMarche);

                if (Global.BaseDonneesCABS.EnvoyerRequeteModification(reqModif) < 0)
                {
                    Journal.AfficherMessage("Une erreur est survenue lors de la modification de l'inscription au club de marche. L'action a été annulée.", TypeMessage.ERREUR, true);
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
            RequeteSuppression reqSupInscription = new RequeteSuppression(NomTable.inscriptionclubmarche, condBeneficiaire);

            if (Global.BaseDonneesCABS.EnvoyerRequeteSuppression(reqSupInscription) < 0)
            {
                Journal.AfficherMessage("Une erreur est survenue lors de la suppression de l'inscription au club de marche. L'action a été annulée.", TypeMessage.ERREUR, true);
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
