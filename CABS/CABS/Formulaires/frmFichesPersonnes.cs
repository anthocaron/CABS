using CABS.BaseDonnees;
using CABS.Outils;
using CABS.Outils.Word;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace CABS.Formulaires
{
    public partial class frmFichesPersonnes : Formulaire
    {
        private static string FORMAT_REQ_SERVICES = "SELECT s.serNom FROM service s INNER JOIN inscriptionservice i ON i.serId = s.serId WHERE i.perId = {0} ORDER BY s.serNom;";
        private static string FORMAT_REQ_LANGUE = "SELECT l.lanNom FROM langue l INNER JOIN languepersonne lp ON lp.lanId = l.lanId WHERE lp.perId = {0} AND l.lanNom LIKE '{1}';";

        private LigneTable PersonneCourante;

        private int AncienIndexPersonneCouple;
        private int IndexPersonneCouple;
        private LigneTable PersonneCouple;

        private Table Services;
        private Champ StatutActif;

        public frmFichesPersonnes()
            : base(true, true)
        {
            InitializeComponent();

            PersonneCourante = null;

            AncienIndexPersonneCouple = 0;
            IndexPersonneCouple = 0;
            PersonneCouple = null;

            Services = null;
            StatutActif = null;

            cmbEtatCivil.MouseWheel += new MouseEventHandler(cmbEtatCivil_MouseWheel);
        }

        private void cmbEtatCivil_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        private void frmPersonne_Load(object sender, EventArgs e)
        {
            RequeteSelection reqSelEtatsCivil = new RequeteSelection(NomTable.etatcivil);
            Table etatsCivil = Global.BaseDonneesCABS.EnvoyerRequeteSelection(reqSelEtatsCivil);

            foreach (LigneTable etat in etatsCivil.Lignes)
                cmbEtatCivil.Items.Add(new ComboBoxItem(etat.GetValeurChamp<string>("etaNom"), etat.GetValeurChamp<int>("etaId")));

            RequeteSelection reqSelLangues = new RequeteSelection(NomTable.langue);
            Table langues = Global.BaseDonneesCABS.EnvoyerRequeteSelection(reqSelLangues);

            foreach (LigneTable langue in langues.Lignes)
                chklbLangues.Items.Add(new ComboBoxItem(langue.GetValeurChamp<string>("lanNom"), langue.GetValeurChamp<int>("lanId")));

            RequeteSelection reqSelStatutActif = new RequeteSelection(NomTable.statut, "staId");
            reqSelStatutActif.Condition = new ConditionRequete(Operateur.COMME, "staNom", "'Actif'");

            Table tableStatutActif = Global.BaseDonneesCABS.EnvoyerRequeteSelection(reqSelStatutActif);

            if (!tableStatutActif.EstVide)
                StatutActif = tableStatutActif.Lignes[0].GetChamp("staId");
        }

        public override void EntrerPage()
        {
            base.EntrerPage();
            RafraichirPersonneCourante();
        }

        public override void EnvoyerMessages(params object[] messages)
        {
            if (messages.Length == 1 && messages[0] is LigneTable)
            {
                PersonneCourante = (LigneTable)messages[0];
                RafraichirPersonneCourante();
            }
        }

        private void btnRechercher_Click(object sender, EventArgs e)
        {
            RequeteSelection reqSel = new RequeteSelection(NomTable.personne);
            reqSel.AjouterTri("perNom");
            reqSel.AjouterTri("perPrenom");
            reqSel.AjouterTri("perDateNaissance");

            Table personnes = Global.BaseDonneesCABS.EnvoyerRequeteSelection(reqSel);
            frmSelectionTable choixPersonne = new frmSelectionTable("Choisir un personne...", personnes, new List<string> { "perNom", "perPrenom", "perDateNaissance" }, "perId");

            if (choixPersonne.AfficherDialogue(this))
            {
                PersonneCourante = choixPersonne.LigneChoisie;
                RafraichirPersonneCourante();
            }
        }

        private void cbBenevole_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbBenevole.Checked)
            {
                txtNoCarte.ResetText();
                cbEnProbation.Checked = false;
                dtpDebutProbation.Value = dtpFinProbation.Value = DateTime.Today;
            }

            txtNoCarte.Enabled = cbEnProbation.Enabled = cbBenevole.Checked;
            dtpDebutProbation.Enabled = dtpFinProbation.Enabled = cbBenevole.Checked && cbEnProbation.Checked;
        }

        private void cbEnProbation_CheckedChanged(object sender, EventArgs e)
        {
            dtpDebutProbation.Enabled = dtpFinProbation.Enabled = cbEnProbation.Checked;
        }

        private void btnChoisirCouple_Click(object sender, EventArgs e)
        {
            RequeteSelection reqSel = new RequeteSelection(NomTable.personne);
            reqSel.AjouterTri("perNom");
            reqSel.AjouterTri("perPrenom");
            reqSel.AjouterTri("perDateNaissance");

            Table personnes = Global.BaseDonneesCABS.EnvoyerRequeteSelection(reqSel);
            frmSelectionTable choixCouple = new frmSelectionTable("Choisir un conjoint(e)...", personnes, new List<string> { "perNom", "perPrenom", "perDateNaissance" }, "perId");

            if (choixCouple.AfficherDialogue(this))
            {
                RemplirDonneesCouple(choixCouple.LigneChoisie);
            }
        }

        private void btnSeparerCouple_Click(object sender, EventArgs e)
        {
            ViderDonneesCouple();
        }

        private void dtpDateNaissance_ValueChanged(object sender, EventArgs e)
        {
            TimeSpan age = DateTime.Now - dtpDateNaissance.Value;
            lblAgeValeur.Text = (age.Days / 365).ToString();
        }

        private void cbEchoBenevole_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbEchoBenevole.Checked)
                cbParCourriel.Checked = false;

            cbParCourriel.Enabled = cbEchoBenevole.Enabled && cbEchoBenevole.Checked;
        }

        private void btnNouveau_Click(object sender, EventArgs e)
        {
            ChangerAccesControle(ModeFormulaire.AJOUT);
            Vider();
        }

        public override void Vider()
        {
            base.Vider();

            cbBeneficiaire.Checked = cbBenevole.Checked = cbEmploye.Checked = false;

            txtNoCarte.Text = txtNom.Text = txtPrenom.Text = txtCourriel.Text = txtNoCivique.Text = txtNoAppart.Text = txtRue.Text = txtVille.Text = txtCommentaires.Text = txtCasePostale.Text =
            mtxtTelephone1.Text = mtxtTelephone2.Text = mtxtTelephone3.Text = mtxtCodePostal.Text = "";

            rbSexeM.Checked = rbFumeurNon.Checked = true;

            if (cmbEtatCivil.Items.Count > 0)
                cmbEtatCivil.SelectedIndex = 0;

            foreach (int indexLangue in chklbLangues.CheckedIndices)
                chklbLangues.SetItemChecked(indexLangue, false);

            cbEnProbation.Checked = cbEchoBenevole.Checked = cbParCourriel.Checked = false;
            dtpDebutProbation.Value = dtpFinProbation.Value = DateTime.Today;
            dtpDateNaissance.Value = DateTime.Today.AddDays(1);

            lblDateDerniereMajValeur.Text = lblStatutValeur.Text = "";

            ViderDonneesCouple();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            ChangerAccesControle(ModeFormulaire.EDITION);
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (Supprimer())
                RafraichirPersonneCourante();
        }

        public override bool Supprimer()
        {
            if (!base.Supprimer())
                return false;

            if (!OutilsForms.PoserQuestion("Confirmation suppression", "Confirmez-vous vouloir supprimer cet personne de la base de données?"))
                return false;

            RequeteSuppression reqSup = new RequeteSuppression(NomTable.personne, new ConditionRequete(Operateur.EGAL, PersonneCourante.GetChamp("perId")));

            if (Global.BaseDonneesCABS.EnvoyerRequeteSuppression(reqSup) < 0)
            {
                Journal.AfficherMessage("Une erreur est survenue lors de la suppression de la personne dans la base de données. L'action a été annulée.", TypeMessage.ERREUR, true);
                return false;
            }

            PersonneCourante = null;
            return true;
        }

        private void btnConfirmer_Click(object sender, EventArgs e)
        {
            if (Enregistrer())
                RafraichirPersonneCourante();
        }

        public override bool Enregistrer()
        {
            Global.BaseDonneesCABS.CommencerTransaction();

            if (!base.Enregistrer() || !ValiderDonnees())
            {
                Global.BaseDonneesCABS.AnnulerTransaction();
                return false;
            }

            Champ indexPersonne = null;

            if(PersonneCourante != null)
                indexPersonne = PersonneCourante.GetChamp("perId");

            LigneTable adresseModifiee = null;

            if (Mode == ModeFormulaire.AJOUT)
            {
                LigneTable nouvellePersonne = CreerNouvellePersonne();
                nouvellePersonne.AjouterChamp("perDateOuverture", DateTime.Now);

                RequeteSelection reqSelNom = new RequeteSelection(NomTable.personne, "perId");
                reqSelNom.Condition = new ConditionRequete(Operateur.EGAL, "perNom", nouvellePersonne.GetChamp("perNom").ValeurSQL);
                reqSelNom.Condition.LierCondition(new ConditionRequete(Operateur.EGAL, "perPrenom", nouvellePersonne.GetChamp("perPrenom").ValeurSQL), true);

                if (!Global.BaseDonneesCABS.EnvoyerRequeteSelection(reqSelNom).EstVide && !OutilsForms.PoserQuestion("Confirmation d'ajout", "Une autre personne porte les mêmes nom et prénom. Voulez-vous quand même ajouter celle-ci?"))
                {
                    Global.BaseDonneesCABS.AnnulerTransaction();
                    return false;
                }

                if (StatutActif == null)
                {
                    Journal.AfficherMessage("La table des statuts est inexistante ou corrompue. L'action a été annulée.", TypeMessage.ERREUR, true);
                    Global.BaseDonneesCABS.AnnulerTransaction();
                    return false;
                }

                nouvellePersonne.AjouterChamp(StatutActif);

                RequeteAjout reqAjout = new RequeteAjout(NomTable.personne, nouvellePersonne);
                int nouvelIndexPersonne = Global.BaseDonneesCABS.EnvoyerRequeteAjout(reqAjout);

                if (nouvelIndexPersonne == -1)
                {
                    Journal.AfficherMessage("Une erreur est survenue lors de l'ajout de la personne dans la base de données. L'action a été annulée.", TypeMessage.ERREUR, true);
                    Global.BaseDonneesCABS.AnnulerTransaction();
                    return false;
                }

                indexPersonne = new Champ("Personne", "perId", nouvelIndexPersonne);
                nouvellePersonne.AjouterChamp(indexPersonne);
                PersonneCourante = nouvellePersonne;

                adresseModifiee = GetAdresseModifiee(PersonneCourante, new LigneTable("Personne"));
            }
            else if (Mode == ModeFormulaire.EDITION)
            {
                LigneTable personneModifiee = CreerNouvellePersonne();
                personneModifiee.AjouterChamp(PersonneCourante.GetChamp("staId"));

                RequeteModification reqModif = new RequeteModification(NomTable.personne, new ConditionRequete(Operateur.EGAL, indexPersonne), personneModifiee);
                int lignesModifiees = Global.BaseDonneesCABS.EnvoyerRequeteModification(reqModif);

                if (lignesModifiees < 0)
                {
                    Journal.AfficherMessage("Une erreur est survenue lors de la modification de la personne. L'action a été annulée.", TypeMessage.ERREUR, true);
                    Global.BaseDonneesCABS.AnnulerTransaction();
                    return false;
                }

                RequeteSuppression reqSup = new RequeteSuppression(NomTable.languepersonne, new ConditionRequete(Operateur.EGAL, indexPersonne));

                if (Global.BaseDonneesCABS.EnvoyerRequeteSuppression(reqSup) < 0)
                {
                    Journal.AfficherMessage("Une erreur est survenue lors de la suppression des langues parlées de la personne. L'action a été annulée.", TypeMessage.ERREUR, true);
                    Global.BaseDonneesCABS.AnnulerTransaction();
                    return false;
                }

                personneModifiee.AjouterChamp(indexPersonne);
                PersonneCourante = personneModifiee;

                adresseModifiee = GetAdresseModifiee(PersonneCourante, personneModifiee);
            }

            if (IndexPersonneCouple != 0 && adresseModifiee != null &&
                OutilsForms.PoserQuestion("Modification adresse conjoint(e)", "Voulez-vous modifier l'adresse du conjoint(e) pour celle de la personne courante?"))
            {
                RequeteModification reqModif = new RequeteModification(NomTable.personne, new ConditionRequete(Operateur.EGAL, new Champ("Personne", "perId", IndexPersonneCouple)), adresseModifiee);
                int lignesModifiees = Global.BaseDonneesCABS.EnvoyerRequeteModification(reqModif);

                if (lignesModifiees < 0)
                {
                    Journal.AfficherMessage("Une erreur est survenue lors de la modification de l'adresse du conjoint(e). L'action a été annulée.", TypeMessage.ERREUR, true);
                }
            }

            if (!MettreAJourTypesPersonne(indexPersonne))
            {
                Journal.AfficherMessage("Une erreur est survenue lors de la mise à jour des types de la personne dans la base de données. L'action a été annulée.", TypeMessage.ERREUR, true);
                Global.BaseDonneesCABS.AnnulerTransaction();
                return false;
            }

            foreach (ComboBoxItem langue in chklbLangues.CheckedItems)
            {
                Champ idLangue = new Champ("Langue", "lanId", langue.Value);

                RequeteAjout reqAjout = new RequeteAjout(NomTable.languepersonne, indexPersonne, idLangue);

                if (Global.BaseDonneesCABS.EnvoyerRequeteAjout(reqAjout) < 0)
                {
                    Journal.AfficherMessage("Une erreur est survenue lors de l'ajout d'une langue parlée dans la base de données. L'action a été annulée.", TypeMessage.ERREUR, true);
                    Global.BaseDonneesCABS.AnnulerTransaction();
                    return false;
                }
            }

            if (AncienIndexPersonneCouple != IndexPersonneCouple)
            {
                Champ premier = new Champ("Couple", "perIdPremier", indexPersonne.Valeur);
                Champ deuxieme = new Champ("Couple", "perIdDeuxieme", IndexPersonneCouple);

                ConditionRequete condCouple = new ConditionRequete(Operateur.EGAL, "perIdPremier", indexPersonne.ValeurSQL);
                condCouple.LierCondition(new ConditionRequete(Operateur.EGAL, "perIdDeuxieme", indexPersonne.ValeurSQL), false);

                if (AncienIndexPersonneCouple == 0)
                {
                    RequeteAjout reqAjout = new RequeteAjout(NomTable.couple, premier, deuxieme);
                    if (Global.BaseDonneesCABS.EnvoyerRequeteAjout(reqAjout) < 0)
                    {
                        Journal.AfficherMessage("Une erreur est survenue lors de l'ajout du couple de la personne. L'action a été annulée.", TypeMessage.ERREUR, true);
                        Global.BaseDonneesCABS.AnnulerTransaction();
                        return false;
                    }
                }
                else if (IndexPersonneCouple == 0)
                {
                    RequeteSuppression reqSup = new RequeteSuppression(NomTable.couple, condCouple);
                    if (Global.BaseDonneesCABS.EnvoyerRequeteSuppression(reqSup) < 0)
                    {
                        Journal.AfficherMessage("Une erreur est survenue lors de la suppression du couple de la personne. L'action a été annulée.", TypeMessage.ERREUR, true);
                        Global.BaseDonneesCABS.AnnulerTransaction();
                        return false;
                    }
                }
                else
                {
                    RequeteModification reqModif = new RequeteModification(NomTable.couple, condCouple, premier, deuxieme);
                    if (Global.BaseDonneesCABS.EnvoyerRequeteModification(reqModif) < 0)
                    {
                        Journal.AfficherMessage("Une erreur est survenue lors de la modification du couple de la personne. L'action a été annulée.", TypeMessage.ERREUR, true);
                        Global.BaseDonneesCABS.AnnulerTransaction();
                        return false;
                    }
                }
            }

            Global.BaseDonneesCABS.ConfirmerTransaction();
            return true;
        }

        public override bool ValiderDonnees()
        {
            if (!base.ValiderDonnees())
                return false;

            int temp;

            if (!OutilsForms.VerifierCondition(!cbBeneficiaire.Checked && !cbBenevole.Checked && !cbEmploye.Checked, "Veuillez choisir au moins un type pour la personne") ||
                !OutilsForms.VerifierCondition(txtNom.Text.Length <= 0, "Veuillez entrer un nom valide.") ||
                !OutilsForms.VerifierCondition(txtPrenom.Text.Length <= 0, "Veuillez entrer un prénom valide.") ||
                !OutilsForms.VerifierCondition(dtpDateNaissance.Value > DateTime.Today, "Veuillez entrer une date de naissance valide.") ||
                !OutilsForms.VerifierCondition(mtxtTelephone1.Text.Length <= 0, "Veuillez entrer au moins un numéro de téléphone valide.") ||
                !OutilsForms.VerifierCondition(!Int32.TryParse(txtNoCivique.Text, out temp), "Veuillez entrer un numéro civique valide.") ||
                !OutilsForms.VerifierCondition(txtRue.Text.Length <= 0, "Veuillez entrer un nom de rue valide.") ||
                !OutilsForms.VerifierCondition(txtVille.Text.Length <= 0, "Veuillez entrer un nom de ville valide.") ||
                !OutilsForms.VerifierCondition(mtxtCodePostal.Text.Length <= 0, "Veuillez entrer un code postal valide.") ||
                !OutilsForms.VerifierCondition(txtCasePostale.Text.Length > 0 && !Int32.TryParse(txtCasePostale.Text, out temp), "Veuillez entrer un numéro de case postale valide.") ||
                !OutilsForms.VerifierCondition(chklbLangues.CheckedIndices.Count <= 0, "Veuillez sélectionner au moins une langue.") ||
                !OutilsForms.VerifierCondition(cmbEtatCivil.SelectedIndex == -1, "Veuillez sélectionner un état civil.") ||
                !OutilsForms.VerifierCondition(dtpDebutProbation.Value > dtpFinProbation.Value, "Veuillez entrer une période de probation valide."))
            {
                return false;
            }

            if ((lblNomCouple.Text.Length > 0 && cmbEtatCivil.Text == "Célibataire") &&
                !OutilsForms.PoserQuestion("Confirmation", "L'état civil de la personne est \"Célibataire\" malgré l'enregistrement d'un couple.\nVoulez-vous enregistrer quand même?"))
            {
                return false;
            }

            return true;
        }

        private LigneTable CreerNouvellePersonne()
        {
            LigneTable nouvellePersonne = new LigneTable("Personne");

            nouvellePersonne.AjouterChamp("perNom", txtNom.Text);
            nouvellePersonne.AjouterChamp("perPrenom", txtPrenom.Text);
            nouvellePersonne.AjouterChamp("perSexe", rbSexeF.Checked);
            nouvellePersonne.AjouterChamp("perDateNaissance", dtpDateNaissance.Value);
            nouvellePersonne.AjouterChamp("perTelephone1", mtxtTelephone1.Text);
            nouvellePersonne.AjouterChamp("perTelephone2", mtxtTelephone2.Text);
            nouvellePersonne.AjouterChamp("perTelephone3", mtxtTelephone3.Text);
            nouvellePersonne.AjouterChamp("perCourriel", txtCourriel.Text);
            nouvellePersonne.AjouterChamp("perFumeur", rbFumeurOui.Checked);
            nouvellePersonne.AjouterChamp("perInfoCAB", cbEchoBenevole.Checked);
            nouvellePersonne.AjouterChamp("perInfoCABCourriel", cbParCourriel.Checked);
            nouvellePersonne.AjouterChamp("etaId", (cmbEtatCivil.SelectedItem as ComboBoxItem).Value);
            nouvellePersonne.AjouterChamp("perCommentaires", txtCommentaires.Text);

            nouvellePersonne.AjouterChamp("perNoCivique", Int32.Parse(txtNoCivique.Text));
            nouvellePersonne.AjouterChamp("perRue", txtRue.Text);

            if (txtNoAppart.Text.Length > 0)
                nouvellePersonne.AjouterChamp("perNoAppart", txtNoAppart.Text);
            else
                nouvellePersonne.AjouterChamp("perNoAppart", DBNull.Value);

            nouvellePersonne.AjouterChamp("perVille", txtVille.Text);
            nouvellePersonne.AjouterChamp("perCodePostal", mtxtCodePostal.Text);

            if (txtCasePostale.Text.Length > 0)
                nouvellePersonne.AjouterChamp("perCasePostale", Int32.Parse(txtCasePostale.Text));
            else
                nouvellePersonne.AjouterChamp("perCasePostale", DBNull.Value);

            nouvellePersonne.AjouterChamp("perDateDerniereMaj", DateTime.Now);

            return nouvellePersonne;
        }

        private LigneTable GetAdresseModifiee(LigneTable personneCourante, LigneTable personneModifiee)
        {
            LigneTable nouvelleAdresse = new LigneTable("Personne");
            int tempInt;
            string tempString;

            if ((tempInt = personneCourante.GetValeurChamp<int>("perNoCivique")) != personneModifiee.GetValeurChamp<int>("perNoCivique"))
                nouvelleAdresse.AjouterChamp("perNoCivique", tempInt);

            if ((tempString = personneCourante.GetValeurChamp<string>("perNoAppart")) != personneModifiee.GetValeurChamp<string>("perNoAppart"))
                nouvelleAdresse.AjouterChamp("perNoAppart", tempString);

            if ((tempString = personneCourante.GetValeurChamp<string>("perRue")) != personneModifiee.GetValeurChamp<string>("perRue"))
                nouvelleAdresse.AjouterChamp("perRue", tempString);

            if ((tempString = personneCourante.GetValeurChamp<string>("perVille")) != personneModifiee.GetValeurChamp<string>("perVille"))
                nouvelleAdresse.AjouterChamp("perVille", tempString);

            if ((tempString = personneCourante.GetValeurChamp<string>("perCodePostal")) != personneModifiee.GetValeurChamp<string>("perCodePostal"))
                nouvelleAdresse.AjouterChamp("perCodePostal", tempString);

            if ((tempInt = personneCourante.GetValeurChamp<int>("perCasePostale")) != personneModifiee.GetValeurChamp<int>("perCasePostale"))
                nouvelleAdresse.AjouterChamp("perCasePostale", tempInt);

            if (nouvelleAdresse.NombreChamps > 0)
                return nouvelleAdresse;

            return null;
        }

        private bool MettreAJourTypesPersonne(Champ indexPersonne)
        {
            LigneTable typePersonne = new LigneTable("");
            typePersonne.AjouterChamp(indexPersonne);

            RequeteSelection reqSelBeneficiaire = new RequeteSelection(NomTable.beneficiaire);
            reqSelBeneficiaire.Condition = new ConditionRequete(Operateur.EGAL, indexPersonne);

            Table beneficiaire = Global.BaseDonneesCABS.EnvoyerRequeteSelection(reqSelBeneficiaire);

            if (beneficiaire.EstVide && cbBeneficiaire.Checked)
            {
                RequeteAjout reqAjoutBeneficiaire = new RequeteAjout(NomTable.beneficiaire, typePersonne);
                if (Global.BaseDonneesCABS.EnvoyerRequeteAjout(reqAjoutBeneficiaire) < 0)
                    return false;
            }
            else if (!beneficiaire.EstVide && !cbBeneficiaire.Checked)
            {
                RequeteSuppression reqSupBeneficiaire = new RequeteSuppression(NomTable.beneficiaire, new ConditionRequete(Operateur.EGAL, indexPersonne));
                if (Global.BaseDonneesCABS.EnvoyerRequeteSuppression(reqSupBeneficiaire) < 0)
                    return false;
            }

            RequeteSelection reqSelEmploye = new RequeteSelection(NomTable.employe);
            reqSelEmploye.Condition = new ConditionRequete(Operateur.EGAL, indexPersonne);

            Table employe = Global.BaseDonneesCABS.EnvoyerRequeteSelection(reqSelEmploye);

            if (employe.EstVide && cbEmploye.Checked)
            {
                RequeteAjout reqAjoutEmploye = new RequeteAjout(NomTable.employe, typePersonne);
                if (Global.BaseDonneesCABS.EnvoyerRequeteAjout(reqAjoutEmploye) < 0)
                    return false;
            }
            else if (!employe.EstVide && !cbEmploye.Checked)
            {
                RequeteSuppression reqSupEmploye = new RequeteSuppression(NomTable.employe, new ConditionRequete(Operateur.EGAL, indexPersonne));
                if (Global.BaseDonneesCABS.EnvoyerRequeteSuppression(reqSupEmploye) < 0)
                    return false;
            }

            RequeteSelection reqSelBenevole = new RequeteSelection(NomTable.benevole);
            reqSelBenevole.Condition = new ConditionRequete(Operateur.EGAL, indexPersonne);

            Table benevole = Global.BaseDonneesCABS.EnvoyerRequeteSelection(reqSelBenevole);

            if (cbBenevole.Checked)
            {
                int temp;
                if (Int32.TryParse(txtNoCarte.Text, out temp))
                    typePersonne.AjouterChamp("benvNoCarte", temp);

                typePersonne.AjouterChamp("benvEnProbation", cbEnProbation.Checked);

                if (cbEnProbation.Checked)
                {
                    typePersonne.AjouterChamp("benvDebutProbation", dtpDebutProbation.Value.ToShortDateString());
                    typePersonne.AjouterChamp("benvFinProbation", dtpFinProbation.Value.ToShortDateString());
                }
                else
                {
                    typePersonne.AjouterChamp("benvDebutProbation", DBNull.Value);
                    typePersonne.AjouterChamp("benvFinProbation", DBNull.Value);
                }

                if (benevole.EstVide)
                {
                    RequeteAjout reqAjoutBenevole = new RequeteAjout(NomTable.benevole, typePersonne);
                    if (Global.BaseDonneesCABS.EnvoyerRequeteAjout(reqAjoutBenevole) < 0)
                        return false;
                }
                else
                {
                    RequeteModification reqModifBenevole = new RequeteModification(NomTable.benevole, new ConditionRequete(Operateur.EGAL, indexPersonne), typePersonne);
                    if (Global.BaseDonneesCABS.EnvoyerRequeteModification(reqModifBenevole) < 0)
                        return false;
                }
            }
            else if (!benevole.EstVide)
            {
                RequeteSuppression reqSupBenevole = new RequeteSuppression(NomTable.benevole, new ConditionRequete(Operateur.EGAL, indexPersonne));
                if (Global.BaseDonneesCABS.EnvoyerRequeteSuppression(reqSupBenevole) < 0)
                    return false;
            }

            return true;
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            RafraichirPersonneCourante();
        }

        private void btnUtiliserAdresse_Click(object sender, EventArgs e)
        {
            RequeteSelection reqSel = new RequeteSelection(NomTable.personne);
            reqSel.AjouterTri("perNom");
            reqSel.AjouterTri("perPrenom");
            reqSel.AjouterTri("perDateNaissance");

            Table personnes = Global.BaseDonneesCABS.EnvoyerRequeteSelection(reqSel);
            frmSelectionTable choixAdresses = new frmSelectionTable("Utiliser l'adresse d'une personne existante...", personnes, new List<string> { "perNom", "perPrenom", "perDateNaissance" }, "perId");

            if (choixAdresses.AfficherDialogue(this))
            {
                RemplirDonneesAdresse(choixAdresses.LigneChoisie);
            }
        }

        private void RafraichirPersonneCourante()
        {
            if (PersonneCourante != null)
                ChargerDonneesPersonneCourante();
            else
                Vider();

            ChangerAccesControle(ModeFormulaire.CONSULTATION);
        }

        private void ChargerDonneesPersonneCourante()
        {
            Champ indexPersonne = PersonneCourante.GetChamp("perId");

            lblDateDerniereMajValeur.Text = PersonneCourante.GetValeurChamp<DateTime>("perDateDerniereMaj").ToShortDateString();

            RequeteSelection reqSelStatut = new RequeteSelection(NomTable.statut, "staNom");
            reqSelStatut.Condition = new ConditionRequete(Operateur.EGAL, PersonneCourante.GetChamp("staId"));

            RequeteSelection reqSelBeneficiaire = new RequeteSelection(NomTable.beneficiaire);
            reqSelBeneficiaire.Condition = new ConditionRequete(Operateur.EGAL, indexPersonne);

            Table statut = Global.BaseDonneesCABS.EnvoyerRequeteSelection(reqSelStatut);
            lblStatutValeur.Text = !statut.EstVide ? statut.Lignes[0].GetValeurChamp<string>("staNom") : "";

            Table beneficiaire = Global.BaseDonneesCABS.EnvoyerRequeteSelection(reqSelBeneficiaire);
            cbBeneficiaire.Checked = !beneficiaire.EstVide;

            RequeteSelection reqSelBenevole = new RequeteSelection(NomTable.benevole);
            reqSelBenevole.Condition = new ConditionRequete(Operateur.EGAL, indexPersonne);

            Table benevole = Global.BaseDonneesCABS.EnvoyerRequeteSelection(reqSelBenevole);
            cbBenevole.Checked = !benevole.EstVide;

            if (cbBenevole.Checked)
            {
                LigneTable infosBenevole = benevole.Lignes[0];

                txtNoCarte.Text = infosBenevole.GetValeurChamp<int>("benvNoCarte").ToString();
                cbEnProbation.Checked = infosBenevole.GetValeurChamp<bool>("benvEnProbation");

                if (cbEnProbation.Checked)
                {
                    dtpDebutProbation.Value = infosBenevole.GetValeurChamp<DateTime>("benvDebutProbation");
                    dtpFinProbation.Value = infosBenevole.GetValeurChamp<DateTime>("benvFinProbation");
                }
                else
                {
                    dtpDebutProbation.Value = dtpFinProbation.Value = DateTime.Today;
                }
            }

            RequeteSelection reqSelEmploye = new RequeteSelection(NomTable.employe);
            reqSelEmploye.Condition = new ConditionRequete(Operateur.EGAL, indexPersonne);

            Table employe = Global.BaseDonneesCABS.EnvoyerRequeteSelection(reqSelEmploye);
            cbEmploye.Checked = !employe.EstVide;

            AncienIndexPersonneCouple = 0;
            ViderDonneesCouple();
            Table couple = Global.BaseDonneesCABS.EnvoyerRequeteSelectionDirect("Couple", "SELECT p.* FROM Personne p INNER JOIN Couple c ON p.perId = c.perIdDeuxieme WHERE c.perIdPremier = " + indexPersonne.Valeur + ";");

            if (!couple.EstVide)
            {
                AncienIndexPersonneCouple = couple.Lignes[0].GetValeurChamp<int>("perId");
                RemplirDonneesCouple(couple.Lignes[0]);
            }
            else
            {
                couple = Global.BaseDonneesCABS.EnvoyerRequeteSelectionDirect("Couple", "SELECT p.* FROM Personne p INNER JOIN Couple c ON p.perId = c.perIdPremier WHERE c.perIdDeuxieme = " + indexPersonne.Valeur + ";");

                if (!couple.EstVide)
                {
                    AncienIndexPersonneCouple = couple.Lignes[0].GetValeurChamp<int>("perId");
                    RemplirDonneesCouple(couple.Lignes[0]);
                }
            }

            txtNom.Text = PersonneCourante.GetValeurChamp<string>("perNom");
            txtPrenom.Text = PersonneCourante.GetValeurChamp<string>("perPrenom");
            txtCourriel.Text = PersonneCourante.GetValeurChamp<string>("perCourriel");
            mtxtTelephone1.Text = PersonneCourante.GetValeurChamp<string>("perTelephone1");
            mtxtTelephone2.Text = PersonneCourante.GetValeurChamp<string>("perTelephone2");
            mtxtTelephone3.Text = PersonneCourante.GetValeurChamp<string>("perTelephone3");
            txtCommentaires.Text = PersonneCourante.GetValeurChamp<string>("perCommentaires");

            if (PersonneCourante.GetValeurChamp<bool>("perSexe"))
                rbSexeF.Checked = true;
            else
                rbSexeM.Checked = true;

            if (PersonneCourante.GetValeurChamp<bool>("perFumeur"))
                rbFumeurOui.Checked = true;
            else
                rbFumeurNon.Checked = true;

            foreach (ComboBoxItem etat in cmbEtatCivil.Items)
            {
                if (((int)etat.Value) == PersonneCourante.GetValeurChamp<int>("etaId"))
                {
                    cmbEtatCivil.SelectedItem = etat;
                    break;
                }
            }

            if (cbEchoBenevole.Checked = PersonneCourante.GetValeurChamp<bool>("perInfoCAB"))
                cbParCourriel.Checked = PersonneCourante.GetValeurChamp<bool>("perInfoCABCourriel");

            dtpDateNaissance.Value = PersonneCourante.GetValeurChamp<DateTime>("perDateNaissance");

            foreach (int indexLangue in chklbLangues.CheckedIndices)
                chklbLangues.SetItemChecked(indexLangue, false);

            RequeteSelection reqSel = new RequeteSelection(NomTable.languepersonne);
            reqSel.Condition = new ConditionRequete(Operateur.EGAL, PersonneCourante.GetChamp("perId"));

            Table langues = Global.BaseDonneesCABS.EnvoyerRequeteSelection(reqSel);

            foreach (LigneTable langue in langues.Lignes)
            {
                for(int i=0; i<chklbLangues.Items.Count; ++i)
                {
                    if(((int)(chklbLangues.Items[i] as ComboBoxItem).Value) == langue.GetValeurChamp<int>("lanId"))
                        chklbLangues.SetItemChecked(i, true);
                }
            }

            lbServicesInscrits.Items.Clear();
            Services = Global.BaseDonneesCABS.EnvoyerRequeteSelectionDirect("Service", String.Format(FORMAT_REQ_SERVICES, indexPersonne.ValeurSQL));
            Services.Lignes.ForEach(l => lbServicesInscrits.Items.Add(l.GetValeurChamp<string>("serNom")));

            RemplirDonneesAdresse(PersonneCourante);
        }

        private void RemplirDonneesCouple(LigneTable personneCouple)
        {
            PersonneCouple = personneCouple;
            IndexPersonneCouple = personneCouple.GetValeurChamp<int>("perId");
            lblNomCouple.Text = personneCouple.GetValeurChamp<string>("perNom");
            lblPrenomCouple.Text = personneCouple.GetValeurChamp<string>("perPrenom");
        }

        private void ViderDonneesCouple()
        {
            PersonneCouple = null;
            IndexPersonneCouple = 0;
            lblNomCouple.ResetText();
            lblPrenomCouple.ResetText();
        }

        private void RemplirDonneesAdresse(LigneTable personne)
        {
            txtNoCivique.Text = personne.GetValeurChamp<int>("perNoCivique").ToString();
            txtNoAppart.Text = personne.GetValeurChamp<string>("perNoAppart");
            txtRue.Text = personne.GetValeurChamp<string>("perRue");
            txtVille.Text = personne.GetValeurChamp<string>("perVille");
            mtxtCodePostal.Text = personne.GetValeurChamp<string>("perCodePostal");

            int casePostale = personne.GetValeurChamp<int>("perCasePostale");

            if (casePostale != 0)
                txtCasePostale.Text = casePostale.ToString();
            else
                txtCasePostale.ResetText();
        }

        public override void ChangerAccesControle(ModeFormulaire mode)
        {
            base.ChangerAccesControle(mode);

            txtNom.Enabled = txtPrenom.Enabled = txtCourriel.Enabled = txtCommentaires.Enabled =
            mtxtTelephone1.Enabled = mtxtTelephone2.Enabled = mtxtTelephone3.Enabled =
            gbCouple.Enabled = gbSexe.Enabled = gbFumeur.Enabled = gbAdresse.Enabled = gbTypesPersonne.Enabled =
            cmbEtatCivil.Enabled =
            chklbLangues.Enabled =
            cbEchoBenevole.Enabled =
            dtpDateNaissance.Enabled =
            btnConfirmer.Enabled = btnAnnuler.Enabled =
            Mode == ModeFormulaire.AJOUT || Mode == ModeFormulaire.EDITION;

            txtNoCarte.Enabled = cbEnProbation.Enabled = cbBenevole.Enabled && cbBenevole.Checked;
            dtpDebutProbation.Enabled = dtpFinProbation.Enabled = cbBenevole.Enabled && cbBenevole.Checked && cbEnProbation.Checked;
            cbParCourriel.Enabled = cbEchoBenevole.Enabled && cbEchoBenevole.Checked;

            btnNouveau.Enabled = btnRechercher.Enabled = Mode == ModeFormulaire.CONSULTATION;

            btnARejoindre.Enabled = btnDossier.Enabled = btnModifier.Enabled = btnSupprimer.Enabled = btnImprimer.Enabled = (Mode == ModeFormulaire.CONSULTATION) && PersonneCourante != null;
            btnInscriptionServices.Enabled = (Mode == ModeFormulaire.CONSULTATION) && PersonneCourante != null && cbBeneficiaire.Checked && PersonneCourante.GetValeurChamp<int>("staId") == (int)StatutActif.Valeur;
        }

        private void btnARejoindre_Click(object sender, EventArgs e)
        {
            if (ParentForm is frmPrincipal)
                ((frmPrincipal)ParentForm).ChangerFormulaire("CABS.Formulaires.frmPersonnesARejoindre", PersonneCourante);
        }

        private void btnDossier_Click(object sender, EventArgs e)
        {
            if (ParentForm is frmPrincipal)
                ((frmPrincipal)ParentForm).ChangerFormulaire("CABS.Formulaires.frmGestionDossiers", PersonneCourante);
        }

        private void btnInscriptionServices_Click(object sender, EventArgs e)
        {
            if (ParentForm is frmPrincipal)
                ((frmPrincipal)ParentForm).ChangerFormulaire("CABS.Formulaires.Inscription.frmInscriptionServicesBeneficiaires", PersonneCourante);
        }

        private void btnImprimer_Click(object sender, EventArgs e)
        {
            Gabarit fiche = new Gabarit(Global.GetConfiguration<string>("GABARIT_FICHE"));
            LigneTable copie = new LigneTable(PersonneCourante);

            //Sexe
            bool sexe = PersonneCourante.GetValeurChamp<bool>("perSexe");
            copie.AjouterChamp("perMasculin", sexe == false);
            copie.AjouterChamp("perFeminin", sexe == true);

            //Langues
            int indexPersonne = PersonneCourante.GetValeurChamp<int>("perId");
            Table francais = Global.BaseDonneesCABS.EnvoyerRequeteSelectionDirect("langue", String.Format(FORMAT_REQ_LANGUE, indexPersonne, "Français"));
            Table anglais = Global.BaseDonneesCABS.EnvoyerRequeteSelectionDirect("langue", String.Format(FORMAT_REQ_LANGUE, indexPersonne, "Anglais"));
            copie.AjouterChamp("perFrancais", !francais.EstVide);
            copie.AjouterChamp("perAnglais", !anglais.EstVide);

            if (PersonneCouple != null)
            {
                copie.AjouterChamp("perNomConjoint", PersonneCouple.GetValeurChamp<string>("perNom"));
                copie.AjouterChamp("perPrenomConjoint", PersonneCouple.GetValeurChamp<string>("perPrenom"));

                //Sexe conjoint
                sexe = PersonneCouple.GetValeurChamp<bool>("perSexe");
                copie.AjouterChamp("perMasculinConjoint", sexe == false);
                copie.AjouterChamp("perFemininConjoint", sexe == true);

                copie.AjouterChamp("perDateNaissanceConj", PersonneCouple.GetValeurChamp<DateTime>("perDateNaissance"));

                //Langues conjoint
                indexPersonne = PersonneCouple.GetValeurChamp<int>("perId");
                francais = Global.BaseDonneesCABS.EnvoyerRequeteSelectionDirect("langue", String.Format(FORMAT_REQ_LANGUE, indexPersonne, "Français"));
                anglais = Global.BaseDonneesCABS.EnvoyerRequeteSelectionDirect("langue", String.Format(FORMAT_REQ_LANGUE, indexPersonne, "Anglais"));
                copie.AjouterChamp("perFrancaisConjoint", !francais.EstVide);
                copie.AjouterChamp("perAnglaisConjoint", !anglais.EstVide);
            }

            //Personnes à rejoindre
            RequeteSelection reqSel = new RequeteSelection(NomTable.arejoindre);
            reqSel.Condition = new ConditionRequete(Operateur.EGAL, PersonneCourante.GetChamp("perId"));

            Table personnesARejoindre = Global.BaseDonneesCABS.EnvoyerRequeteSelection(reqSel);

            if(!personnesARejoindre.EstVide)
            {
                LigneTable personneARejoindre = personnesARejoindre.Lignes[0];
                string nom = personneARejoindre.GetValeurChamp<string>("arjPrenom") + " " + personneARejoindre.GetValeurChamp<string>("arjNom");

                copie.AjouterChamp("perNomRej1", nom);
                copie.AjouterChamp("perLienRej1", personneARejoindre.GetValeurChamp<string>("arjLien"));
                copie.AjouterChamp("perTelephoneRej1", personneARejoindre.GetValeurChamp<string>("arjTelephone"));

                if(personnesARejoindre.NombreLignes > 1)
                {
                    personneARejoindre = personnesARejoindre.Lignes[1];
                    nom = personneARejoindre.GetValeurChamp<string>("arjPrenom") + " " + personneARejoindre.GetValeurChamp<string>("arjNom");

                    copie.AjouterChamp("perNomRej2", nom);
                    copie.AjouterChamp("perLienRej2", personneARejoindre.GetValeurChamp<string>("arjLien"));
                    copie.AjouterChamp("perTelephoneRej2", personneARejoindre.GetValeurChamp<string>("arjTelephone"));
                }
            }

            //Services
            string servicesInscrits = "";

            if (Services != null && !Services.EstVide)
            {
                servicesInscrits = Services.Lignes[0].GetValeurChamp<string>("serNom");

                for (int i = 1; i < Services.NombreLignes; ++i)
                {
                    servicesInscrits += "\n" + Services.Lignes[i].GetValeurChamp<string>("serNom");
                }
            }

            copie.AjouterChamp("perServices", servicesInscrits);

            fiche.Generer(copie);
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