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
    public partial class frmFeuillesRoute : Formulaire
    {
        private const string FORMAT_NOM_TABLEAU = "{0} / {1} CAB {2}";
        private const string FORMAT_REQUETE_LIVRAISONS =    "SELECT p.perNoCivique, p.perRue, p.perNoAppart, p.perPrenom, p.perNom, p.perTelephone1, i.iprSolde, l.lprNombreRepas, l.lprPrixRepas, i.iprIndicationsLivraison, ins.insCommentaires " +
                                                            "FROM livraisonpopoteroulante l " +
                                                            "INNER JOIN personne p ON l.perId = p.perId " +
                                                            "INNER JOIN beneficiaireroutepopoteroulante b ON l.perId = b.perId " +
                                                            "INNER JOIN routepopoteroulante r ON b.rprId = r.rprId " +
                                                            "INNER JOIN inscriptionpopoteroulante i ON l.perId = i.perId " +
                                                            "INNER JOIN inscriptionservice ins ON l.perId = ins.perId " +
                                                            "WHERE l.lprDate = '{0}' AND r.rprId = {1} AND ins.insSuspendu = 0 " +
                                                            "GROUP BY p.perId ORDER BY b.brprOrdre;";
        private const string FORMAT_REQUETE_NON_CLASSES =   "SELECT p.perNoCivique, p.perRue, p.perNoAppart, p.perPrenom, p.perNom, p.perTelephone1, i.iprSolde, l.lprNombreRepas, l.lprPrixRepas, i.iprIndicationsLivraison, ins.insCommentaires " +
                                                            "FROM livraisonpopoteroulante l " +
                                                            "INNER JOIN personne p ON l.perId = p.perId " +
                                                            "LEFT JOIN beneficiaireroutepopoteroulante b ON l.perId = b.perId " +
                                                            "INNER JOIN inscriptionpopoteroulante i ON l.perId = i.perId " +
                                                            "INNER JOIN inscriptionservice ins ON l.perId = ins.perId " +
                                                            "WHERE l.lprDate = '{0}' AND ins.insSuspendu = 0 AND b.perId IS NULL;";
        private string NumTelephoneCAB;

        public frmFeuillesRoute()
            : base(true, true)
        {
            InitializeComponent();

            NumTelephoneCAB = Global.GetConfiguration<string>("TELEPHONE_CAB");
        }

        public override void EntrerPage()
        {
            base.EntrerPage();

            DateTime maintenant = DateTime.Now;
            mcDateLivraisons.SelectionRange = new SelectionRange(maintenant, maintenant);
            mcDateLivraisons.ViewStart = maintenant;

            RequeteSelection reqSel = new RequeteSelection(NomTable.routepopoteroulante);
            reqSel.AjouterTri("rprNom");

            Table routes = Global.BaseDonneesCABS.EnvoyerRequeteSelection(reqSel);
            
            clbRoutes.Items.Clear();

            foreach (LigneTable route in routes.Lignes)
            {
                clbRoutes.Items.Add(new ComboBoxItem(route.GetValeurChamp<string>("rprNom"), route.GetValeurChamp<int>("rprId")));
            }
        }

        private void btnGenererFeuille_Click(object sender, EventArgs e)
        {
            if (clbRoutes.CheckedItems.Count <= 0 && !cbBeneficiairesNonClasses.Checked)
            {
                Journal.AfficherMessage("Veuillez sélectionner au moins une route ou les bénéficiaires non-classés avant de générer la feuille de route.", TypeMessage.INFORMATION, false);
                return;
            }

            if (!cbDetailRoute.Checked && !cbSommaireRoute.Checked && !cbSommaireLivraisons.Checked)
            {
                Journal.AfficherMessage("Veuillez sélectionner au moins une section à imprimer avant de générer la feuille de route.", TypeMessage.INFORMATION, false);
                return;
            }

            Classeur document = new Classeur();
            string date = mcDateLivraisons.SelectionStart.ToShortDateString();

            Table sommaireLivraisons = new Table("Sommaire des livraisons");

            foreach (ComboBoxItem route in clbRoutes.CheckedItems)
            {
                Table beneficiaires = Global.BaseDonneesCABS.EnvoyerRequeteSelectionDirect(String.Format(FORMAT_NOM_TABLEAU, route.Text, date, NumTelephoneCAB), 
                                                                                           String.Format(FORMAT_REQUETE_LIVRAISONS, date, route.Value.ToString()));

                GenererFeuille(beneficiaires, route.Text, sommaireLivraisons, document);
            }

            if (cbBeneficiairesNonClasses.Checked)
            {
                Table beneficiairesNonClasses = Global.BaseDonneesCABS.EnvoyerRequeteSelectionDirect(String.Format(FORMAT_NOM_TABLEAU, "Bénéficiaires non-classés", date, NumTelephoneCAB),
                                                                                                     String.Format(FORMAT_REQUETE_NON_CLASSES, date));

                if (!beneficiairesNonClasses.EstVide)
                    GenererFeuille(beneficiairesNonClasses, "Bénéficiaires non-classés", sommaireLivraisons, document);
            }

            if (cbSommaireLivraisons.Checked)
            {
                Feuille feuilleSommaireLivraisons = new Feuille("Sommaire des livraisons");
                feuilleSommaireLivraisons.AjouterTableau(new Tableau(sommaireLivraisons, 0, 28));

                document.AjouterFeuille(feuilleSommaireLivraisons);
            }

            frmPrincipal formulairePrincipal = ParentForm is frmPrincipal ? (frmPrincipal)ParentForm : null;

            if (formulairePrincipal != null)
                formulairePrincipal.AfficherIndication("Génération du document Excel");

            document.Generer();

            if (formulairePrincipal != null)
                formulairePrincipal.EffacerIndication();
        }

        private void GenererFeuille(Table beneficiaires, string nomRoute, Table sommaireLivraisons, Classeur document)
        {
            if (beneficiaires.EstVide)
                return;

            int totalNbRepas = 0;
            beneficiaires.Lignes.ForEach(l =>
            {
                int nbRepas = l.GetValeurChamp<int>("lprNombreRepas");
                decimal prixRepas = l.GetValeurChamp<decimal>("lprPrixRepas");

                totalNbRepas += nbRepas;

                //l.AjouterChamp("lprTransaction", (decimal)(nbRepas * prixRepas), "iprIndicationsLivraison");  //Enlever à la demande du CABS

                int noAppart = l.GetValeurChamp<int>("perNoAppart");
                l.RetirerChamp("perNoAppart");

                if (noAppart > 0)
                    l.GetChamp("perRue").Valeur = l.GetValeurChamp<string>("perRue") + " #" + noAppart;
            });

            beneficiaires.RetirerChamp("lprPrixRepas");

            Feuille nouvelleFeuille = new Feuille(nomRoute, 2);
            nouvelleFeuille.AjouterTableau(new Tableau(beneficiaires, 120, 28));

            if (cbSommaireRoute.Checked)
            {
                LigneTable ligneSommaire = new LigneTable("Sommaire de la route");
                ligneSommaire.AjouterChamp("Total à livrer", totalNbRepas);
                ligneSommaire.AjouterChamp("Total livrés", "");

                Table sommaireRoute = new Table("Sommaire de la route");
                sommaireRoute.AjouterLigne(ligneSommaire);

                nouvelleFeuille.AjouterTableau(new Tableau(sommaireRoute, 0, 28));
            }

            if (cbSommaireLivraisons.Checked)
            {
                LigneTable ligneSommaireLivraisons = new LigneTable("Sommaire des livraisons");
                ligneSommaireLivraisons.AjouterChamp("Route", nomRoute);
                ligneSommaireLivraisons.AjouterChamp("Total à livrer", totalNbRepas);
                ligneSommaireLivraisons.AjouterChamp("Total livrés", "");

                sommaireLivraisons.AjouterLigne(ligneSommaireLivraisons);
            }

            if(cbDetailRoute.Checked)
                document.AjouterFeuille(nouvelleFeuille);
        }
    }
}
