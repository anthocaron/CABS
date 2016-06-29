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
    public partial class frmActions : Formulaire
    {
        private const string REQUETE_PERSONNES = "SELECT p.perId, p.perNom, p.perPrenom, p.perDateNaissance FROM personne p INNER JOIN {0} b ON b.perId = p.perId ORDER BY p.perNom, p.perPrenom, p.perDateNaissance;";
        private const string REQUETE_BENEVOLES_INCLUS = "SELECT p.perId, p.perNom, p.perPrenom, b.benaHeures FROM personne p INNER JOIN benevoleactionactivite b ON b.perId = p.perId WHERE b.actaId = {0} ORDER BY p.perNom, p.perPrenom, p.perDateNaissance, b.benaHeures;";
        private const string REQUETE_BENEFICIAIRES_INCLUS = "SELECT p.perId, p.perNom, p.perPrenom FROM personne p INNER JOIN beneficiaireactionactivite b ON b.perId = p.perId WHERE b.actaId = {0} ORDER BY p.perNom, p.perPrenom, p.perDateNaissance;";
        private const string FORMAT_BENEVOLES_INCLUS = "{0}, {1} - {2} heure(s)";
        private const string FORMAT_BENEFICIAIRES_INCLUS = "{0}, {1}";
        private List<string> CHAMPS_PERSONNES_AFFICHES = new List<string>(new string[] { "perNom", "perPrenom", "perDateNaissance" });

        private bool RafraichissementActionActive;

        private int DernierIndexChamp;
        private int DernierIndexSousChamp;
        private int DernierIndexActivite;
        private int DernierIndexAction;

        public frmActions()
            : base(true, true)
        {
            InitializeComponent();

            RafraichissementActionActive = true;
            DernierIndexChamp = DernierIndexSousChamp = DernierIndexActivite = DernierIndexAction = -1;
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

            Table beneficaires = Global.BaseDonneesCABS.EnvoyerRequeteSelectionDirect("personne", String.Format(REQUETE_PERSONNES, "beneficiaire"));
            gtBeneficiaires.Rafraichir(beneficaires, CHAMPS_PERSONNES_AFFICHES);

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

            cmbAction.SelectedIndex = -1;
            cmbAction.Items.Clear();

            if (cmbActivite.SelectedIndex == -1)
                return;

            RequeteSelection reqSel = new RequeteSelection(NomTable.actionactivite);
            reqSel.Condition = new ConditionRequete(Operateur.EGAL, ((Champ)((ComboBoxItem)cmbActivite.SelectedItem).Value));
            reqSel.AjouterTri("actaDate", false);

            Table actions = Global.BaseDonneesCABS.EnvoyerRequeteSelection(reqSel);
            actions.Lignes.ForEach(l => cmbAction.Items.Add(new ComboBoxItem(l.GetValeurChamp<DateTime>("actaDate").ToLongDateString(), l)));

            if (cmbAction.Items.Count > 0)
                cmbAction.SelectedIndex = 0;

            ChangerAccesControle(Mode);
        }

        private void cmbAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DernierIndexAction == cmbAction.SelectedIndex)
                return;

            DernierIndexAction = cmbAction.SelectedIndex;

            if(RafraichissementActionActive)
                RafraichirAction();
        }

        private void btnAjouterAction_Click(object sender, EventArgs e)
        {
            ChangerAccesControle(ModeFormulaire.AJOUT);
            Vider();
        }

        private void btnModifierAction_Click(object sender, EventArgs e)
        {
            ChangerAccesControle(ModeFormulaire.EDITION);
        }

        private void btnSupprimerAction_Click(object sender, EventArgs e)
        {
            if (Supprimer())
                RafraichirAction();
        }

        public override bool Supprimer()
        {
            if (!base.Supprimer())
                return false;

            if (!OutilsForms.PoserQuestion("Confirmation suppression", "Voulez-vous vraiment supprimer cette action?"))
                return false;

            LigneTable action = ((LigneTable)((ComboBoxItem)cmbAction.SelectedItem).Value);

            RequeteSuppression reqSup = new RequeteSuppression(NomTable.actionactivite, new ConditionRequete(Operateur.EGAL, action.GetChamp("actaId")));

            if (Global.BaseDonneesCABS.EnvoyerRequeteSuppression(reqSup) < 0)
            {
                Journal.AfficherMessage("Une erreur est survenue lors de la suppression de l'action. L'action a été annulée.", TypeMessage.ERREUR, true);
                return false;
            }

            cmbAction.Items.Remove(cmbAction.SelectedItem);

            if (cmbAction.Items.Count > 0)
                cmbAction.SelectedIndex = 0;

            return true;
        }

        private void btnConfirmerAction_Click(object sender, EventArgs e)
        {
            RafraichissementActionActive = false;

            if (Enregistrer())
                RafraichirAction();

            RafraichissementActionActive = true;
        }

        public override bool Enregistrer()
        {
            if (!base.Enregistrer())
                return false;

            Champ dateAction = new Champ("actionactivite", "actaDate", dtpDate.Value);
            Champ nbBenevolesNonInscritsAction = new Champ("actionactivite", "actaNbBenevolesNonInscrits", nudBenevolesNonInscrits.Value);

            LigneTable ligneAction = new LigneTable("actionactivite");
            ligneAction.AjouterChamp(dateAction);
            ligneAction.AjouterChamp(nbBenevolesNonInscritsAction);

            if (Mode == ModeFormulaire.AJOUT)
            {
                RequeteAjout reqAjout = new RequeteAjout(NomTable.actionactivite, (Champ)((ComboBoxItem)cmbActivite.SelectedItem).Value, dateAction, nbBenevolesNonInscritsAction);
                int nouvelIndex;

                if ((nouvelIndex = Global.BaseDonneesCABS.EnvoyerRequeteAjout(reqAjout)) < 0)
                {
                    Journal.AfficherMessage("Une erreur est survenue lors de l'ajout de l'action. L'action a été annulée", TypeMessage.ERREUR, true);
                    return false;
                }

                ligneAction.AjouterChamp(new Champ("actionactivite", "actaId", nouvelIndex));
            }
            else if (Mode == ModeFormulaire.EDITION)
            {
                Champ indexAction = ((LigneTable)((ComboBoxItem)cmbAction.SelectedItem).Value).GetChamp("actaId");
                RequeteModification reqModif = new RequeteModification(NomTable.actionactivite, new ConditionRequete(Operateur.EGAL, indexAction), dateAction, nbBenevolesNonInscritsAction);

                if (Global.BaseDonneesCABS.EnvoyerRequeteModification(reqModif) < 0)
                {
                    Journal.AfficherMessage("Une erreur est survenue lors de la modification de l'action. L'action a été annulée.", TypeMessage.ERREUR, true);
                    return false;
                }

                ligneAction.AjouterChamp(indexAction);
                cmbAction.Items.Remove(cmbAction.SelectedItem);
            }

            int indexInsertion = cmbAction.Items.Count;

            for (int i = 0; i < cmbAction.Items.Count; ++i)
            {
                LigneTable action = (LigneTable)((ComboBoxItem)cmbAction.Items[i]).Value;

                if (action.GetValeurChamp<DateTime>("actaDate") <= dtpDate.Value)
                {
                    indexInsertion = i;
                    break;
                }
            }

            cmbAction.Items.Insert(indexInsertion, new ComboBoxItem(dtpDate.Value.ToLongDateString(), ligneAction));
            cmbAction.SelectedIndex = indexInsertion;

            return true;
        }

        private void btnAnnulerAction_Click(object sender, EventArgs e)
        {
            RafraichirAction();
        }

        private void RafraichirAction()
        {
            if (cmbAction.SelectedIndex == -1)
                Vider();
            else
                ChargerAction();

            ChangerAccesControle(ModeFormulaire.CONSULTATION);
        }

        public override void Vider()
        {
            base.Vider();

            dtpDate.Value = DateTime.Today;
            nudBenevolesNonInscrits.Value = 0;
            lbBenevolesInclus.DataSource = null;
            lbBeneficiairesInclus.DataSource = null;
        }

        private void ChargerAction()
        {
            LigneTable action = ((LigneTable)((ComboBoxItem)cmbAction.SelectedItem).Value);
            int indexAction = action.GetValeurChamp<int>("actaId");

            dtpDate.Value = action.GetValeurChamp<DateTime>("actaDate");
            nudBenevolesNonInscrits.Value = action.GetValeurChamp<int>("actaNbBenevolesNonInscrits");

            Table benevolesInclus = Global.BaseDonneesCABS.EnvoyerRequeteSelectionDirect("benevoleactionactivite", String.Format(REQUETE_BENEVOLES_INCLUS, indexAction));
            List<ComboBoxItem> listeBenevolesInclus = new List<ComboBoxItem>();

            foreach (LigneTable l in benevolesInclus.Lignes)
            {
                string infosBenevole = String.Format(FORMAT_BENEVOLES_INCLUS, l.GetValeurChamp<string>("perNom"), l.GetValeurChamp<string>("perPrenom"), l.GetValeurChamp<int>("benaHeures"));
                listeBenevolesInclus.Add(new ComboBoxItem(infosBenevole, l.GetChamp("perId")));
            }

            MettreAJourListe(lbBenevolesInclus, listeBenevolesInclus);

            Table beneficiairesInclus = Global.BaseDonneesCABS.EnvoyerRequeteSelectionDirect("beneficiaireactionactivite", String.Format(REQUETE_BENEFICIAIRES_INCLUS, indexAction));
            List<ComboBoxItem> listeBeneficiairesInclus = new List<ComboBoxItem>();

            foreach (LigneTable l in beneficiairesInclus.Lignes)
            {
                string infosBeneficiaire = String.Format(FORMAT_BENEFICIAIRES_INCLUS, l.GetValeurChamp<string>("perNom"), l.GetValeurChamp<string>("perPrenom"));
                listeBeneficiairesInclus.Add(new ComboBoxItem(infosBeneficiaire, l.GetChamp("perId")));
            }

            MettreAJourListe(lbBeneficiairesInclus, listeBeneficiairesInclus);
        }

        public override void ChangerAccesControle(ModeFormulaire mode)
        {
            base.ChangerAccesControle(mode);

            cmbChamp.Enabled = Mode == ModeFormulaire.CONSULTATION;
            cmbSousChamp.Enabled = cmbChamp.SelectedIndex != -1 && Mode == ModeFormulaire.CONSULTATION;
            cmbActivite.Enabled = cmbSousChamp.SelectedIndex != -1 && Mode == ModeFormulaire.CONSULTATION;
            cmbAction.Enabled = btnAjouterAction.Enabled = cmbActivite.SelectedIndex != -1 && Mode == ModeFormulaire.CONSULTATION;

            btnConfirmerAction.Enabled = btnAnnulerAction.Enabled = dtpDate.Enabled = nudBenevolesNonInscrits.Enabled = Mode != ModeFormulaire.CONSULTATION;

            btnModifierAction.Enabled = btnSupprimerAction.Enabled = 
            gtBenevoles.Enabled = gtBeneficiaires.Enabled =
            nudNombreHeures.Enabled =
            lbBenevolesInclus.Enabled = lbBeneficiairesInclus.Enabled = cmbAction.SelectedIndex != -1 && Mode == ModeFormulaire.CONSULTATION;
            btnRetirerBenevole.Enabled = lbBenevolesInclus.SelectedIndex != -1 && cmbAction.SelectedIndex != -1 && Mode == ModeFormulaire.CONSULTATION;
            btnRetirerBeneficiaire.Enabled = lbBeneficiairesInclus.SelectedIndex != -1 && cmbAction.SelectedIndex != -1 && Mode == ModeFormulaire.CONSULTATION;
        }

        private void gtBenevoles_RowDoubleClick(object sender, Outils.RowDoubleClickEventArgs e)
        {
            Champ indexBenevole = e.LigneCliquee.GetChamp("perId");
            Champ nombreHeures = new Champ("benevoleactionactivite", "benaHeures", (int)nudNombreHeures.Value);
            LigneTable action = ((LigneTable)((ComboBoxItem)cmbAction.SelectedItem).Value);
            string infosBenevole = String.Format(FORMAT_BENEVOLES_INCLUS, e.LigneCliquee.GetValeurChamp<string>("perNom"), e.LigneCliquee.GetValeurChamp<string>("perPrenom"), nombreHeures.Valeur);

            RequeteSelection reqSel = new RequeteSelection(NomTable.benevoleactionactivite);
            reqSel.Condition = new ConditionRequete(Operateur.EGAL, indexBenevole);
            reqSel.Condition.LierCondition(new ConditionRequete(Operateur.EGAL, action.GetChamp("actaId")), true);

            if (!Global.BaseDonneesCABS.EnvoyerRequeteSelection(reqSel).EstVide)
            {
                Journal.AfficherMessage("Ce bénévole fait déjà partie de cette action. Retirez-le préalablement pour modifier son nombre d'heures.", TypeMessage.INFORMATION, false);
                return;
            }

            RequeteAjout reqAjout = new RequeteAjout(NomTable.benevoleactionactivite, nombreHeures, indexBenevole, action.GetChamp("actaId"));

            if (Global.BaseDonneesCABS.EnvoyerRequeteAjout(reqAjout) < 0)
            {
                Journal.AfficherMessage("Une erreur est survenue lors de l'ajout du bénévole à l'action. L'action a été annulée.", TypeMessage.ERREUR, true);
                return;
            }

            AjouterItem(lbBenevolesInclus, new ComboBoxItem(infosBenevole, indexBenevole));
        }

        private void gtBeneficiaires_RowDoubleClick(object sender, Outils.RowDoubleClickEventArgs e)
        {
            Champ indexBeneficiaire = e.LigneCliquee.GetChamp("perId");
            LigneTable action = ((LigneTable)((ComboBoxItem)cmbAction.SelectedItem).Value);
            string infosBeneficiaire = String.Format(FORMAT_BENEFICIAIRES_INCLUS, e.LigneCliquee.GetValeurChamp<string>("perNom"), e.LigneCliquee.GetValeurChamp<string>("perPrenom"));

            RequeteSelection reqSel = new RequeteSelection(NomTable.beneficiaireactionactivite);
            reqSel.Condition = new ConditionRequete(Operateur.EGAL, indexBeneficiaire);
            reqSel.Condition.LierCondition(new ConditionRequete(Operateur.EGAL, action.GetChamp("actaId")), true);

            if (!Global.BaseDonneesCABS.EnvoyerRequeteSelection(reqSel).EstVide)
            {
                Journal.AfficherMessage("Ce bénéficiaire fait déjà partie de cette action.", TypeMessage.INFORMATION, false);
                return;
            }

            RequeteAjout reqAjout = new RequeteAjout(NomTable.beneficiaireactionactivite, indexBeneficiaire, action.GetChamp("actaId"));

            if (Global.BaseDonneesCABS.EnvoyerRequeteAjout(reqAjout) < 0)
            {
                Journal.AfficherMessage("Une erreur est survenue lors de l'ajout du bénéficiaire à l'action. L'action a été annulée.", TypeMessage.ERREUR, true);
                return;
            }

            AjouterItem(lbBeneficiairesInclus, new ComboBoxItem(infosBeneficiaire, indexBeneficiaire));
        }

        private void lbBenevolesInclus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangerAccesControle(Mode);
        }

        private void btnRetirerBenevole_Click(object sender, EventArgs e)
        {
            if (!OutilsForms.PoserQuestion("Confirmation suppression", "Voulez-vous vraiment retirer ce bénévole de cette action?"))
                return;

            Champ indexBenevole = ((Champ)((ComboBoxItem)lbBenevolesInclus.SelectedItem).Value);

            ConditionRequete cond = new ConditionRequete(Operateur.EGAL, indexBenevole);
            cond.LierCondition(new ConditionRequete(Operateur.EGAL, ((LigneTable)((ComboBoxItem)cmbAction.SelectedItem).Value).GetChamp("actaId")), true);

            RequeteSuppression reqSup = new RequeteSuppression(NomTable.benevoleactionactivite, cond);

            if (Global.BaseDonneesCABS.EnvoyerRequeteSuppression(reqSup) < 0)
            {
                Journal.AfficherMessage("Une erreur est survenue lors du retirement du bénévole de l'action. L'action a été annulée.", TypeMessage.ERREUR, true);
                return;
            }

            SupprimerItem(lbBenevolesInclus);
        }

        private void lbBeneficiairesInclus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangerAccesControle(Mode);
        }

        private void btnRetirerBeneficiaire_Click(object sender, EventArgs e)
        {
            if (!OutilsForms.PoserQuestion("Confirmation suppression", "Voulez-vous vraiment retirer ce bénéficiaire de cette action?"))
                return;

            Champ indexBeneficiaire = ((Champ)((ComboBoxItem)lbBeneficiairesInclus.SelectedItem).Value);

            ConditionRequete cond = new ConditionRequete(Operateur.EGAL, indexBeneficiaire);
            cond.LierCondition(new ConditionRequete(Operateur.EGAL, ((LigneTable)((ComboBoxItem)cmbAction.SelectedItem).Value).GetChamp("actaId")), true);

            RequeteSuppression reqSup = new RequeteSuppression(NomTable.beneficiaireactionactivite, cond);

            if (Global.BaseDonneesCABS.EnvoyerRequeteSuppression(reqSup) < 0)
            {
                Journal.AfficherMessage("Une erreur est survenue lors du retirement du bénéficiaire de l'action. L'action a été annulée.", TypeMessage.ERREUR, true);
                return;
            }

            SupprimerItem(lbBeneficiairesInclus);
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
                    btnAnnulerAction.PerformClick();

                return quitter;
            }

            return true;
        }
    }
}
