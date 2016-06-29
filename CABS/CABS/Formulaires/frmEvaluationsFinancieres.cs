using CABS.BaseDonnees;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CABS.Outils;

namespace CABS.Formulaires
{
    public partial class frmEvaluationsFinancieres : Formulaire
    {
        private static string RequeteBeneficiaire = "SELECT p.perId, p.perNom, p.perPrenom, ida.idaId FROM personne p INNER JOIN inscriptionservice i ON p.perId = i.perId INNER JOIN inscriptiondepannagealimentaire ida ON p.perId = ida.perId WHERE p.staId = {0} AND i.insSuspendu = 0 AND i.serId = {1} ORDER BY p.perNom, p.perPrenom, p.perDateNaissance;";

        private Dictionary<string, decimal> Revenus;
        private Dictionary<string, decimal> Depenses;

        private decimal TotalRevenus;
        private decimal TotalDepenses;

        private LigneTable BeneficiaireCourant;
        private Table Evaluations;

        private int IdService;
        private int IdStatut;

        public frmEvaluationsFinancieres()
            : base(true, true)
        {
            InitializeComponent();

            Revenus = new Dictionary<string, decimal>();
            Depenses = new Dictionary<string, decimal>();

            TotalRevenus = 0.0m;
            TotalDepenses = 0.0m;

            BeneficiaireCourant = null;
            Evaluations = null;

            IdService = IdStatut = -1;
        }

        private void frmEvaluationsFinancieres_Load(object sender, EventArgs e)
        {
            CreerHandlers();

            lblTotalRevenusValeur.Text = TotalRevenus.ToString("C");
            lblTotalDepensesValeur.Text = TotalDepenses.ToString("C");
            MettreAJourMontantPersonneSemaine();

            RequeteSelection reqSel = new RequeteSelection(NomTable.service, "serId");
            reqSel.Condition = new ConditionRequete(Operateur.COMME, "serNom", "'Dépannage alimentaire La Manne'");

            Table service = Global.BaseDonneesCABS.EnvoyerRequeteSelection(reqSel);

            if (!service.EstVide)
                IdService = service.Lignes[0].GetValeurChamp<int>("serId");

            reqSel = new RequeteSelection(NomTable.statut, "staId");
            reqSel.Condition = new ConditionRequete(Operateur.COMME, "staNom", "'Actif'");

            Table statut = Global.BaseDonneesCABS.EnvoyerRequeteSelection(reqSel);

            if (!statut.EstVide)
                IdStatut = statut.Lignes[0].GetValeurChamp<int>("staId");
        }

