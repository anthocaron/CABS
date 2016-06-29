using CABS.BaseDonnees;
using CABS.Outils;
using System.Windows.Forms;

namespace CABS.Formulaires.Inscription
{
    public partial class frmInscriptionPopote : Formulaire
    {
        private int IndexBeneficiaireCourant;

        public frmInscriptionPopote()
            : base(true, false)
        {
            InitializeComponent();
            IndexBeneficiaireCourant = 0;
        }

        private void nudSolde_Click(object sender, System.EventArgs e)
        {
            nudSolde.Select(0, nudSolde.Text.Length);
        }

        private void nudSolde_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('.') || e.KeyChar.Equals(','))
                e.KeyChar = ((System.Globalization.CultureInfo)System.Globalization.CultureInfo.CurrentCulture).NumberFormat.NumberDecimalSeparator.ToCharArray()[0];
        }

        public override void EnvoyerMessages(params object[] messages)
        {
            if (messages.Length == 1 && messages[0] is int)
            {
                IndexBeneficiaireCourant = (int)messages[0];

                RequeteSelection reqSel = new RequeteSelection(NomTable.inscriptionpopoteroulante);
                reqSel.Condition = new ConditionRequete(Operateur.EGAL, "perId", IndexBeneficiaireCourant.ToString());

                Table inscriptionPopote = Global.BaseDonneesCABS.EnvoyerRequeteSelection(reqSel);

                if (!inscriptionPopote.EstVide)
                {
                    LigneTable infosInscription = inscriptionPopote.Lignes[0];

                    nudSolde.Value = infosInscription.GetValeurChamp<decimal>("iprSolde");
                    cbDiabetique.Checked = infosInscription.GetValeurChamp<bool>("iprDiabetique");
                    cbConjointDiabetique.Checked = infosInscription.GetValeurChamp<bool>("iprConjointDiabetique");
                    txtAllergies.Text = infosInscription.GetValeurChamp<string>("iprListeAllergies");
                    txtAllergiesConjoint.Text = infosInscription.GetValeurChamp<string>("iprListeAllergiesConjoint");
                    txtIndicationsLivraison.Text = infosInscription.GetValeurChamp<string>("iprIndicationsLivraison");
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

            nudSolde.Value = 0;
            cbDiabetique.Checked = cbConjointDiabetique.Checked = false;
            txtAllergies.Text = txtAllergiesConjoint.Text = txtIndicationsLivraison.Text = "";
        }

        public override void ChangerAccesControle(ModeFormulaire mode)
        {
            base.ChangerAccesControle(mode);

            nudSolde.Enabled = cbDiabetique.Enabled = cbConjointDiabetique.Enabled = txtAllergies.Enabled = 
            txtAllergiesConjoint.Enabled = txtIndicationsLivraison.Enabled = Mode != ModeFormulaire.CONSULTATION;
        }

        public override bool Enregistrer()
        {
            if(!base.Enregistrer())
                return false;
            
            LigneTable inscriptionPopote = new LigneTable("InscriptionPopoteRoulante");
            inscriptionPopote.AjouterChamp("iprSolde", nudSolde.Value);
            inscriptionPopote.AjouterChamp("iprDiabetique", cbDiabetique.Checked);
            inscriptionPopote.AjouterChamp("iprConjointDiabetique", cbConjointDiabetique.Checked);
            inscriptionPopote.AjouterChamp("iprListeAllergies", txtAllergies.Text);
            inscriptionPopote.AjouterChamp("iprListeAllergiesConjoint", txtAllergiesConjoint.Text);
            inscriptionPopote.AjouterChamp("iprIndicationsLivraison", txtIndicationsLivraison.Text);

            if (Mode == ModeFormulaire.AJOUT)
            {
                inscriptionPopote.AjouterChamp("perId", IndexBeneficiaireCourant);
                RequeteAjout reqAjout = new RequeteAjout(NomTable.inscriptionpopoteroulante, inscriptionPopote);

                if (Global.BaseDonneesCABS.EnvoyerRequeteAjout(reqAjout) < 0)
                {
                    Journal.AfficherMessage("Une erreur est survenue lors de l'inscription à la Popote roulante. L'action a été annulée.", TypeMessage.ERREUR, true);
                    return false;
                }
            }
            else if (Mode == ModeFormulaire.EDITION)
            {
                RequeteModification reqModif = new RequeteModification(NomTable.inscriptionpopoteroulante, 
                                                                       new ConditionRequete(Operateur.EGAL, "perId", IndexBeneficiaireCourant.ToString()), 
                                                                       inscriptionPopote);

                if (Global.BaseDonneesCABS.EnvoyerRequeteModification(reqModif) < 0)
                {
                    Journal.AfficherMessage("Une erreur est survenue lors de la modification de l'inscription à la Popote roulante. L'action a été annulée.", TypeMessage.ERREUR, true);
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
            RequeteSuppression reqSupInscription = new RequeteSuppression(NomTable.inscriptionpopoteroulante, condBeneficiaire);

            if (Global.BaseDonneesCABS.EnvoyerRequeteSuppression(reqSupInscription) < 0)
            {
                Journal.AfficherMessage("Une erreur est survenue lors de la suppression de l'inscription à la Popote roulante. L'action a été annulée.", TypeMessage.ERREUR, true);
                return false;
            }

            return true;
        }
    }
}