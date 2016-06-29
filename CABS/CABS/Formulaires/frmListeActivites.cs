using CABS.BaseDonnees;
using CABS.Outils;
using CABS.Outils.Excel;
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
	public partial class frmListeActivites : Formulaire
	{
		private const string REQ_ACTIONS_BENEVOLES = "SELECT a.actaDate, coalesce(sum(bo.benaHeures), 0) as actaHeuresBenevoles, count(distinct bo.perId) as actaNombreBenevoles, a.actaNbBenevolesNonInscrits " +
													 "FROM actionactivite a LEFT JOIN benevoleactionactivite bo ON bo.actaId = a.actaId WHERE a.actId = {0}{1} GROUP BY a.actaDate;";
		private const string REQ_ACTIONS_BENEFICIAIRES = "SELECT a.actaDate, count(distinct be.perId) as actaNombreBeneficiaires " +
														 "FROM actionactivite a LEFT JOIN beneficiaireactionactivite be ON be.actaId = a.actaId WHERE a.actId = {0}{1} GROUP BY a.actaDate;";
		private const string REQ_REUNIONS_BENEVOLES = "SELECT r.reuDate, coalesce(sum(bo.benrHeures), 0) as reuHeuresBenevoles, count(distinct bo.perId) as reuNombreBenevoles " +
													  "FROM reunion r LEFT JOIN benevolereunion bo ON bo.reuId = r.reuId WHERE r.actId = {0}{1} GROUP BY r.reuDate;";
		private const string REQ_REUNIONS_EMPLOYES = "SELECT r.reuDate, coalesce(sum(e.erHeures), 0) as reuHeuresEmployes, count(distinct e.perId) as reuNombreEmployes " +
													 "FROM reunion r LEFT JOIN employereunion e ON e.reuId = r.reuId WHERE r.actId = {0}{1} GROUP BY r.reuDate;";
		private const string REQ_NB_BENEVOLES = "SELECT count(distinct b.perId) as nombreBenevoles FROM (" +
												"SELECT distinct bo.perId FROM actionactivite a LEFT JOIN benevoleactionactivite bo ON bo.actaId = a.actaId WHERE a.actId = {0}{1} " +
												"UNION SELECT distinct bo.perId FROM reunion r LEFT JOIN benevolereunion bo ON bo.reuId = r.reuId WHERE r.actId = {0}{2}) as b;";
		private const string REQ_NB_BENEFICIAIRES_ACT = "SELECT count(distinct be.perId) as actaNombreBeneficiaires " +
														"FROM actionactivite a LEFT JOIN beneficiaireactionactivite be ON be.actaId = a.actaId WHERE a.actId = {0}{1};";
		private const string REQ_NB_BENEVOLES_TOTAL = "SELECT count(distinct b.perId) as nombreBenevoles FROM ( " +
													  "SELECT distinct bo.perId FROM actionactivite aa INNER JOIN activite a ON a.actId = aa.actId " +
													  "LEFT JOIN benevoleactionactivite bo ON bo.actaId = aa.actaId WHERE a.scaId = {0}{1} " +
													  "UNION SELECT distinct bo.perId FROM reunion r INNER JOIN activite a ON a.actId = r.actId " +
													  "LEFT JOIN benevolereunion bo ON bo.reuId = r.reuId WHERE a.scaId = {0}{2}) as b;";
		private const string REQ_NB_BENEFICIAIRES_TOTAL = "SELECT count(distinct be.perId) as actaNombreBeneficiaires FROM actionactivite aa " +
														  "INNER JOIN activite a ON a.actId = aa.actId LEFT JOIN beneficiaireactionactivite be ON be.actaId = aa.actaId WHERE a.scaId = {0}{1};";
		private const string COND_DATE_ACTIONS = " AND (a.actaDate BETWEEN '{0}' AND '{1}')";
		private const string COND_DATE_REUNIONS = " AND (r.reuDate BETWEEN '{0}' AND '{1}')";

		private int DernierIndexChamp;
		private int DernierIndexSousChamp;
		private int DernierIndexActivite;

		public frmListeActivites()
			: base(true, true)
		{
			InitializeComponent();
			DernierIndexChamp = DernierIndexSousChamp = DernierIndexActivite = -1;
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
			if (DernierIndexActivite == cmbActivite.SelectedIndex)
				return;

			DernierIndexActivite = cmbActivite.SelectedIndex;
			ChangerAccesControle(Mode);
		}

		private void cbSpecifierPeriodeActionsReunions_CheckedChanged(object sender, EventArgs e)
		{
			ChangerAccesControle(Mode);
		}

		private Table GetListe(string formatRequete, string formatConditionDate, int indexActivite, string nomTable)
		{
			string conditionDate = "";

			if (cbSpecifierPeriodeActionsReunions.Checked)
			{
				conditionDate = String.Format(formatConditionDate, dtpDeActionsReunions.Value.ToShortDateString(),
																   dtpAActionsReunions.Value.ToShortDateString());
			}

			string requete = String.Format(formatRequete, indexActivite, conditionDate);
			return Global.BaseDonneesCABS.EnvoyerRequeteSelectionDirect(nomTable, requete);
		}

		private void btnListeActions_Click(object sender, EventArgs e)
		{
			if (dtpDeActionsReunions.Value.Date > dtpAActionsReunions.Value.Date)
			{
				Journal.AfficherMessage("Veuillez entrer une période de temps valide.", TypeMessage.INFORMATION, false);
				return;
			}

			Champ indexActivite = (Champ)((ComboBoxItem)cmbActivite.SelectedItem).Value;
			
			Table benevoles = GetListe(REQ_ACTIONS_BENEVOLES, COND_DATE_ACTIONS, (int)indexActivite.Valeur, "actionactivite");
			Table beneficiaires = GetListe(REQ_ACTIONS_BENEFICIAIRES, COND_DATE_ACTIONS, (int)indexActivite.Valeur, "actionactivite");

			benevoles.Joindre("actaDate", beneficiaires, "actaDate");
			GenererListe(benevoles, "Actions");
		}

		private void btnListeReunions_Click(object sender, EventArgs e)
		{
			if (dtpDeActionsReunions.Value.Date > dtpAActionsReunions.Value.Date)
			{
				Journal.AfficherMessage("Veuillez entrer une période de temps valide.", TypeMessage.INFORMATION, false);
				return;
			}

			Champ indexActivite = (Champ)((ComboBoxItem)cmbActivite.SelectedItem).Value;

			Table benevoles = GetListe(REQ_REUNIONS_BENEVOLES, COND_DATE_REUNIONS, (int)indexActivite.Valeur, "actionactivite");
			Table employes = GetListe(REQ_REUNIONS_EMPLOYES, COND_DATE_REUNIONS, (int)indexActivite.Valeur, "actionactivite");

			benevoles.Joindre("reuDate", employes, "reuDate");
			GenererListe(benevoles, "Réunions");
		}

		private void GenererListe(Table donnees, string nomFeuille)
		{
			Classeur document = new Classeur();

			Tableau tableau = new Tableau(donnees, ((ComboBoxItem)cmbChamp.SelectedItem).Text);
			tableau.AjouterTitre(((ComboBoxItem)cmbSousChamp.SelectedItem).Text);
			tableau.AjouterTitre(((ComboBoxItem)cmbActivite.SelectedItem).Text);

			Feuille feuille = new Feuille(nomFeuille, tableau.Titres.Count + 1);
			feuille.AjouterTableau(tableau);
			document.AjouterFeuille(feuille);

			frmPrincipal formulairePrincipal = ParentForm is frmPrincipal ? (frmPrincipal)ParentForm : null;

			if (formulairePrincipal != null)
				formulairePrincipal.AfficherIndication("Génération du document Excel");

			document.Generer();

			if (formulairePrincipal != null)
				formulairePrincipal.EffacerIndication();
		}

		private void cbSpecifierPeriodeActivites_CheckedChanged(object sender, EventArgs e)
		{
			ChangerAccesControle(Mode);
		}

		private void btnGenererTableauxActivites_Click(object sender, EventArgs e)
		{
			if (dtpDeActivites.Value.Date > dtpAActivites.Value.Date)
			{
				Journal.AfficherMessage("Veuillez entrer une période de temps valide.", TypeMessage.INFORMATION, false);
				return;
			}

			Classeur document = new Classeur();
			Feuille feuille = new Feuille("Tableaux");

			RequeteSelection reqSel = new RequeteSelection(NomTable.champactivite);
			Table champs = Global.BaseDonneesCABS.EnvoyerRequeteSelection(reqSel);

			foreach (LigneTable champ in champs.Lignes)
			{
				reqSel = new RequeteSelection(NomTable.souschampactivite);
				reqSel.Condition = new ConditionRequete(Operateur.EGAL, champ.GetChamp("chaId"));

				Table sousChamps = Global.BaseDonneesCABS.EnvoyerRequeteSelection(reqSel);

				foreach (LigneTable sousChamp in sousChamps.Lignes)
				{
					reqSel = new RequeteSelection(NomTable.activite);
					reqSel.Condition = new ConditionRequete(Operateur.EGAL, sousChamp.GetChamp("scaId"));

					Table activites = Global.BaseDonneesCABS.EnvoyerRequeteSelection(reqSel);
					Table statsActivites = new Table("statsactivites");

					int totalBenevoles = 0;
					int totalBeneficiaires = 0;
					int totalHeures = 0;
					int totalActions = 0;
					int totalReunions = 0;

					foreach (LigneTable activite in activites.Lignes)
					{
						int indexActivite = activite.GetValeurChamp<int>("actId");

						Table benevolesActions = GetTableau(REQ_ACTIONS_BENEVOLES, COND_DATE_ACTIONS, indexActivite, "actionactivite");
						Table heuresBenevolesReunions = GetTableau(REQ_REUNIONS_BENEVOLES, COND_DATE_REUNIONS, indexActivite, "reunion");
						Table heuresEmployesReunions = GetTableau(REQ_REUNIONS_EMPLOYES, COND_DATE_REUNIONS, indexActivite, "reunion");

						if (benevolesActions.EstVide && heuresBenevolesReunions.EstVide && heuresEmployesReunions.EstVide)
							continue;

						int nbHeures = 0;

						benevolesActions.Lignes.ForEach(l => nbHeures += l.GetValeurChamp<int>("actaHeuresBenevoles"));
						heuresBenevolesReunions.Lignes.ForEach(l => nbHeures += l.GetValeurChamp<int>("reuHeuresBenevoles"));
						heuresEmployesReunions.Lignes.ForEach(l => nbHeures += l.GetValeurChamp<int>("reuHeuresEmployes"));

						string nbHeuresTexte = nbHeures == 0 ? "" : nbHeures.ToString();

						Table nombreBenevoles = GetTableaunNbBenevoles(REQ_NB_BENEVOLES, indexActivite, "");

						int nbBenevoles = nombreBenevoles.EstVide ? 0 : nombreBenevoles.Lignes[0].GetValeurChamp<int>("nombreBenevoles");
						benevolesActions.Lignes.ForEach(l => nbBenevoles += l.GetValeurChamp<int>("actaNbBenevolesNonInscrits"));

						string nbBenevolesTexte = nbBenevoles == 0 ? "" : nbBenevoles.ToString();

						Table nombreBeneficiaires = GetTableau(REQ_NB_BENEFICIAIRES_ACT, COND_DATE_ACTIONS, indexActivite, "actionactivite");
						int nbBeneficiaires = nombreBeneficiaires.EstVide ? 0 : nombreBeneficiaires.Lignes[0].GetValeurChamp<int>("actaNombreBeneficiaires");
						string nbBeneficiairesTexte = nbBeneficiaires == 0 ? "" : nbBeneficiaires.ToString();

						int nbActions = benevolesActions.NombreLignes;
						string nbActionsTexte = nbActions == 0 ? "" : nbActions.ToString();

						int nbReunions = heuresBenevolesReunions.NombreLignes;
						string nbReunionsTexte = nbReunions == 0 ? "" : nbReunions.ToString();

						LigneTable stats = new LigneTable("statsactivites");
						stats.AjouterChamp("staaNomActivite", activite.GetValeurChamp<string>("actNom"));
						stats.AjouterChamp("staaNbBenevoles", nbBenevolesTexte);
						stats.AjouterChamp("staaNbHeures", nbHeuresTexte);
						stats.AjouterChamp("staaNbBeneficiaires", nbBeneficiairesTexte);
						stats.AjouterChamp("staaNbActions", nbActionsTexte);
						stats.AjouterChamp("staaNbReunions", nbReunionsTexte);

						statsActivites.AjouterLigne(stats);

						totalBenevoles += nbBenevoles;
						totalHeures += nbHeures;
						totalBeneficiaires += nbBeneficiaires;
						totalActions += nbActions;
						totalReunions += nbReunions;
					}

					if (statsActivites.EstVide)
						continue;

					int indexSousChampActivite = sousChamp.GetValeurChamp<int>("scaId");

					if (cbTotaliserBenevolesDifferents.Checked)
					{
						Table nombreBenevoles = GetTableaunNbBenevoles(REQ_NB_BENEVOLES_TOTAL, indexSousChampActivite, "");
						totalBenevoles = nombreBenevoles.EstVide ? 0 : nombreBenevoles.Lignes[0].GetValeurChamp<int>("nombreBenevoles");
					}

					if (cbTotaliserBeneficiairesDifferents.Checked)
					{
						Table nombreBeneficiaires = GetTableau(REQ_NB_BENEFICIAIRES_TOTAL, COND_DATE_ACTIONS, indexSousChampActivite, "actionactivite");
						totalBeneficiaires = nombreBeneficiaires.EstVide ? 0 : nombreBeneficiaires.Lignes[0].GetValeurChamp<int>("actaNombreBeneficiaires");
					}

					LigneTable totaux = new LigneTable("statsactivites");
					totaux.AjouterChamp("staaNomActivite", "Total");
					totaux.AjouterChamp("staaNbBenevoles", totalBenevoles);
					totaux.AjouterChamp("staaNbHeures", totalHeures);
					totaux.AjouterChamp("staaNbBeneficiaires", totalBeneficiaires);
					totaux.AjouterChamp("staaNbActions", totalActions);
					totaux.AjouterChamp("staaNbReunions", totalReunions);

					statsActivites.AjouterLigne(totaux);

					Tableau tableau = new Tableau(statsActivites, champ.GetValeurChamp<string>("chaNom"));
					tableau.AjouterTitre(sousChamp.GetValeurChamp<string>("scaNom"));

					feuille.AjouterTableau(tableau);
				}
			}

			document.AjouterFeuille(feuille);

			frmPrincipal formulairePrincipal = ParentForm is frmPrincipal ? (frmPrincipal)ParentForm : null;

			if (formulairePrincipal != null)
				formulairePrincipal.AfficherIndication("Génération du document Excel");

			document.Generer();

			if (formulairePrincipal != null)
				formulairePrincipal.EffacerIndication();
		}

		private Table GetTableau(string formatRequete, string formatConditionDate, int index, string nomTable)
		{
			string conditionDate = "";

			if (cbSpecifierPeriodeActivites.Checked)
			{
				conditionDate = String.Format(formatConditionDate, dtpDeActivites.Value.ToShortDateString(),
																   dtpAActivites.Value.ToShortDateString());
			}

			string requete = String.Format(formatRequete, index, conditionDate);
			return Global.BaseDonneesCABS.EnvoyerRequeteSelectionDirect(nomTable, requete);
		}

		private Table GetTableaunNbBenevoles(string formatRequete, int index, string nomTable)
		{
			string conditionDateActions = "";
			string conditionDateReunions = "";

			if (cbSpecifierPeriodeActivites.Checked)
			{
				conditionDateActions = String.Format(COND_DATE_ACTIONS, dtpDeActivites.Value.ToShortDateString(),
																		dtpAActivites.Value.ToShortDateString());
				conditionDateReunions = String.Format(COND_DATE_REUNIONS, dtpDeActivites.Value.ToShortDateString(),
																		  dtpAActivites.Value.ToShortDateString());
			}

			string requete = String.Format(formatRequete, index, conditionDateActions, conditionDateReunions);
			return Global.BaseDonneesCABS.EnvoyerRequeteSelectionDirect(nomTable, requete);
		}

		public override void ChangerAccesControle(ModeFormulaire mode)
		{
			base.ChangerAccesControle(mode);

			cmbSousChamp.Enabled = cmbChamp.SelectedIndex != -1;
			cmbActivite.Enabled = cmbSousChamp.SelectedIndex != -1;

			cbSpecifierPeriodeActionsReunions.Enabled = btnListeActions.Enabled = btnListeReunions.Enabled = cmbActivite.SelectedIndex != -1;
			dtpDeActionsReunions.Enabled = dtpAActionsReunions.Enabled = cbSpecifierPeriodeActionsReunions.Checked && cbSpecifierPeriodeActionsReunions.Enabled;

			dtpDeActivites.Enabled = dtpAActivites.Enabled = cbSpecifierPeriodeActivites.Checked;
		}
	}
}