        private void CreerHandlers()
        {
            nudAideSociale.Click += new EventHandler(numericUpDown_Click);
            nudAssuranceAuto.Click += new EventHandler(numericUpDown_Click);
            nudAssuranceLogement.Click += new EventHandler(numericUpDown_Click);
            nudAssuranceVie.Click += new EventHandler(numericUpDown_Click);
            nudAutresDepenses1.Click += new EventHandler(numericUpDown_Click);
            nudAutresDepenses2.Click += new EventHandler(numericUpDown_Click);
            nudAutresDepenses3.Click += new EventHandler(numericUpDown_Click);
            nudAutresRevenus1.Click += new EventHandler(numericUpDown_Click);
            nudAutresRevenus2.Click += new EventHandler(numericUpDown_Click);
            nudAutresRevenus3.Click += new EventHandler(numericUpDown_Click);
            nudCableInternetTelephone.Click += new EventHandler(numericUpDown_Click);
            nudCellulaire.Click += new EventHandler(numericUpDown_Click);
            nudChauffage.Click += new EventHandler(numericUpDown_Click);
            nudChomage.Click += new EventHandler(numericUpDown_Click);
            nudDepensesCourantes.Click += new EventHandler(numericUpDown_Click);
            nudEssenceEntretien.Click += new EventHandler(numericUpDown_Click);
            nudHydroQuebec.Click += new EventHandler(numericUpDown_Click);
            nudImmatriculationPermis.Click += new EventHandler(numericUpDown_Click);
            nudImpotSolidarite.Click += new EventHandler(numericUpDown_Click);
            nudLoyerHypotheque.Click += new EventHandler(numericUpDown_Click);
            nudNbPersonnes.Click += new EventHandler(numericUpDown_Click);
            nudPensionAlimentaireDepenses.Click += new EventHandler(numericUpDown_Click);
            nudPensionAlimentaireRevenus.Click += new EventHandler(numericUpDown_Click);
            nudPensionVieillesse.Click += new EventHandler(numericUpDown_Click);
            nudPresFamFed.Click += new EventHandler(numericUpDown_Click);
            nudPresFamProv.Click += new EventHandler(numericUpDown_Click);
            nudRemboursementAuto.Click += new EventHandler(numericUpDown_Click);
            nudRRQ.Click += new EventHandler(numericUpDown_Click);
            nudTalonPaie.Click += new EventHandler(numericUpDown_Click);
            nudTaxesScolairesNum.Click += new EventHandler(numericUpDown_Click);
            nudTPS.Click += new EventHandler(numericUpDown_Click);

            nudAideSociale.KeyPress += new KeyPressEventHandler(numericUpDown_KeyPress);
            nudAssuranceAuto.KeyPress += new KeyPressEventHandler(numericUpDown_KeyPress);
            nudAssuranceLogement.KeyPress += new KeyPressEventHandler(numericUpDown_KeyPress);
            nudAssuranceVie.KeyPress += new KeyPressEventHandler(numericUpDown_KeyPress);
            nudAutresDepenses1.KeyPress += new KeyPressEventHandler(numericUpDown_KeyPress);
            nudAutresDepenses2.KeyPress += new KeyPressEventHandler(numericUpDown_KeyPress);
            nudAutresDepenses3.KeyPress += new KeyPressEventHandler(numericUpDown_KeyPress);
            nudAutresRevenus1.KeyPress += new KeyPressEventHandler(numericUpDown_KeyPress);
            nudAutresRevenus2.KeyPress += new KeyPressEventHandler(numericUpDown_KeyPress);
            nudAutresRevenus3.KeyPress += new KeyPressEventHandler(numericUpDown_KeyPress);
            nudCableInternetTelephone.KeyPress += new KeyPressEventHandler(numericUpDown_KeyPress);
            nudCellulaire.KeyPress += new KeyPressEventHandler(numericUpDown_KeyPress);
            nudChauffage.KeyPress += new KeyPressEventHandler(numericUpDown_KeyPress);
            nudChomage.KeyPress += new KeyPressEventHandler(numericUpDown_KeyPress);
            nudDepensesCourantes.KeyPress += new KeyPressEventHandler(numericUpDown_KeyPress);
            nudEssenceEntretien.KeyPress += new KeyPressEventHandler(numericUpDown_KeyPress);
            nudHydroQuebec.KeyPress += new KeyPressEventHandler(numericUpDown_KeyPress);
            nudImmatriculationPermis.KeyPress += new KeyPressEventHandler(numericUpDown_KeyPress);
            nudImpotSolidarite.KeyPress += new KeyPressEventHandler(numericUpDown_KeyPress);
            nudLoyerHypotheque.KeyPress += new KeyPressEventHandler(numericUpDown_KeyPress);
            nudPensionAlimentaireDepenses.KeyPress += new KeyPressEventHandler(numericUpDown_KeyPress);
            nudPensionAlimentaireRevenus.KeyPress += new KeyPressEventHandler(numericUpDown_KeyPress);
            nudPensionVieillesse.KeyPress += new KeyPressEventHandler(numericUpDown_KeyPress);
            nudPresFamFed.KeyPress += new KeyPressEventHandler(numericUpDown_KeyPress);
            nudPresFamProv.KeyPress += new KeyPressEventHandler(numericUpDown_KeyPress);
            nudRemboursementAuto.KeyPress += new KeyPressEventHandler(numericUpDown_KeyPress);
            nudRRQ.KeyPress += new KeyPressEventHandler(numericUpDown_KeyPress);
            nudTalonPaie.KeyPress += new KeyPressEventHandler(numericUpDown_KeyPress);
            nudTaxesScolairesNum.KeyPress += new KeyPressEventHandler(numericUpDown_KeyPress);
            nudTPS.KeyPress += new KeyPressEventHandler(numericUpDown_KeyPress);

            cmbEvaluationsPrecedentes.MouseWheel += new MouseEventHandler(numericUpDown_MouseWheel);
            nudAideSociale.MouseWheel += new MouseEventHandler(numericUpDown_MouseWheel);
            nudAssuranceAuto.MouseWheel += new MouseEventHandler(numericUpDown_MouseWheel);
            nudAssuranceLogement.MouseWheel += new MouseEventHandler(numericUpDown_MouseWheel);
            nudAssuranceVie.MouseWheel += new MouseEventHandler(numericUpDown_MouseWheel);
            nudAutresDepenses1.MouseWheel += new MouseEventHandler(numericUpDown_MouseWheel);
            nudAutresDepenses2.MouseWheel += new MouseEventHandler(numericUpDown_MouseWheel);
            nudAutresDepenses3.MouseWheel += new MouseEventHandler(numericUpDown_MouseWheel);
            nudAutresRevenus1.MouseWheel += new MouseEventHandler(numericUpDown_MouseWheel);
            nudAutresRevenus2.MouseWheel += new MouseEventHandler(numericUpDown_MouseWheel);
            nudAutresRevenus3.MouseWheel += new MouseEventHandler(numericUpDown_MouseWheel);
            nudCableInternetTelephone.MouseWheel += new MouseEventHandler(numericUpDown_MouseWheel);
            nudCellulaire.MouseWheel += new MouseEventHandler(numericUpDown_MouseWheel);
            nudChauffage.MouseWheel += new MouseEventHandler(numericUpDown_MouseWheel);
            nudChomage.MouseWheel += new MouseEventHandler(numericUpDown_MouseWheel);
            nudDepensesCourantes.MouseWheel += new MouseEventHandler(numericUpDown_MouseWheel);
            nudEssenceEntretien.MouseWheel += new MouseEventHandler(numericUpDown_MouseWheel);
            nudHydroQuebec.MouseWheel += new MouseEventHandler(numericUpDown_MouseWheel);
            nudImmatriculationPermis.MouseWheel += new MouseEventHandler(numericUpDown_MouseWheel);
            nudImpotSolidarite.MouseWheel += new MouseEventHandler(numericUpDown_MouseWheel);
            nudLoyerHypotheque.MouseWheel += new MouseEventHandler(numericUpDown_MouseWheel);
            nudNbPersonnes.MouseWheel += new MouseEventHandler(numericUpDown_MouseWheel);
            nudPensionAlimentaireDepenses.MouseWheel += new MouseEventHandler(numericUpDown_MouseWheel);
            nudPensionAlimentaireRevenus.MouseWheel += new MouseEventHandler(numericUpDown_MouseWheel);
            nudPensionVieillesse.MouseWheel += new MouseEventHandler(numericUpDown_MouseWheel);
            nudPresFamFed.MouseWheel += new MouseEventHandler(numericUpDown_MouseWheel);
            nudPresFamProv.MouseWheel += new MouseEventHandler(numericUpDown_MouseWheel);
            nudRemboursementAuto.MouseWheel += new MouseEventHandler(numericUpDown_MouseWheel);
            nudRRQ.MouseWheel += new MouseEventHandler(numericUpDown_MouseWheel);
            nudTalonPaie.MouseWheel += new MouseEventHandler(numericUpDown_MouseWheel);
            nudTaxesScolairesNum.MouseWheel += new MouseEventHandler(numericUpDown_MouseWheel);
            nudTPS.MouseWheel += new MouseEventHandler(numericUpDown_MouseWheel);

            nudAideSociale.ValueChanged += new EventHandler(revenus_ValueChanged);
            nudAutresRevenus1.ValueChanged += new EventHandler(revenus_ValueChanged);
            nudAutresRevenus2.ValueChanged += new EventHandler(revenus_ValueChanged);
            nudAutresRevenus3.ValueChanged += new EventHandler(revenus_ValueChanged);
            nudChomage.ValueChanged += new EventHandler(revenus_ValueChanged);
            nudImpotSolidarite.ValueChanged += new EventHandler(revenus_ValueChanged);
            nudPensionAlimentaireRevenus.ValueChanged += new EventHandler(revenus_ValueChanged);
            nudPensionVieillesse.ValueChanged += new EventHandler(revenus_ValueChanged);
            nudPresFamFed.ValueChanged += new EventHandler(revenus_ValueChanged);
            nudPresFamProv.ValueChanged += new EventHandler(revenus_ValueChanged);
            nudRRQ.ValueChanged += new EventHandler(revenus_ValueChanged);
            nudTalonPaie.ValueChanged += new EventHandler(revenus_ValueChanged);
            nudTPS.ValueChanged += new EventHandler(revenus_ValueChanged);

            nudAssuranceAuto.ValueChanged += new EventHandler(depenses_ValueChanged);
            nudAssuranceLogement.ValueChanged += new EventHandler(depenses_ValueChanged);
            nudAssuranceVie.ValueChanged += new EventHandler(depenses_ValueChanged);
            nudAutresDepenses1.ValueChanged += new EventHandler(depenses_ValueChanged);
            nudAutresDepenses2.ValueChanged += new EventHandler(depenses_ValueChanged);
            nudAutresDepenses3.ValueChanged += new EventHandler(depenses_ValueChanged);
            nudCableInternetTelephone.ValueChanged += new EventHandler(depenses_ValueChanged);
            nudCellulaire.ValueChanged += new EventHandler(depenses_ValueChanged);
            nudChauffage.ValueChanged += new EventHandler(depenses_ValueChanged);
            nudDepensesCourantes.ValueChanged += new EventHandler(depenses_ValueChanged);
            nudEssenceEntretien.ValueChanged += new EventHandler(depenses_ValueChanged);
            nudHydroQuebec.ValueChanged += new EventHandler(depenses_ValueChanged);
            nudImmatriculationPermis.ValueChanged += new EventHandler(depenses_ValueChanged);
            nudLoyerHypotheque.ValueChanged += new EventHandler(depenses_ValueChanged);
            nudPensionAlimentaireDepenses.ValueChanged += new EventHandler(depenses_ValueChanged);
            nudRemboursementAuto.ValueChanged += new EventHandler(depenses_ValueChanged);
            nudTaxesScolairesNum.ValueChanged += new EventHandler(depenses_ValueChanged);
        }

