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
    public partial class frmReunions : Formulaire
    {
        private const string REQUETE_PERSONNES = "SELECT p.perId, p.perNom, p.perPrenom, p.perDateNaissance FROM personne p INNER JOIN {0} x ON x.perId = p.perId ORDER BY p.perNom, p.perPrenom, p.perDateNaissance;";
        private const string REQUETE_BENEVOLES_INCLUS = "SELECT p.perId, p.perNom, p.perPrenom, b.benrHeures FROM personne p INNER JOIN benevolereunion b ON b.perId = p.perId WHERE b.reuId = {0} ORDER BY p.perNom, p.perPrenom, p.perDateNaissance, b.benrHeures;";
        private const string REQUETE_EMPLOYES_INCLUS = "SELECT p.perId, p.perNom, p.perPrenom, e.erHeures FROM personne p INNER JOIN employereunion e ON e.perId = p.perId WHERE e.reuId = {0} ORDER BY p.perNom, p.perPrenom, p.perDateNaissance, e.erHeures;";
        private const string FORMAT_REUNION = "{0} - {1}";
        private const string FORMAT_PERSONNES_INCLUS = "{0}, {1} - {2} heure(s)";
        private List<string> CHAMPS_PERSONNES_AFFICHES = new List<string>(new string[] { "perNom", "perPrenom", "perDateNaissance" });

        private bool RafraichissementReunionActive;

        private int DernierIndexChamp;
        private int DernierIndexSousChamp;
        private int DernierIndexActivite;
        private int DernierIndexReunion;

        public frmReunions()
            : base(true, true)
        {
            InitializeComponent();

            RafraichissementReunionActive = true;
            DernierIndexChamp = DernierIndexSousChamp = DernierIndexActivite = DernierIndexReunion = -1;
        }

        public override void EntrerPage()
        {
            base.EntrerPage();

            cmbChamp.SelectedIndex = -1;
            cmbChamp.Items.Clear();

            Table champs = Global.BaseDonneesCABS.EnvoyerRequeteSelection(new RequeteSelection(NomTable.champactivite));
            champs.Lignes.ForEach(l => cmbChamp.Items.Add(new ComboBoxItem(l.GetValeurChamp<string>("chaNom"), l.GetChamp("chaId"))));

            if (cmbChamp.Items.Count > 0)
                cmbChamp.SelectedIndex = 0;

            Table benevoles = Global.BaseDonneesCABS.EnvoyerRequeteSelectionDirect("personne", String.Format(REQUETE_PERSONNES, "benevole"));
            gtBenevoles.Rafraichir(benevoles, CHAMPS_PERSONNES_AFFICHES);

            Table beneficaires = Global.BaseDonneesCABS.EnvoyerRequeteSelectionDirect("personne", String.Format(REQUETE_PERSONNES, "employe"));
            gtEmployes.Rafraichir(beneficaires, CHAMPS_PERSONNES_AFFICHES);

            ChangerAccesControle(Mode);
        }

        private void cmbChamp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbChamp.SelectedIndex == DernierIndexChamp)
                return;

            DernierIndexChamp = cmbChamp.SelectedIndex;

            cmbSousChamp.SelectedIndex = -1;
            cmbSousChamp.Items.Clear();

            if (cmbChamp.SelectedIndex == -1)
                return;

            RequeteSelection reqSel = new RequeteSelection(NomTable.souschampactivite);
            reqSel.Condition = new ConditionRequete(Operateur.EGAL, ((Champ)((ComboBoxItem)cmbChamp.SelectedItem).Value));

            Table sousChamps = Global.BaseDonneesCABS.EnvoyerRequeteSelection(reqSel);
            sousChamps.Lignes.ForEach(l => cmbSousChamp.Items.Add(new ComboBoxItem(l.GetValeurChamp<string>("scaNom"), l.GetChamp("scaId"))));

            if (cmbSousChamp.Items.Count > 0)
                cmbSousChamp.SelectedIndex = 0;

            ChangerAccesControle(Mode);
        }

        private void cmbSousChamp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSousChamp.SelectedIndex == DernierIndexSousChamp)
                return;

            DernierIndexSousChamp = cmbSousChamp.SelectedIndex;

            cmbActivite.SelectedIndex = -1;
            cmbActivite.Items.Clear();

            if (cmbSousChamp.SelectedIndex == -1)
                return;

            RequeteSelection reqSel = new RequeteSelection(NomTable.activite);
            reqSel.Condition = new ConditionRequete(Operateur.EGAL, ((Champ)((ComboBoxItem)cmbSousChamp.SelectedItem).Value));

            Table activites = Global.BaseDonneesCABS.EnvoyerRequeteSelection(reqSel);
            activites.Lignes.ForEach(l => cmbActivite.Items.Add(new ComboBoxItem(l.GetValeurChamp<string>("actNom"), l.GetChamp("actId"))));

            if (cmbActivite.Items.Count > 0)
                cmbActivite.SelectedIndex = 0;

            ChangerAccesControle(Mode);
        }

        private void cmbActivite_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbActivite.SelectedIndex == DernierIndexActivite)
                return;

            DernierIndexActivite = cmbActivite.SelectedIndex;

            cmbReunion.SelectedIndex = -1;
            cmbReunion.Items.Clear();

            if (cmbActivite.SelectedIndex == -1)
                return;

            RequeteSelection reqSel = new RequeteSelection(NomTable.reunion);
            reqSel.Condition = new ConditionRequete(Operateur.EGAL, ((Champ)((ComboBoxItem)cmbActivite.SelectedItem).Value));
            reqSel.AjouterTri("reuDate", false);

            Table reunions = Global.BaseDonneesCABS.EnvoyerRequeteSelection(reqSel);
            reunions.Lignes.ForEach(l => cmbReunion.Items.Add(new ComboBoxItem(String.Format(FORMAT_REUNION, l.GetValeurChamp<string>("reuDescription"), l.GetValeurChamp<DateTime>("reuDate").ToLongDateString()), l)));

            if (cmbReunion.Items.Count > 0)
                cmbReunion.SelectedIndex = 0;

            ChangerAccesControle(Mode);
        }

        private void cmbReunion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DernierIndexReunion == cmbReunion.SelectedIndex)
                return;

            DernierIndexReunion = cmbReunion.SelectedIndex;

            if (RafraichissementReunionActive)
                RafraichirReunion();
        }

        private void btnAjouterReunion_Click(object sender, EventArgs e)
        {
            ChangerAccesControle(ModeFormulaire.AJOUT);
            Vider();
        }

        private void btnModifierReunion_Click(object sender, EventArgs e)
        {
            ChangerAccesControle(ModeFormulaire.EDITION);
        }

        private void btnSupprimerReunion_Click(object sender, EventArgs e)
        {
            if (Supprimer())
                RafraichirReunion();
        }

        public override bool Supprimer()
        {
            if (!base.Supprimer())
                return false;

            if (!OutilsForms.PoserQuestion("Confirmation suppression", "Voulez-vous vraiment supprimer cette réunion?"))
                return false;

            LigneTable reunion = ((LigneTable)((ComboBoxItem)cmbReunion.SelectedItem).Value);

            RequeteSuppression reqSup = new RequeteSuppression(NomTable.reunion, new ConditionRequete(Operateur.EGAL, reunion.GetChamp("reuId")));

            if (Global.BaseDonneesCABS.EnvoyerRequeteSuppression(reqSup) < 0)
            {
                Journal.AfficherMessage("Une erreur est survenue lors de la suppression de la réunion. L'action a été annulée.", TypeMessage.ERREUR, true);
                return false;
            }

            cmbReunion.Items.Remove(cmbReunion.SelectedItem);

            if (cmbReunion.Items.Count > 0)
                cmbReunion.SelectedIndex = 0;

            return true;
        }

        private void btnConfirmerReunion_Click(object sender, EventArgs e)
        {
            RafraichissementReunionActive = false;

            if (Enregistrer())
                RafraichirReunion();

            RafraichissementReunionActive = true;
        }

        public override bool Enregistrer()
        {
            if (!base.Enregistrer())
                return false;

            Champ dateReunion = new Champ("reunion", "reuDate", dtpDate.Value);
            Champ descriptionReunion = new Champ("reunion", "reuDescription", txtDescription.Text);

            LigneTable ligneReunion = new LigneTable("reunion");
            ligneReunion.AjouterChamp(dateReunion);
            ligneReunion.AjouterChamp(descriptionReunion);

            if (Mode == ModeFormulaire.AJOUT)
            {
                RequeteAjout reqAjout = new RequeteAjout(NomTable.reunion, (Champ)((ComboBoxItem)cmbActivite.SelectedItem).Value, dateReunion, descriptionReunion);
                int nouvelIndex;

                if ((nouvelIndex = Global.BaseDonneesCABS.EnvoyerRequeteAjout(reqAjout)) < 0)
                {
                    Journal.AfficherMessage("Une erreur est survenue lors de l'ajout de la réunion. L'action a été annulée", TypeMessage.ERREUR, true);
                    return false;
                }

                ligneReunion.AjouterChamp(new Champ("reunion", "reuId", nouvelIndex));
            }
            else if (Mode == ModeFormulaire.EDITION)
            {
                Champ indexReunion = ((LigneTable)((ComboBoxItem)cmbReunion.SelectedItem).Value).GetChamp("reuId");
                RequeteModification reqModif = new RequeteModification(NomTable.reunion, new ConditionRequete(Operateur.EGAL, indexReunion), dateReunion, descriptionReunion);

                if (Global.BaseDonneesCABS.EnvoyerRequeteModification(reqModif) < 0)
                {
                    Journal.AfficherMessage("Une erreur est survenue lors de la modification de la réunion. L'action a été annulée.", TypeMessage.ERREUR, true);
                    return false;
                }

                ligneReunion.AjouterChamp(indexReunion);
                cmbReunion.Items.Remove(cmbReunion.SelectedItem);
            }

            int indexInsertion = cmbReunion.Items.Count;

            for (int i = 0; i < cmbReunion.Items.Count; ++i)
            {
                LigneTable reunion = (LigneTable)((ComboBoxItem)cmbReunion.Items[i]).Value;

                if (reunion.GetValeurChamp<DateTime>("reuDate") <= dtpDate.Value)
                {
                    indexInsertion = i;
                    break;
                }
            }

            cmbReunion.Items.Insert(indexInsertion, new ComboBoxItem(String.Format(FORMAT_REUNION, txtDescription.Text, dtpDate.Value.ToLongDateString()), ligneReunion));
            cmbReunion.SelectedIndex = indexInsertion;

            return true;
        }

        private void btnAnnulerReunion_Click(object sender, EventArgs e)
        {
            RafraichirReunion();
        }

        private void RafraichirReunion()
        {
            if (cmbReunion.SelectedIndex == -1)
                Vider();
            else
                ChargerReunion();

            ChangerAccesControle(ModeFormulaire.CONSULTATION);
        }

        public override void Vider()
        {
            base.Vider();

            dtpDate.Value = DateTime.Today;
            txtDescription.ResetText();

            lbBenevolesInclus.DataSource = null;
            lbEmployesInclus.DataSource = null;
        }

        private void ChargerReunion()
        {
            LigneTable reunion = ((LigneTable)((ComboBoxItem)cmbReunion.SelectedItem).Value);
            int indexReunion = reunion.GetValeurChamp<int>("reuId");

            dtpDate.Value = reunion.GetValeurChamp<DateTime>("reuDate");
            txtDescription.Text = reunion.GetValeurChamp<string>("reuDescription");

            Table benevolesInclus = Global.BaseDonneesCABS.EnvoyerRequeteSelectionDirect("benevolereunion", String.Format(REQUETE_BENEVOLES_INCLUS, indexReunion));
            List<ComboBoxItem> listeBenevolesInclus = new List<ComboBoxItem>();

            foreach (LigneTable l in benevolesInclus.Lignes)
            {
                string infosBenevole = String.Format(FORMAT_PERSONNES_INCLUS, l.GetValeurChamp<string>("perNom"), l.GetValeurChamp<string>("perPrenom"), l.GetValeurChamp<int>("benrHeures"));
                listeBenevolesInclus.Add(new ComboBoxItem(infosBenevole, l.GetChamp("perId")));
            }

            MettreAJourListe(lbBenevolesInclus, listeBenevolesInclus);

            Table employesInclus = Global.BaseDonneesCABS.EnvoyerRequeteSelectionDirect("employereunion", String.Format(REQUETE_EMPLOYES_INCLUS, indexReunion));
            List<ComboBoxItem> listeEmployesInclus = new List<ComboBoxItem>();

            foreach (LigneTable l in employesInclus.Lignes)
            {
                string infosBeneficiaire = String.Format(FORMAT_PERSONNES_INCLUS, l.GetValeurChamp<string>("perNom"), l.GetValeurChamp<string>("perPrenom"), l.GetValeurChamp<int>("erHeures"));
                listeEmployesInclus.Add(new ComboBoxItem(infosBeneficiaire, l.GetChamp("perId")));
            }

            MettreAJourListe(lbEmployesInclus, listeEmployesInclus);
        }

        public override void ChangerAccesControle(ModeFormulaire mode)
        {
            base.ChangerAccesControle(mode);

            cmbChamp.Enabled = Mode == ModeFormulaire.CONSULTATION;
            cmbSousChamp.Enabled = cmbChamp.SelectedIndex != -1 && Mode == ModeFormulaire.CONSULTATION;
            cmbActivite.Enabled = cmbSousChamp.SelectedIndex != -1 && Mode == ModeFormulaire.CONSULTATION;
            cmbReunion.Enabled = btnAjouterReunion.Enabled = cmbActivite.SelectedIndex != -1 && Mode == ModeFormulaire.CONSULTATION;

            btnConfirmerReunion.Enabled = btnAnnulerReunion.Enabled = 
            dtpDate.Enabled = txtDescription.Enabled = Mode != ModeFormulaire.CONSULTATION;

            btnModifierReunion.Enabled = btnSupprimerReunion.Enabled =
            gtBenevoles.Enabled = gtEmployes.Enabled =
            nudNombreHeuresBenevole.Enabled = nudNombreHeuresEmploye.Enabled =
            lbBenevolesInclus.Enabled = lbEmployesInclus.Enabled = cmbReunion.SelectedIndex != -1 && Mode == ModeFormulaire.CONSULTATION;
            btnRetirerBenevole.Enabled = lbBenevolesInclus.SelectedIndex != -1 && cmbReunion.SelectedIndex != -1 && Mode == ModeFormulaire.CONSULTATION;
            btnRetirerEmploye.Enabled = lbEmployesInclus.SelectedIndex != -1 && cmbReunion.SelectedIndex != -1 && Mode == ModeFormulaire.CONSULTATION;
        }

        private void gtBenevoles_RowDoubleClick(object sender, RowDoubleClickEventArgs e)
        {
            Champ indexBenevole = e.LigneCliquee.GetChamp("perId");
            Champ nombreHeures = new Champ("benevolereunion", "benrHeures", (int)nudNombreHeuresBenevole.Value);
            LigneTable reunion = ((LigneTable)((ComboBoxItem)cmbReunion.SelectedItem).Value);
            string infosBenevole = String.Format(FORMAT_PERSONNES_INCLUS, e.LigneCliquee.GetValeurChamp<string>("perNom"), e.LigneCliquee.GetValeurChamp<string>("perPrenom"), nombreHeures.Valeur);

            RequeteSelection reqSel = new RequeteSelection(NomTable.benevolereunion);
            reqSel.Condition = new ConditionRequete(Operateur.EGAL, indexBenevole);
            reqSel.Condition.LierCondition(new ConditionRequete(Operateur.EGAL, reunion.GetChamp("reuId")), true);

            if (!Global.BaseDonneesCABS.EnvoyerRequeteSelection(reqSel).EstVide)
            {
                Journal.AfficherMessage("Ce bénévole fait déjà partie de cette réunion. Retirez-le préalablement pour modifier son nombre d'heures.", TypeMessage.INFORMATION, false);
                return;
            }

            RequeteAjout reqAjout = new RequeteAjout(NomTable.benevolereunion, nombreHeures, indexBenevole, reunion.GetChamp("reuId"));

            if (Global.BaseDonneesCABS.EnvoyerRequeteAjout(reqAjout) < 0)
            {
                Journal.AfficherMessage("Une erreur est survenue lors de l'ajout du bénévole à la réunion. L'action a été annulée.", TypeMessage.ERREUR, true);
                return;
            }

            AjouterItem(lbBenevolesInclus, new ComboBoxItem(infosBenevole, indexBenevole));
        }

        private void gtEmployes_RowDoubleClick(object sender, RowDoubleClickEventArgs e)
        {
            Champ indexEmploye = e.LigneCliquee.GetChamp("perId");
            Champ nombreHeures = new Champ("employereunion", "erHeures", (int)nudNombreHeuresEmploye.Value);
            LigneTable reunion = ((LigneTable)((ComboBoxItem)cmbReunion.SelectedItem).Value);
            string infosEmploye = String.Format(FORMAT_PERSONNES_INCLUS, e.LigneCliquee.GetValeurChamp<string>("perNom"), e.LigneCliquee.GetValeurChamp<string>("perPrenom"), nombreHeures.Valeur);

            RequeteSelection reqSel = new RequeteSelection(NomTable.employereunion);
            reqSel.Condition = new ConditionRequete(Operateur.EGAL, indexEmploye);
            reqSel.Condition.LierCondition(new ConditionRequete(Operateur.EGAL, reunion.GetChamp("reuId")), true);

            if (!Global.BaseDonneesCABS.EnvoyerRequeteSelection(reqSel).EstVide)
            {
                Journal.AfficherMessage("Cet employé fait déjà partie de cette réunion. Retirez-le préalablement pour modifier son nombre d'heures.", TypeMessage.INFORMATION, false);
                return;
            }

            RequeteAjout reqAjout = new RequeteAjout(NomTable.employereunion, indexEmploye, reunion.GetChamp("reuId"), nombreHeures);

            if (Global.BaseDonneesCABS.EnvoyerRequeteAjout(reqAjout) < 0)
            {
                Journal.AfficherMessage("Une erreur est survenue lors de l'ajout de l'employé à la réunion. L'action a été annulée.", TypeMessage.ERREUR, true);
                return;
            }

            AjouterItem(lbEmployesInclus, new ComboBoxItem(infosEmploye, indexEmploye));
        }

        private void lbBenevolesInclus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangerAccesControle(Mode);
        }

        private void btnRetirerBenevole_Click(object sender, EventArgs e)
        {
            if (!OutilsForms.PoserQuestion("Confirmation suppression", "Voulez-vous vraiment retirer ce bénévole de cette réunion?"))
                return;

            Champ indexBenevole = ((Champ)((ComboBoxItem)lbBenevolesInclus.SelectedItem).Value);

            ConditionRequete cond = new ConditionRequete(Operateur.EGAL, indexBenevole);
            cond.LierCondition(new ConditionRequete(Operateur.EGAL, ((LigneTable)((ComboBoxItem)cmbReunion.SelectedItem).Value).GetChamp("reuId")), true);

            RequeteSuppression reqSup = new RequeteSuppression(NomTable.benevolereunion, cond);

            if (Global.BaseDonneesCABS.EnvoyerRequeteSuppression(reqSup) < 0)
            {
                Journal.AfficherMessage("Une erreur est survenue lors du retirement du bénévole de la réunion. L'action a été annulée.", TypeMessage.ERREUR, true);
                return;
            }

            SupprimerItem(lbBenevolesInclus);
        }

        private void lbEmployesInclus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangerAccesControle(Mode);
        }

        private void btnRetirerEmploye_Click(object sender, EventArgs e)
        {
            if (!OutilsForms.PoserQuestion("Confirmation suppression", "Voulez-vous vraiment retirer cet employé de cette réunion?"))
                return;

            Champ indexEmploye = ((Champ)((ComboBoxItem)lbEmployesInclus.SelectedItem).Value);

            ConditionRequete cond = new ConditionRequete(Operateur.EGAL, indexEmploye);
            cond.LierCondition(new ConditionRequete(Operateur.EGAL, ((LigneTable)((ComboBoxItem)cmbReunion.SelectedItem).Value).GetChamp("reuId")), true);

            RequeteSuppression reqSup = new RequeteSuppression(NomTable.employereunion, cond);

            if (Global.BaseDonneesCABS.EnvoyerRequeteSuppression(reqSup) < 0)
            {
                Journal.AfficherMessage("Une erreur est survenue lors du retirement de l'employé de la réunion. L'action a été annulée.", TypeMessage.ERREUR, true);
                return;
            }

            SupprimerItem(lbEmployesInclus);
        }

        private void AjouterItem(ListBox liste, ComboBoxItem nouvelItem)
        {
            List<ComboBoxItem> dataSource = (List<ComboBoxItem>)liste.DataSource;

            if (dataSource == null)
                dataSource = new List<ComboBoxItem>();

            dataSource.Add(nouvelItem);
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

        public override bool QuitterPage()
        {
            if (!base.QuitterPage())
                return false;

            if (Mode == ModeFormulaire.AJOUT || Mode == ModeFormulaire.EDITION)
            {
                bool quitter = OutilsForms.PoserQuestion("Confirmation", "Des modifications n'ont pas été enregistrées et seront perdues.\nVoulez-vous vraiment quitter sans enregistrer?");

                if (quitter)
                    btnAnnulerReunion.PerformClick();

                return quitter;
            }

            return true;
        }
    }
}
