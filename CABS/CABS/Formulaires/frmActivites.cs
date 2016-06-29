using CABS.BaseDonnees;
using CABS.Outils;
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
    public partial class frmActivites : Formulaire
    {
        private int DernierIndexChamp;
        private int DernierIndexSousChamp;
        private int DernierIndexActivite;

        public frmActivites()
            : base(true, true)
        {
            InitializeComponent();

            DernierIndexChamp = DernierIndexSousChamp = DernierIndexActivite = -1;
        }

        public override void EntrerPage()
        {
            base.EntrerPage();

            Table champs = Global.BaseDonneesCABS.EnvoyerRequeteSelection(new RequeteSelection(NomTable.champactivite));
            List<ComboBoxItem> listeChamps = new List<ComboBoxItem>();

            champs.Lignes.ForEach(l => listeChamps.Add(new ComboBoxItem(l.GetValeurChamp<string>("chaNom"), l.GetChamp("chaId"))));
            MettreAJourListe(lbChamps, listeChamps);
        }

        private void lbChamps_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbChamps.SelectedIndex == DernierIndexChamp)
                return;

            DernierIndexChamp = lbChamps.SelectedIndex;

            bool champSelectionne = DernierIndexChamp != -1;
            btnModifierChamp.Enabled = champSelectionne && txtNomChamp.TextLength > 0;
            btnSupprimerChamp.Enabled = champSelectionne;
            btnAjouterSousChamp.Enabled = lbChamps.SelectedIndex != -1 && txtNomSousChamp.TextLength > 0;

            List<ComboBoxItem> listeSousChamps = (List<ComboBoxItem>)lbSousChamps.DataSource;

            if (listeSousChamps != null)
                listeSousChamps.Clear();
            else
                listeSousChamps = new List<ComboBoxItem>();

            if (champSelectionne)
            {
                RequeteSelection reqSel = new RequeteSelection(NomTable.souschampactivite);
                reqSel.Condition = new ConditionRequete(Operateur.EGAL, ((Champ)((ComboBoxItem)lbChamps.SelectedItem).Value));

                Table sousChamps = Global.BaseDonneesCABS.EnvoyerRequeteSelection(reqSel);
                sousChamps.Lignes.ForEach(l => listeSousChamps.Add(new ComboBoxItem(l.GetValeurChamp<string>("scaNom"), l.GetChamp("scaId"))));
            }

            MettreAJourListe(lbSousChamps, listeSousChamps);
        }

        private void lbSousChamps_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbSousChamps.SelectedIndex == DernierIndexSousChamp)
                return;

            DernierIndexSousChamp = lbSousChamps.SelectedIndex;

            bool sousChampSelectionne = DernierIndexSousChamp != -1;
            btnModifierSousChamp.Enabled = sousChampSelectionne && txtNomSousChamp.TextLength > 0;
            btnSupprimerSousChamp.Enabled = sousChampSelectionne;
            btnAjouterActivite.Enabled = lbSousChamps.SelectedIndex != -1 && txtNomActivite.TextLength > 0;

            List<ComboBoxItem> listeActivites = (List<ComboBoxItem>)lbActivites.DataSource;

            if (listeActivites != null)
                listeActivites.Clear();
            else
                listeActivites = new List<ComboBoxItem>();

            if (sousChampSelectionne)
            {
                RequeteSelection reqSel = new RequeteSelection(NomTable.activite);
                reqSel.Condition = new ConditionRequete(Operateur.EGAL, ((Champ)((ComboBoxItem)lbSousChamps.SelectedItem).Value));

                Table activites = Global.BaseDonneesCABS.EnvoyerRequeteSelection(reqSel);
                activites.Lignes.ForEach(l => listeActivites.Add(new ComboBoxItem(l.GetValeurChamp<string>("actNom"), l.GetChamp("actId"))));
            }

            MettreAJourListe(lbActivites, listeActivites);
        }

        private void lbActivites_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbActivites.SelectedIndex == DernierIndexActivite)
                return;

            DernierIndexActivite = lbActivites.SelectedIndex;

            bool activiteSelectionne = DernierIndexActivite != -1;
            btnModifierActivite.Enabled = activiteSelectionne && txtNomActivite.TextLength > 0;
            btnSupprimerActivite.Enabled = activiteSelectionne;
        }

        private void txtNomChamp_TextChanged(object sender, EventArgs e)
        {
            bool nomEntre = txtNomChamp.TextLength > 0;
            btnAjouterChamp.Enabled = nomEntre;
            btnModifierChamp.Enabled = lbChamps.SelectedIndex != -1 && nomEntre;
        }

        private void txtNomSousChamp_TextChanged(object sender, EventArgs e)
        {
            bool nomEntre = txtNomSousChamp.TextLength > 0;
            btnAjouterSousChamp.Enabled = lbChamps.SelectedIndex != -1 && nomEntre;
            btnModifierSousChamp.Enabled = lbSousChamps.SelectedIndex != -1 && nomEntre;
        }

        private void txtNomActivite_TextChanged(object sender, EventArgs e)
        {
            bool nomEntre = txtNomActivite.TextLength > 0;
            btnAjouterActivite.Enabled = lbSousChamps.SelectedIndex != -1 && nomEntre;
            btnModifierActivite.Enabled = lbActivites.SelectedIndex != -1 && nomEntre;
        }

        private void btnAjouterChamp_Click(object sender, EventArgs e)
        {
            RequeteAjout reqAjout = new RequeteAjout(NomTable.champactivite, new Champ("champactivite", "chaNom", txtNomChamp.Text));
            int nouvelIndex;

            if ((nouvelIndex = Global.BaseDonneesCABS.EnvoyerRequeteAjout(reqAjout)) < 0)
            {
                Journal.AfficherMessage("Une erreur est survenue lors de l'ajout du champ d'activités. L'action a été annulée.", TypeMessage.ERREUR, true);
                return;
            }

            AjouterItem(lbChamps, new ComboBoxItem(txtNomChamp.Text, new Champ("champactivite", "chaId", nouvelIndex)));
            txtNomChamp.ResetText();
        }

        private void btnModifierChamp_Click(object sender, EventArgs e)
        {
            RequeteModification reqModif = new RequeteModification(NomTable.champactivite,
                                                                   new ConditionRequete(Operateur.EGAL, ((Champ)((ComboBoxItem)lbChamps.SelectedItem).Value)),
                                                                   new Champ("champactivite", "chaNom", txtNomChamp.Text));

            if (Global.BaseDonneesCABS.EnvoyerRequeteModification(reqModif) < 0)
            {
                Journal.AfficherMessage("Une erreur est survenue lors de la modification du champ d'activités. L'action a été annulée.", TypeMessage.ERREUR, true);
                return;
            }

            ModifierItem(lbChamps, txtNomChamp.Text);
            txtNomChamp.ResetText();
        }

        private void btnSupprimerChamp_Click(object sender, EventArgs e)
        {
            if (!OutilsForms.PoserQuestion("Confirmation de suppression", "Voulez-vous vraiment supprimer ce champ? Tous les sous-champs et activités reliés à ce champ vont être également supprimés."))
                return;

            RequeteSuppression reqSup = new RequeteSuppression(NomTable.champactivite, new ConditionRequete(Operateur.EGAL, ((Champ)((ComboBoxItem)lbChamps.SelectedItem).Value)));

            if (Global.BaseDonneesCABS.EnvoyerRequeteSuppression(reqSup) < 0)
            {
                Journal.AfficherMessage("Une erreur est survenue lors de la suppression du champ d'activités. L'action a été annulée.", TypeMessage.ERREUR, true);
                return;
            }

            SupprimerItem(lbChamps);
        }

        private void btnAjouterSousChamp_Click(object sender, EventArgs e)
        {
            RequeteAjout reqAjout = new RequeteAjout(NomTable.souschampactivite, new Champ("souschampactivite", "scaNom", txtNomSousChamp.Text), ((Champ)((ComboBoxItem)lbChamps.SelectedItem).Value));
            int nouvelIndex;

            if ((nouvelIndex = Global.BaseDonneesCABS.EnvoyerRequeteAjout(reqAjout)) < 0)
            {
                Journal.AfficherMessage("Une erreur est survenue lors de l'ajout du sous-champ d'activités. L'action a été annulée.", TypeMessage.ERREUR, true);
                return;
            }

            AjouterItem(lbSousChamps, new ComboBoxItem(txtNomSousChamp.Text, new Champ("souschampactivite", "scaId", nouvelIndex)));
            txtNomSousChamp.ResetText();
        }

        private void btnModifierSousChamp_Click(object sender, EventArgs e)
        {
            RequeteModification reqModif = new RequeteModification(NomTable.souschampactivite,
                                                                   new ConditionRequete(Operateur.EGAL, ((Champ)((ComboBoxItem)lbSousChamps.SelectedItem).Value)),
                                                                   new Champ("souschampactivite", "scaNom", txtNomSousChamp.Text));

            if (Global.BaseDonneesCABS.EnvoyerRequeteModification(reqModif) < 0)
            {
                Journal.AfficherMessage("Une erreur est survenue lors de la modification du sous-champ d'activités. L'action a été annulée.", TypeMessage.ERREUR, true);
                return;
            }

            ModifierItem(lbSousChamps, txtNomSousChamp.Text);
            txtNomSousChamp.ResetText();
        }

        private void btnSupprimerSousChamp_Click(object sender, EventArgs e)
        {
            if (!OutilsForms.PoserQuestion("Confirmation de suppression", "Voulez-vous vraiment supprimer ce sous-champ? Toutes les activités reliées à ce sous-champ vont être également supprimées."))
                return;

            RequeteSuppression reqSup = new RequeteSuppression(NomTable.souschampactivite, new ConditionRequete(Operateur.EGAL, ((Champ)((ComboBoxItem)lbSousChamps.SelectedItem).Value)));

            if (Global.BaseDonneesCABS.EnvoyerRequeteSuppression(reqSup) < 0)
            {
                Journal.AfficherMessage("Une erreur est survenue lors de la suppression du sous-champ d'activités. L'action a été annulée.", TypeMessage.ERREUR, true);
                return;
            }

            SupprimerItem(lbSousChamps);
        }

        private void btnAjouterActivite_Click(object sender, EventArgs e)
        {
            RequeteAjout reqAjout = new RequeteAjout(NomTable.activite, new Champ("activite", "actNom", txtNomActivite.Text), ((Champ)((ComboBoxItem)lbSousChamps.SelectedItem).Value));
            int nouvelIndex;

            if ((nouvelIndex = Global.BaseDonneesCABS.EnvoyerRequeteAjout(reqAjout)) < 0)
            {
                Journal.AfficherMessage("Une erreur est survenue lors de l'ajout de l'activité. L'action a été annulée.", TypeMessage.ERREUR, true);
                return;
            }

            AjouterItem(lbActivites, new ComboBoxItem(txtNomActivite.Text, new Champ("activite", "actId", nouvelIndex)));
            txtNomActivite.ResetText();
        }

        private void btnModifierActivite_Click(object sender, EventArgs e)
        {
            RequeteModification reqModif = new RequeteModification(NomTable.activite,
                                                                   new ConditionRequete(Operateur.EGAL, ((Champ)((ComboBoxItem)lbActivites.SelectedItem).Value)),
                                                                   new Champ("activite", "actNom", txtNomActivite.Text));

            if (Global.BaseDonneesCABS.EnvoyerRequeteModification(reqModif) < 0)
            {
                Journal.AfficherMessage("Une erreur est survenue lors de la modification de l'activité. L'action a été annulée.", TypeMessage.ERREUR, true);
                return;
            }

            ModifierItem(lbActivites, txtNomActivite.Text);
            txtNomActivite.ResetText();
        }

        private void btnSupprimerActivite_Click(object sender, EventArgs e)
        {
            if (!OutilsForms.PoserQuestion("Confirmation de suppression", "Voulez-vous vraiment supprimer cette activité?"))
                return;

            RequeteSuppression reqSup = new RequeteSuppression(NomTable.activite, new ConditionRequete(Operateur.EGAL, ((Champ)((ComboBoxItem)lbActivites.SelectedItem).Value)));

            if (Global.BaseDonneesCABS.EnvoyerRequeteSuppression(reqSup) < 0)
            {
                Journal.AfficherMessage("Une erreur est survenue lors de la suppression de l'activité. L'action a été annulée.", TypeMessage.ERREUR, true);
                return;
            }

            SupprimerItem(lbActivites);
        }

        private void AjouterItem(ListBox liste, ComboBoxItem nouvelItem)
        {
            List<ComboBoxItem> dataSource = (List<ComboBoxItem>)liste.DataSource;

            if (dataSource == null)
                dataSource = new List<ComboBoxItem>();

            dataSource.Add(nouvelItem);
            MettreAJourListe(liste, dataSource);
        }

        private void ModifierItem(ListBox liste, string nouveauTexte)
        {
            List<ComboBoxItem> dataSource = (List<ComboBoxItem>)liste.DataSource;

            if (dataSource == null)
                return;

            dataSource[liste.SelectedIndex].Text = nouveauTexte;
            MettreAJourListe(liste, dataSource);
        }

        private void SupprimerItem(ListBox liste)
        {
            List<ComboBoxItem> dataSource = (List<ComboBoxItem>)liste.DataSource;

            if (dataSource == null)
                return;

            dataSource.RemoveAt(liste.SelectedIndex);
            MettreAJourListe(liste, dataSource);
        }

        private void MettreAJourListe(ListBox liste, List<ComboBoxItem> items)
        {
            liste.DataSource = null;
            liste.DataSource = items;
        }
    }
}