        private void numericUpDown_Click(object sender, EventArgs e)
        {
            if (!(sender is NumericUpDown))
                return;

            NumericUpDown nud = (NumericUpDown)sender;
            nud.Select(0, nud.Text.Length);
        }

        private void numericUpDown_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('.') || e.KeyChar.Equals(','))
                e.KeyChar = ((System.Globalization.CultureInfo)System.Globalization.CultureInfo.CurrentCulture).NumberFormat.NumberDecimalSeparator.ToCharArray()[0];
        }

        private void numericUpDown_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        private void nudNbPersonnes_ValueChanged(object sender, EventArgs e)
        {
            MettreAJourMontantPersonneSemaine();
        }

        private void revenus_ValueChanged(object sender, EventArgs e)
        {
            if(!(sender is NumericUpDown))
                return;

            NumericUpDown nud = (NumericUpDown)sender;
            decimal temp;

            if (Revenus.TryGetValue(nud.Name, out temp))
            {
                TotalRevenus += nud.Value - temp;
                Revenus[nud.Name] = nud.Value;
            }
            else
            {
                TotalRevenus += nud.Value;
                Revenus.Add(nud.Name, nud.Value);
            }

            lblTotalRevenusValeur.Text = TotalRevenus.ToString("C");
            MettreAJourMontantPersonneSemaine();
        }

        private void depenses_ValueChanged(object sender, EventArgs e)
        {
            if (!(sender is NumericUpDown))
                return;

            NumericUpDown nud = (NumericUpDown)sender;
            decimal temp;

            if (Depenses.TryGetValue(nud.Name, out temp))
            {
                TotalDepenses += nud.Value - temp;
                Depenses[nud.Name] = nud.Value;
            }
            else
            {
                TotalDepenses += nud.Value;
                Depenses.Add(nud.Name, nud.Value);
            }

            lblTotalDepensesValeur.Text = TotalDepenses.ToString("C");
            MettreAJourMontantPersonneSemaine();
        }

        private void MettreAJourMontantPersonneSemaine()
        {
            decimal montant = 0.0m;

            if (nudNbPersonnes.Value != 0)
            {
                montant = (TotalRevenus - TotalDepenses) / (4 * nudNbPersonnes.Value);
            }

            lblMontantPersonneSemaineValeur.Text = montant.ToString("C");
        }

        public override void EntrerPage()
        {
            base.EntrerPage();
            RafraichirEvaluations();
        }

        public override void EnvoyerMessages(params object[] messages)
        {
            if (messages.Length == 1 && messages[0] is LigneTable)
            {
                BeneficiaireCourant = (LigneTable)messages[0];
                RafraichirEvaluations();
            }
        }

        private void btnChoisirBeneficiaire_Click(object sender, EventArgs e)
        {
            if (IdService < 0)
            {
                Journal.AfficherMessage("La table des services est inexistante ou corrompue. L'action a été annulée.", TypeMessage.ERREUR, true);
                return;
            }

            if (IdStatut < 0)
            {
                Journal.AfficherMessage("La table des statuts est inexistante ou corrompue. L'action a été annulée.", TypeMessage.ERREUR, true);
                return;
            }

            Table beneficiaires = Global.BaseDonneesCABS.EnvoyerRequeteSelectionDirect("Beneficiaire", String.Format(RequeteBeneficiaire, IdStatut, IdService));
            frmSelectionTable choixBeneficiaire = new frmSelectionTable("Choisir un bénéficiaire...", beneficiaires, new List<string> { "perNom", "perPrenom", "perDateNaissance" }, "perId");

            if (choixBeneficiaire.AfficherDialogue(this))
            {
                BeneficiaireCourant = choixBeneficiaire.LigneChoisie;

                lblNomValeur.Text = BeneficiaireCourant.GetValeurChamp<string>("perNom");
                lblPrenomValeur.Text = BeneficiaireCourant.GetValeurChamp<string>("perPrenom");

                RafraichirEvaluations();
            }
        }

        private void cmbEvaluationsPrecedentes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEvaluationsPrecedentes.SelectedIndex < 0)
                return;

            LigneTable evaluation = ((LigneTable)((ComboBoxItem)cmbEvaluationsPrecedentes.SelectedItem).Value);

            nudNbPersonnes.Value = evaluation.GetValeurChamp<int>("edaNbPersonnes");

            nudAideSociale.Value = evaluation.GetValeurChamp<decimal>("edaAideSociale");
            nudAssuranceAuto.Value = evaluation.GetValeurChamp<decimal>("edaAssuranceAuto");
            nudAssuranceLogement.Value = evaluation.GetValeurChamp<decimal>("edaAssuranceLogement");
            nudAssuranceVie.Value = evaluation.GetValeurChamp<decimal>("edaAssuranceVie");
            nudAutresDepenses1.Value = evaluation.GetValeurChamp<decimal>("edaAutresDepenses1");
            nudAutresDepenses2.Value = evaluation.GetValeurChamp<decimal>("edaAutresDepenses2");
            nudAutresDepenses3.Value = evaluation.GetValeurChamp<decimal>("edaAutresDepenses3");
            nudAutresRevenus1.Value = evaluation.GetValeurChamp<decimal>("edaAutresRevenus1");
            nudAutresRevenus2.Value = evaluation.GetValeurChamp<decimal>("edaAutresRevenus2");
            nudAutresRevenus3.Value = evaluation.GetValeurChamp<decimal>("edaAutresRevenus3");
            nudCableInternetTelephone.Value = evaluation.GetValeurChamp<decimal>("edaCableInternetTelephone");
            nudCellulaire.Value = evaluation.GetValeurChamp<decimal>("edaCellulaire");
            nudChauffage.Value = evaluation.GetValeurChamp<decimal>("edaChauffage");
            nudChomage.Value = evaluation.GetValeurChamp<decimal>("edaChomage");
            nudDepensesCourantes.Value = evaluation.GetValeurChamp<decimal>("edaDepensesCourantes");
            nudEssenceEntretien.Value = evaluation.GetValeurChamp<decimal>("edaEssenceEntretien");
            nudHydroQuebec.Value = evaluation.GetValeurChamp<decimal>("edaHydroQuebec");
            nudImmatriculationPermis.Value = evaluation.GetValeurChamp<decimal>("edaImmatriculationPermis");
            nudImpotSolidarite.Value = evaluation.GetValeurChamp<decimal>("edaImpotSolidarite");
            nudLoyerHypotheque.Value = evaluation.GetValeurChamp<decimal>("edaLoyerHypotheque");
            nudPensionAlimentaireDepenses.Value = evaluation.GetValeurChamp<decimal>("edaPensionAlimentaireDepense");
            nudPensionAlimentaireRevenus.Value = evaluation.GetValeurChamp<decimal>("edaPensionAlimentaireRevenu");
            nudPensionVieillesse.Value = evaluation.GetValeurChamp<decimal>("edaPensionVieillesse");
            nudPresFamFed.Value = evaluation.GetValeurChamp<decimal>("edaPrestationsFamFed");
            nudPresFamProv.Value = evaluation.GetValeurChamp<decimal>("edaPrestationsFamProv");
            nudRemboursementAuto.Value = evaluation.GetValeurChamp<decimal>("edaRemboursementAuto");
            nudRRQ.Value = evaluation.GetValeurChamp<decimal>("edaRRQ");
            nudTalonPaie.Value = evaluation.GetValeurChamp<decimal>("edaTalonPaie");
            nudTaxesScolairesNum.Value = evaluation.GetValeurChamp<decimal>("edaTaxesScolairesMun");
            nudTPS.Value = evaluation.GetValeurChamp<decimal>("edaTPS");

            txtAutresDepenses1.Text = evaluation.GetValeurChamp<string>("edaNomAutreDepenses1");
            txtAutresDepenses2.Text = evaluation.GetValeurChamp<string>("edaNomAutresDepenses2");
            txtAutresDepenses3.Text = evaluation.GetValeurChamp<string>("edaNomAutresDepenses3");
            txtAutresRevenus1.Text = evaluation.GetValeurChamp<string>("edaNomAutresRevenus1");
            txtAutresRevenus2.Text = evaluation.GetValeurChamp<string>("edaNomAutresRevenus2");
            txtAutresRevenus3.Text = evaluation.GetValeurChamp<string>("edaNomAutresRevenus3");
            txtCommentaires.Text = evaluation.GetValeurChamp<string>("edaCommentaires");

            dtpDateNaissance.Value = evaluation.GetValeurChamp<DateTime>("edaDate");
            rbRefuse.Checked = !(rbAccepte.Checked = evaluation.GetValeurChamp<bool>("edaAccepte"));
        }

        private void btnNouveau_Click(object sender, EventArgs e)
        {
            ChangerAccesControle(ModeFormulaire.AJOUT);
            Vider();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            ChangerAccesControle(ModeFormulaire.EDITION);
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (Supprimer())
                RafraichirEvaluations();
        }

        public override bool Supprimer()
        {
            if (!base.Supprimer())
                return false;

            if (!OutilsForms.PoserQuestion("Confirmation suppression", "Confirmez-vous vouloir supprimer cette évaluation de la base de données?"))
                return false;

            int idEval = ((LigneTable)((ComboBoxItem)cmbEvaluationsPrecedentes.SelectedItem).Value).GetValeurChamp<int>("edaId");
            RequeteSuppression reqSup = new RequeteSuppression(NomTable.evaluationdepannagealimentaire, 
                                                               new ConditionRequete(Operateur.EGAL, "edaId", idEval.ToString()));

            if (Global.BaseDonneesCABS.EnvoyerRequeteSuppression(reqSup) < 0)
            {
                Journal.AfficherMessage("Une erreur est survenue lors de la suppression de l'évaluation dans la base de données. L'action a été annulée.", TypeMessage.ERREUR, true);
                return false;
            }

            return true;
        }

        private void btnConfirmer_Click(object sender, EventArgs e)
        {
            if (Enregistrer())
                RafraichirEvaluations();
        }

        public override bool Enregistrer()
        {
            if (!base.Enregistrer() || !ValiderDonnees())
                return false;

            LigneTable evaluation = CreerEvaluation();

            if (Mode == ModeFormulaire.AJOUT)
            {
                RequeteAjout reqAjout = new RequeteAjout(NomTable.evaluationdepannagealimentaire, evaluation);
                int idEval = Global.BaseDonneesCABS.EnvoyerRequeteAjout(reqAjout);

                if (idEval == -1)
                {
                    Journal.AfficherMessage("Une erreur est survenue lors de l'ajout de l'évaluation dans la base de données. L'action a été annulée.", TypeMessage.ERREUR, true);
                    return false;
                }
            }
            else if (Mode == ModeFormulaire.EDITION)
            {
                int idEval = ((LigneTable)((ComboBoxItem)cmbEvaluationsPrecedentes.SelectedItem).Value).GetValeurChamp<int>("edaId");
                ConditionRequete cond = new ConditionRequete(Operateur.EGAL, "edaId", idEval.ToString());
                RequeteModification reqModif = new RequeteModification(NomTable.evaluationdepannagealimentaire, cond, evaluation);
                int lignesModifiees = Global.BaseDonneesCABS.EnvoyerRequeteModification(reqModif);

                if (lignesModifiees < 0)
                {
                    Journal.AfficherMessage("Une erreur est survenue lors de la modification de l'évaluation. L'action a été annulée.", TypeMessage.ERREUR, true);
                    return false;
                }
            }

            return true;
        }

        public override bool ValiderDonnees()
        {
            if (!base.ValiderDonnees())
                return false;

            if(!OutilsForms.VerifierCondition(dtpDateNaissance.Value > DateTime.Today, "Veuillez entrer une date d'évaluation valide."))
                return false;

            return true;
        }

        private LigneTable CreerEvaluation()
        {
            LigneTable evaluation = new LigneTable("EvaluationDepannageAlimentaire");

            evaluation.AjouterChamp("edaNbPersonnes", (int)nudNbPersonnes.Value);

            evaluation.AjouterChamp("edaAideSociale", nudAideSociale.Value);
            evaluation.AjouterChamp("edaAssuranceAuto", nudAssuranceAuto.Value);
            evaluation.AjouterChamp("edaAssuranceLogement", nudAssuranceLogement.Value);
            evaluation.AjouterChamp("edaAssuranceVie", nudAssuranceVie.Value);
            evaluation.AjouterChamp("edaAutresDepenses1", nudAutresDepenses1.Value);
            evaluation.AjouterChamp("edaAutresDepenses2", nudAutresDepenses2.Value);
            evaluation.AjouterChamp("edaAutresDepenses3", nudAutresDepenses3.Value);
            evaluation.AjouterChamp("edaAutresRevenus1", nudAutresRevenus1.Value);
            evaluation.AjouterChamp("edaAutresRevenus2", nudAutresRevenus2.Value);
            evaluation.AjouterChamp("edaAutresRevenus3", nudAutresRevenus3.Value);
            evaluation.AjouterChamp("edaCableInternetTelephone", nudCableInternetTelephone.Value);
            evaluation.AjouterChamp("edaCellulaire", nudCellulaire.Value);
            evaluation.AjouterChamp("edaChauffage", nudChauffage.Value);
            evaluation.AjouterChamp("edaChomage", nudChomage.Value);
            evaluation.AjouterChamp("edaDepensesCourantes", nudDepensesCourantes.Value);
            evaluation.AjouterChamp("edaEssenceEntretien", nudEssenceEntretien.Value);
            evaluation.AjouterChamp("edaHydroQuebec", nudHydroQuebec.Value);
            evaluation.AjouterChamp("edaImmatriculationPermis", nudImmatriculationPermis.Value);
            evaluation.AjouterChamp("edaImpotSolidarite", nudImpotSolidarite.Value);
            evaluation.AjouterChamp("edaLoyerHypotheque", nudLoyerHypotheque.Value);
            evaluation.AjouterChamp("edaPensionAlimentaireDepense", nudPensionAlimentaireDepenses.Value);
            evaluation.AjouterChamp("edaPensionAlimentaireRevenu", nudPensionAlimentaireRevenus.Value);
            evaluation.AjouterChamp("edaPensionVieillesse", nudPensionVieillesse.Value);
            evaluation.AjouterChamp("edaPrestationsFamFed", nudPresFamFed.Value);
            evaluation.AjouterChamp("edaPrestationsFamProv", nudPresFamProv.Value);
            evaluation.AjouterChamp("edaRemboursementAuto", nudRemboursementAuto.Value);
            evaluation.AjouterChamp("edaRRQ", nudRRQ.Value);
            evaluation.AjouterChamp("edaTalonPaie", nudTalonPaie.Value);
            evaluation.AjouterChamp("edaTaxesScolairesMun", nudTaxesScolairesNum.Value);
            evaluation.AjouterChamp("edaTPS", nudTPS.Value);

            evaluation.AjouterChamp("edaNomAutreDepenses1", txtAutresDepenses1.Text);
            evaluation.AjouterChamp("edaNomAutresDepenses2", txtAutresDepenses2.Text);
            evaluation.AjouterChamp("edaNomAutresDepenses3", txtAutresDepenses3.Text);
            evaluation.AjouterChamp("edaNomAutresRevenus1", txtAutresRevenus1.Text);
            evaluation.AjouterChamp("edaNomAutresRevenus2", txtAutresRevenus2.Text);
            evaluation.AjouterChamp("edaNomAutresRevenus3", txtAutresRevenus3.Text);
            evaluation.AjouterChamp("edaCommentaires", txtCommentaires.Text);

            evaluation.AjouterChamp("edaDate", dtpDateNaissance.Value);
            evaluation.AjouterChamp("edaAccepte", rbAccepte.Checked);

            evaluation.AjouterChamp(BeneficiaireCourant.GetChamp("idaId"));

            return evaluation;
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            RafraichirEvaluations();
        }

        private void RafraichirEvaluations()
        {
            if (BeneficiaireCourant != null)
                ChargerDonneesBeneficiaireCourant();
            else
                Vider();

            ChangerAccesControle(ModeFormulaire.CONSULTATION);
        }

        private void ChargerDonneesBeneficiaireCourant()
        {
            RequeteSelection reqSel = new RequeteSelection(NomTable.evaluationdepannagealimentaire);
            reqSel.Condition = new ConditionRequete(Operateur.EGAL, BeneficiaireCourant.GetChamp("idaId"));
            reqSel.AjouterTri("edaDate", false);

            Evaluations = Global.BaseDonneesCABS.EnvoyerRequeteSelection(reqSel);
            cmbEvaluationsPrecedentes.Items.Clear();

            foreach (LigneTable eval in Evaluations.Lignes)
            {
                DateTime dateEval = eval.GetValeurChamp<DateTime>("edaDate");
                cmbEvaluationsPrecedentes.Items.Add(new ComboBoxItem(dateEval.ToLongDateString(), eval));
            }

            if (cmbEvaluationsPrecedentes.Items.Count > 0)
                cmbEvaluationsPrecedentes.SelectedIndex = 0;
            else
                Vider();
        }

        public override void Vider()
        {
            base.Vider();

            nudAideSociale.Value = nudAssuranceAuto.Value = nudAssuranceLogement.Value = nudAssuranceVie.Value = nudAutresDepenses1.Value =
            nudAutresDepenses2.Value = nudAutresDepenses3.Value = nudAutresRevenus1.Value = nudAutresRevenus2.Value = nudAutresRevenus3.Value =
            nudCableInternetTelephone.Value = nudCellulaire.Value = nudChauffage.Value = nudChomage.Value = nudDepensesCourantes.Value =
            nudEssenceEntretien.Value = nudHydroQuebec.Value = nudImmatriculationPermis.Value = nudImpotSolidarite.Value = nudLoyerHypotheque.Value =
            nudNbPersonnes.Value = nudPensionAlimentaireDepenses.Value = nudPensionAlimentaireRevenus.Value = nudPensionVieillesse.Value =
            nudPresFamFed.Value = nudPresFamProv.Value = nudRemboursementAuto.Value = nudRRQ.Value = nudTalonPaie.Value = nudTaxesScolairesNum.Value = nudTPS.Value = 0;

            txtAutresDepenses1.Text = txtAutresDepenses2.Text = txtAutresDepenses3.Text = txtAutresRevenus1.Text = txtAutresRevenus2.Text = txtAutresRevenus3.Text = txtCommentaires.Text = "";

            dtpDateNaissance.Value = DateTime.Today;

            rbAccepte.Checked = !(rbRefuse.Checked = true);
        }

        public override void ChangerAccesControle(ModeFormulaire mode)
        {
            base.ChangerAccesControle(mode);

            btnChoisirBeneficiaire.Enabled = 
            cmbEvaluationsPrecedentes.Enabled = Mode == ModeFormulaire.CONSULTATION;

            btnConfirmer.Enabled = btnAnnuler.Enabled = 
            nudAideSociale.Enabled = nudAssuranceAuto.Enabled = nudAssuranceLogement.Enabled = nudAssuranceVie.Enabled = nudAutresDepenses1.Enabled =
            nudAutresDepenses2.Enabled = nudAutresDepenses3.Enabled = nudAutresRevenus1.Enabled = nudAutresRevenus2.Enabled = nudAutresRevenus3.Enabled =
            nudCableInternetTelephone.Enabled = nudCellulaire.Enabled = nudChauffage.Enabled = nudChomage.Enabled = nudDepensesCourantes.Enabled =
            nudEssenceEntretien.Enabled = nudHydroQuebec.Enabled = nudImmatriculationPermis.Enabled = nudImpotSolidarite.Enabled = nudLoyerHypotheque.Enabled =
            nudNbPersonnes.Enabled = nudPensionAlimentaireDepenses.Enabled = nudPensionAlimentaireRevenus.Enabled = nudPensionVieillesse.Enabled = 
            nudPresFamFed.Enabled = nudPresFamProv.Enabled = nudRemboursementAuto.Enabled = nudRRQ.Enabled = nudTalonPaie.Enabled = nudTaxesScolairesNum.Enabled = nudTPS.Enabled =
            txtAutresDepenses1.Enabled = txtAutresDepenses2.Enabled = txtAutresDepenses3.Enabled = txtAutresRevenus1.Enabled = txtAutresRevenus2.Enabled = txtAutresRevenus3.Enabled = txtCommentaires.Enabled =
            dtpDateNaissance.Enabled =
            rbAccepte.Enabled = rbRefuse.Enabled = !(Mode == ModeFormulaire.CONSULTATION);

            btnNouveau.Enabled = btnInscription.Enabled = (Mode == ModeFormulaire.CONSULTATION && BeneficiaireCourant != null);
            btnModifier.Enabled = btnSupprimer.Enabled = (Mode == ModeFormulaire.CONSULTATION && Evaluations != null && !Evaluations.EstVide);
        }

        private void btnInscription_Click(object sender, EventArgs e)
        {
            if (ParentForm is frmPrincipal)
                ((frmPrincipal)ParentForm).ChangerFormulaire("CABS.Formulaires.Inscription.frmInscriptionServicesBeneficiaires", BeneficiaireCourant, IdService);
        }

        public override bool QuitterPage()
        {
            if (!base.QuitterPage())
                return false;

            if (Mode == ModeFormulaire.AJOUT || Mode == ModeFormulaire.EDITION)
            {
                return OutilsForms.PoserQuestion("Confirmation", "Des modifications n'ont pas été enregistrées et seront perdues.\nVoulez-vous vraiment quitter sans enregistrer?");
            }

            return true;
        }
    }
}
