using CABS.BaseDonnees;
using CABS.Outils;
using CustomControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CABS.Formulaires
{
    public partial class frmGestionLivraisons : Formulaire
    {
        private static string RequeteBeneficiaire = "SELECT p.*, ip.iprSolde FROM personne p INNER JOIN inscriptionservice i ON p.perId = i.perId INNER JOIN inscriptionpopoteroulante ip ON p.perId = ip.perId WHERE p.staId = {0} AND i.insSuspendu = 0 AND i.serId = {1} ORDER BY p.perNom, p.perPrenom, p.perDateNaissance;";

        private BoldedDateCategory CategorieAvant;
        private BoldedDateCategory CategorieApres;

        private LigneTable BeneficiaireCourant;
        private Table Livraisons;

        private int IdService;
        private int IdStatut;

        public frmGestionLivraisons()
            : base(true, true)
        {
            InitializeComponent();

            CategorieAvant = new BoldedDateCategory("Avant");
            CategorieAvant.BackColorStart = CategorieAvant.BackColorEnd = Color.Red;

            CategorieApres = new BoldedDateCategory("Après");
            CategorieApres.BackColorStart = CategorieApres.BackColorEnd = Color.LimeGreen;

            BeneficiaireCourant = null;
            Livraisons = new Table("livraisonpopoteroulante");

            IdService = IdStatut = -1;
        }

        private void frmGestionLivraisons_Load(object sender, EventArgs e)
        {
            cmbFrequence.SelectedIndex = 0;
            cmbFrequence.MouseWheel += new MouseEventHandler(numericUpDown_MouseWheel);

            mcCalendrier.BoldedDateCategoryCollection.Add(CategorieAvant);
            mcCalendrier.BoldedDateCategoryCollection.Add(CategorieApres);

            cbLundi.EnabledChanged += new EventHandler(CheckBoxDesactive);
            cbMardi.EnabledChanged += new EventHandler(CheckBoxDesactive);
            cbMercredi.EnabledChanged += new EventHandler(CheckBoxDesactive);
            cbJeudi.EnabledChanged += new EventHandler(CheckBoxDesactive);
            cbVendredi.EnabledChanged += new EventHandler(CheckBoxDesactive);
            cbSamedi.EnabledChanged += new EventHandler(CheckBoxDesactive);
            cbDimanche.EnabledChanged += new EventHandler(CheckBoxDesactive);
            cbFinDeSemaine.EnabledChanged += new EventHandler(CheckBoxDesactive);

            nudNombreRepas.MouseWheel += new MouseEventHandler(numericUpDown_MouseWheel);
            nudPrixRepas.MouseWheel += new MouseEventHandler(numericUpDown_MouseWheel);

            nudNombreRepas.Click += new EventHandler(numericUpDown_Click);
            nudPrixRepas.Click += new EventHandler(numericUpDown_Click);

            nudNombreRepas.KeyPress += new KeyPressEventHandler(numericUpDown_KeyPress);
            nudPrixRepas.KeyPress += new KeyPressEventHandler(numericUpDown_KeyPress);

            RequeteSelection reqSel = new RequeteSelection(NomTable.service, "serId");
            reqSel.Condition = new ConditionRequete(Operateur.COMME, "serNom", "'Popote roulante'");

            Table service = Global.BaseDonneesCABS.EnvoyerRequeteSelection(reqSel);

            if (service.NombreLignes == 1)
                IdService = service.Lignes[0].GetValeurChamp<int>("serId");

            reqSel = new RequeteSelection(NomTable.statut, "staId");
            reqSel.Condition = new ConditionRequete(Operateur.COMME, "staNom", "'Actif'");

            Table statut = Global.BaseDonneesCABS.EnvoyerRequeteSelection(reqSel);

            if (statut.NombreLignes == 1)
                IdStatut = statut.Lignes[0].GetValeurChamp<int>("staId");

            nudPrixRepas.Value = Global.GetConfiguration<decimal>("PRIX_REPAS_POPOTE");
        }

        private void numericUpDown_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
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

        public override void EntrerPage()
        {
            base.EntrerPage();

            DateTime maintenant = DateTime.Now;
            mcCalendrier.SelectionRange = new SelectionRange(maintenant, maintenant);
            mcCalendrier.ViewStart = maintenant;
        }

        private void CheckBoxDesactive(object sender, EventArgs e)
        {
            CheckBox cbSender = (CheckBox)sender;

            if (!cbSender.Enabled)
                cbSender.Checked = false;
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
                lblNomValeur.Text = choixBeneficiaire.LigneChoisie.GetValeurChamp<string>("perNom");
                lblPrenomValeur.Text = choixBeneficiaire.LigneChoisie.GetValeurChamp<string>("perPrenom");

                ChargerLivraisons();
            }

            mcCalendrier.Enabled = gbGestionLivraisons.Enabled = btnInscription.Enabled = BeneficiaireCourant != null;
        }

        private void ChargerLivraisons()
        {
            RequeteSelection reqSel = new RequeteSelection(NomTable.livraisonpopoteroulante);
            reqSel.Condition = new ConditionRequete(Operateur.EGAL, BeneficiaireCourant.GetChamp("perId"));
            reqSel.AjouterTri("lprDate");

            Livraisons = Global.BaseDonneesCABS.EnvoyerRequeteSelection(reqSel);

            mcCalendrier.BoldedDatesCollection.Clear();

            foreach (LigneTable liv in Livraisons.Lignes)
            {
                AjouterLivraisonCalendrier(liv.GetValeurChamp<DateTime>("lprDate"));
            }

            RafraichirInfosLivraison();
        }

        private void AjouterLivraisonCalendrier(DateTime date)
        {
            BoldedDate nouvelleDate = new BoldedDate();
            nouvelleDate.Value = date;
            nouvelleDate.Category = date < DateTime.Now ? CategorieAvant : CategorieApres;

            mcCalendrier.BoldedDatesCollection.Add(nouvelleDate);
            mcCalendrier.Refresh();
        }

        private void SupprimerLivraisonCalendrier(DateTime date)
        {
            BoldedDate dateSupprimee = mcCalendrier.BoldedDatesCollection.Find(b => b.Value == date);

            mcCalendrier.BoldedDatesCollection.Remove(dateSupprimee);
            mcCalendrier.Refresh();
        }

        private void mcCalendrier_DateSelected(object sender, DateRangeEventArgs e)
        {
            if(BeneficiaireCourant != null)
                RafraichirInfosLivraison();
        }

        private void RafraichirInfosLivraison()
        {
            int indexLivraison = GetIndexLivraisonExistante(mcCalendrier.SelectionStart);
            int nbRepas = 0;
            decimal prixRepas = 0;

            if (indexLivraison >= 0)
            {
                LigneTable livraison = Livraisons.Lignes[indexLivraison];
                nbRepas = livraison.GetValeurChamp<int>("lprNombreRepas");
                prixRepas = livraison.GetValeurChamp<decimal>("lprPrixRepas");
            }

            lblDateValeur.Text = mcCalendrier.SelectionStart.ToShortDateString();
            lblNbRepasValeur.Text = nbRepas.ToString();
            lblPrixRepasValeur.Text = prixRepas.ToString("C");
        }

        private int GetIndexLivraisonExistante(DateTime date)
        {
            return Livraisons.Lignes.FindIndex(l => l.GetValeurChamp<DateTime>("lprDate") == date);
        }

        private void cmbFrequence_SelectedIndexChanged(object sender, EventArgs e)
        {
            string frequence = cmbFrequence.SelectedItem.ToString();

            cbLundi.Enabled = cbMardi.Enabled = cbMercredi.Enabled =
            cbJeudi.Enabled = cbVendredi.Enabled = cbSamedi.Enabled =
            cbDimanche.Enabled = frequence == "Semaine";

            dtpDe.Enabled = dtpA.Enabled = frequence != "Date sélectionnée";

            cbFinDeSemaine.Enabled = frequence == "Jour";
        }

        private void btnAjouterLivraisons_Click(object sender, EventArgs e)
        {
            if(Enregistrer())
                RafraichirInfosLivraison();
        }

        public override bool Enregistrer()
        {
            if (!base.Enregistrer())
                return false;

            if (!ValiderDonnees())
                return false;

            List<DateTime> datesAAjouter = new List<DateTime>();
            List<DateTime> datesAModifier = new List<DateTime>();

            foreach (DateTime date in GetDatesConsiderees())
            {
                if (GetIndexLivraisonExistante(date) < 0)
                    datesAAjouter.Add(date);
                else
                    datesAModifier.Add(date);
            }
            
            Champ champId = new Champ("livraisonpopoteroulante", "perId", BeneficiaireCourant.GetValeurChamp<int>("perId"));
            Champ champNbRepas = new Champ("livraisonpopoteroulante", "lprNombreRepas", (int)nudNombreRepas.Value);
            Champ champPrixRepas = new Champ("livraisonpopoteroulante", "lprPrixRepas", nudPrixRepas.Value);

            LigneTable livraison = new LigneTable("livraisonpopoteroulante");
            livraison.AjouterChamp(champId);
            livraison.AjouterChamp(champNbRepas);
            livraison.AjouterChamp(champPrixRepas);

            bool erreur = false;

            foreach (DateTime date in datesAAjouter)
            {
                LigneTable copieLivraison = new LigneTable(livraison);
                copieLivraison.AjouterChamp(new Champ("livraisonpopoteroulante", "lprDate", date));

                RequeteAjout reqAjout = new RequeteAjout(NomTable.livraisonpopoteroulante, copieLivraison);

                if (Global.BaseDonneesCABS.EnvoyerRequeteAjout(reqAjout) < 0)
                {
                    erreur = true;
                }
                else
                {
                    Livraisons.Lignes.Add(copieLivraison);
                    AjouterLivraisonCalendrier(date);
                }
            }

            ConditionRequete cond = new ConditionRequete(Operateur.EGAL, champId);
            RequeteModification reqModif = new RequeteModification(NomTable.livraisonpopoteroulante, cond, champNbRepas, champPrixRepas);

            foreach (DateTime date in datesAModifier)
            {
                ConditionRequete copieCond = new ConditionRequete(cond);
                copieCond.LierCondition(new ConditionRequete(Operateur.EGAL, new Champ("livraisonpopoteroulante", "lprDate", date)), true);

                reqModif.Condition = copieCond;

                if (Global.BaseDonneesCABS.EnvoyerRequeteModification(reqModif) < 0)
                {
                    erreur = true;
                }
                else
                {
                    int indexLivraisonAModifier = GetIndexLivraisonExistante(date);

                    if (indexLivraisonAModifier >= 0)
                    {
                        LigneTable copieLivraison = new LigneTable(livraison);
                        copieLivraison.AjouterChamp(new Champ("livraisonpopoteroulante", "lprDate", date));
                        Livraisons.Lignes[indexLivraisonAModifier] = copieLivraison;
                    }
                }
            }

            if (erreur)
                Journal.AfficherMessage("Une erreur est survenue lors de la modification d'une ou plusieurs livraisons.", TypeMessage.ERREUR, true);

            return true;
        }

        public override bool ValiderDonnees()
        {
            if (!base.ValiderDonnees())
                return false;

            string frequence = cmbFrequence.SelectedItem.ToString();
            bool datesInvalides = frequence != "Date sélectionnée" && dtpDe.Value > dtpA.Value;
            bool aucunJour = frequence == "Semaine" && !cbLundi.Checked && !cbMardi.Checked && 
                             !cbMercredi.Checked && !cbJeudi.Checked && !cbVendredi.Checked && !cbSamedi.Checked && 
                             !cbDimanche.Checked;

            if (!OutilsForms.VerifierCondition(datesInvalides, "La date de début doit être plus petite ou égale à la date de fin.") ||
               !OutilsForms.VerifierCondition(aucunJour, "Veuillez sélectionner au moins une journée de la semaine."))
            {
                return false;
            }

            return true;
        }

        private void btnSupprimerLivraisons_Click(object sender, EventArgs e)
        {
            if(Supprimer())
                RafraichirInfosLivraison();
        }

        public override bool Supprimer()
        {
            if (!base.Supprimer())
                return false;

            if (!ValiderDonnees())
                return false;

            if (!OutilsForms.PoserQuestion("Confirmation suppression", "Voulez-vous vraiment supprimer ces livraisons?"))
                return false;

            List<DateTime> datesASupprimer = new List<DateTime>();

            foreach (DateTime date in GetDatesConsiderees())
            {
                if (GetIndexLivraisonExistante(date) >= 0)
                    datesASupprimer.Add(date);
            }

            ConditionRequete cond = new ConditionRequete(Operateur.EGAL, BeneficiaireCourant.GetChamp("perId"));
            RequeteSuppression reqSup;
            bool erreurAffichee = false;

            foreach (DateTime date in datesASupprimer)
            {
                Champ champDate = new Champ("livraisonpopoteroulante", "lprDate", date);

                ConditionRequete copieCond = new ConditionRequete(cond);
                copieCond.LierCondition(new ConditionRequete(Operateur.EGAL, champDate), true);

                reqSup = new RequeteSuppression(NomTable.livraisonpopoteroulante, copieCond);

                if (Global.BaseDonneesCABS.EnvoyerRequeteSuppression(reqSup) < 0 && !erreurAffichee)
                {
                    Journal.AfficherMessage("Une erreur est survenue lors de la suppression d'une ou plusieurs livraisons.", TypeMessage.ERREUR, true);
                    erreurAffichee = true;
                }
                else
                {
                    int indexLivraisonASupprimer = GetIndexLivraisonExistante(date);

                    if (indexLivraisonASupprimer >= 0)
                        Livraisons.Lignes.RemoveAt(indexLivraisonASupprimer);

                    SupprimerLivraisonCalendrier(date);
                }
            }

            return true;
        }

        private List<DateTime> GetDatesConsiderees()
        {
            List<DateTime> dates = new List<DateTime>();

            string frequence = cmbFrequence.SelectedItem.ToString();

            if (frequence == "Date sélectionnée")
            {
                dates.Add(mcCalendrier.SelectionStart);
            }
            else if (frequence == "Jour")
            {
                DateTime dateCourante = dtpDe.Value.Date;
                DateTime dateFin = dtpA.Value.Date;

                while (dateCourante <= dateFin)
                {
                    DayOfWeek jour = dateCourante.DayOfWeek;

                    if (!(!cbFinDeSemaine.Checked && (jour == DayOfWeek.Saturday || jour == DayOfWeek.Sunday)))
                        dates.Add(dateCourante);

                    dateCourante = dateCourante.AddDays(1);
                }
            }
            else if (frequence == "Semaine")
            {
                DateTime dateCourante = dtpDe.Value.Date;
                DateTime dateFin = dtpA.Value.Date;

                while (dateCourante <= dateFin)
                {
                    DayOfWeek jour = dateCourante.DayOfWeek;
                    bool ajout = (jour == DayOfWeek.Monday && cbLundi.Checked) ||
                                 (jour == DayOfWeek.Tuesday && cbMardi.Checked) ||
                                 (jour == DayOfWeek.Wednesday && cbMercredi.Checked) ||
                                 (jour == DayOfWeek.Thursday && cbJeudi.Checked) ||
                                 (jour == DayOfWeek.Friday && cbVendredi.Checked) ||
                                 (jour == DayOfWeek.Saturday && cbSamedi.Checked) ||
                                 (jour == DayOfWeek.Sunday && cbDimanche.Checked);

                    if (ajout)
                        dates.Add(dateCourante);

                    dateCourante = dateCourante.AddDays(1);
                }
            }

            return dates;
        }

        private void btnInscription_Click(object sender, EventArgs e)
        {
            if (ParentForm is frmPrincipal)
                ((frmPrincipal)ParentForm).ChangerFormulaire("CABS.Formulaires.Inscription.frmInscriptionServicesBeneficiaires", BeneficiaireCourant, IdService);
        }
    }
}
