using CABS.BaseDonnees;
using CABS.Outils;
using JThomas.Controls;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CABS.Formulaires
{
    public partial class frmPersonnesARejoindre : Formulaire
    {
        private bool LigneAjoutee;
        private bool LigneModifiee;

        private LigneTable PersonneCourante;
        private List<LigneTable> PersonnesARejoindreASupprimer;

        public frmPersonnesARejoindre()
            : base(true, true)
        {
            InitializeComponent();

            LigneAjoutee = LigneModifiee = false;

            PersonneCourante = null;
            PersonnesARejoindreASupprimer = new List<LigneTable>();
        }

        public override void EntrerPage()
        {
            base.EntrerPage();

            if (PersonneCourante != null)
                ChargerPersonnesARejoindre();
        }

        private void btnChoisirPersonne_Click(object sender, EventArgs e)
        {
            RequeteSelection reqSel = new RequeteSelection(NomTable.personne);
            reqSel.AjouterTri("perNom");
            reqSel.AjouterTri("perPrenom");
            reqSel.AjouterTri("perDateNaissance");

            Table personnes = Global.BaseDonneesCABS.EnvoyerRequeteSelection(reqSel);
            frmSelectionTable choixPersonne = new frmSelectionTable("Choisir une personne...", personnes, new List<string> { "perNom", "perPrenom", "perDateNaissance" }, "perId");

            if (choixPersonne.AfficherDialogue(this) && choixPersonne.LigneChoisie != null)
            {
                PersonneCourante = choixPersonne.LigneChoisie;
                ChargerPersonnesARejoindre();
            }
        }

        public override void EnvoyerMessages(params object[] messages)
        {
            if (messages.Length == 1 && messages[0] is LigneTable)
            {
                PersonneCourante = (LigneTable)messages[0];
                ChargerPersonnesARejoindre();
            }
        }

        private void ChargerPersonnesARejoindre()
        {
            lblPrenomValeur.Text = PersonneCourante.GetValeurChamp<string>("perPrenom");
            lblNomValeur.Text = PersonneCourante.GetValeurChamp<string>("perNom");

            dgvPersonnesARejoindre.Rows.Clear();
            PersonnesARejoindreASupprimer.Clear();

            btnEnregistrer.Enabled = btnAnnuler.Enabled = false;

            RequeteSelection reqSel = new RequeteSelection(NomTable.arejoindre);
            reqSel.Condition = new ConditionRequete(Operateur.EGAL, "perId", PersonneCourante.GetChamp("perId").ValeurSQL);

            Table personnesARejoindre = Global.BaseDonneesCABS.EnvoyerRequeteSelection(reqSel);

            foreach (LigneTable persARej in personnesARejoindre.Lignes)
                AjouterPersonnesARejoindre(persARej);
        }

        private void AjouterPersonnesARejoindre(LigneTable persARej)
        {
            dgvPersonnesARejoindre.Rows.Add(persARej.GetValeurChamp<int>("arjId"),
                                            persARej.GetValeurChamp<string>("arjPrenom"),
                                            persARej.GetValeurChamp<string>("arjNom"),
                                            persARej.GetValeurChamp<string>("arjLien"),
                                            persARej.GetValeurChamp<string>("arjTelephone"));
        }

        private void btnVider_Click(object sender, EventArgs e)
        {
            if (PersonneCourante == null ||
                dgvPersonnesARejoindre.Rows.Count <= 1 ||
                !OutilsForms.PoserQuestion("Confirmation", "Voulez-vous vraiment supprimer toutes les personnes à rejoindre?"))
            {
                return;
            }

            for (int i = 0; i < dgvPersonnesARejoindre.Rows.Count - 1; ++i)
                if (dgvPersonnesARejoindre.Rows[i].Cells["Id"].Value != null)
                    PersonnesARejoindreASupprimer.Add(CreerNouvellePersonneARejoindre(i));

            dgvPersonnesARejoindre.Rows.Clear();
            btnEnregistrer.Enabled = btnAnnuler.Enabled = true;
        }

        private void dgvPersonnesARejoindre_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (PersonneCourante == null)
            {
                dgvPersonnesARejoindre.Rows.Clear();
                return;
            }

            btnEnregistrer.Enabled = btnAnnuler.Enabled = true;
            dgvPersonnesARejoindre.Rows[e.Row.Index - 1].Tag = ModeFormulaire.AJOUT;
        }

        private void dgvPersonnesARejoindre_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (PersonneCourante == null)
                return;

            btnEnregistrer.Enabled = btnAnnuler.Enabled = true;
            object valeurTag = dgvPersonnesARejoindre.Rows[e.RowIndex].Tag;

            if (!(valeurTag is ModeFormulaire) ||
                (ModeFormulaire)valeurTag != ModeFormulaire.AJOUT)
                dgvPersonnesARejoindre.Rows[e.RowIndex].Tag = ModeFormulaire.EDITION;
        }

        private LigneTable CreerNouvellePersonneARejoindre(int indexLigne)
        {
            DataGridViewRow ligneCourante = dgvPersonnesARejoindre.Rows[indexLigne];

            LigneTable personneARejoindreCourante = new LigneTable("ARejoindre");
            object index = ligneCourante.Cells["Id"].Value;

            if (index != null)
                personneARejoindreCourante.AjouterChamp("arjId", (int)index);

            personneARejoindreCourante.AjouterChamp("arjNom", ligneCourante.Cells["Nom"].Value);
            personneARejoindreCourante.AjouterChamp("arjPrenom", ligneCourante.Cells["Prenom"].Value);
            personneARejoindreCourante.AjouterChamp("arjLien", ligneCourante.Cells["Lien"].Value);
            personneARejoindreCourante.AjouterChamp("arjTelephone", ((DataGridViewMaskedTextCell)ligneCourante.Cells["Telephone"]).ValueWithoutMask);

            personneARejoindreCourante.AjouterChamp("perId", PersonneCourante.GetValeurChamp<int>("perId"));

            return personneARejoindreCourante;
        }

        private void dgvPersonnesARejoindre_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (PersonneCourante == null || !OutilsForms.PoserQuestion("Confirmation", "Voulez-vous vraiment supprimer cette personne à rejoindre?"))
            {
                e.Cancel = true;
                return;
            }

            btnEnregistrer.Enabled = btnAnnuler.Enabled = true;
            PersonnesARejoindreASupprimer.Add(CreerNouvellePersonneARejoindre(e.Row.Index));
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            int temp;
            bool erreur = false;

            for (int i = 0; i < dgvPersonnesARejoindre.Rows.Count - 1; ++i)
            {
                DataGridViewRow ligne = dgvPersonnesARejoindre.Rows[i];
                ligne.ErrorText = "";

                if (!(ligne.Tag is ModeFormulaire))
                    continue;

                if (!ValiderLigne(ligne))
                {
                    erreur = true;
                    continue;
                }

                LigneTable personneARejoindre = CreerNouvellePersonneARejoindre(ligne.Index);

                if ((ModeFormulaire)ligne.Tag == ModeFormulaire.AJOUT)
                {
                    RequeteAjout reqAjout = new RequeteAjout(NomTable.arejoindre, personneARejoindre);
                    if ((temp = Global.BaseDonneesCABS.EnvoyerRequeteAjout(reqAjout)) == -1)
                    {
                        ligne.ErrorText = "Une erreur est survenue lors de l'ajout de cette personne à rejoindre.";
                        erreur = true;
                        continue;
                    }

                    ligne.Cells["Id"].Value = temp;
                }
                else if ((ModeFormulaire)ligne.Tag == ModeFormulaire.EDITION)
                {
                    RequeteModification reqModif = new RequeteModification(NomTable.arejoindre, new ConditionRequete(Operateur.EGAL, personneARejoindre.GetChamp("arjId")), personneARejoindre);
                    if ((temp = Global.BaseDonneesCABS.EnvoyerRequeteModification(reqModif)) <= 0)
                    {
                        ligne.ErrorText = "Une erreur est survenue lors de la modification de cette personne à rejoindre.";
                        erreur = true;
                        continue;
                    }
                }
            }

            foreach (LigneTable ligne in PersonnesARejoindreASupprimer)
            {
                RequeteSuppression reqSup = new RequeteSuppression(NomTable.arejoindre, new ConditionRequete(Operateur.EGAL, ligne.GetChamp("arjId")));

                if ((temp = Global.BaseDonneesCABS.EnvoyerRequeteSuppression(reqSup)) <= 0)
                {
                    AjouterPersonnesARejoindre(ligne);
                    dgvPersonnesARejoindre.Rows[dgvPersonnesARejoindre.Rows.Count - 2].ErrorText = "Une erreur est survenue lors de la suppression de cette personne à rejoindre.";
                    erreur = true;
                }
            }

            PersonnesARejoindreASupprimer.Clear();

            if (!erreur)
                btnEnregistrer.Enabled = btnAnnuler.Enabled = false;
        }

        private bool ValiderLigne(DataGridViewRow ligne)
        {
            if (ligne.Cells["Prenom"].Value == null ||  //Utiliser VerifierCondition
               ligne.Cells["Nom"].Value == null ||
               ligne.Cells["Lien"].Value == null ||
               ((DataGridViewMaskedTextCell)ligne.Cells["Telephone"]).ValueWithoutMask == null)
            {
                ligne.ErrorText = "Certains champs ne sont pas spécifiés. Cette ligne n'a pas été enregistrée.";
                return false;
            }

            return true;
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            if (PersonneCourante != null)
                ChargerPersonnesARejoindre();

            btnEnregistrer.Enabled = btnAnnuler.Enabled = false;
        }

        public override bool QuitterPage()
        {
            if (!base.QuitterPage())
                return false;

            if (LigneAjoutee || LigneModifiee)
            {
                return OutilsForms.PoserQuestion("Confirmation", "Une ou plusieurs personnes à rejoindre n'ont pas été enregistrées et seront perdues. Voulez-vous vraiment quitter sans enregistrer?");
            }

            return true;
        }
    }
}