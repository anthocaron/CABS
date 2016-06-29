using CABS.BaseDonnees;
using CABS.Outils;
using CABS.Outils.Word;
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
    public partial class frmRecusImpot : Formulaire
    {
        private static string FORMAT_REQ = "SELECT p.perNom, p.perPrenom, p.perNoCivique, p.perRue, p.perNoAppart, p.perVille, p.perCasePostale, p.perCodePostal, coalesce(sum(l.lprNombreRepas), 0) as recNbRepas, coalesce(sum(l.lprNombreRepas * l.lprPrixRepas), 0.00) as recMontantClient FROM personne p " +
                                           "INNER JOIN inscriptionpopoteroulante ipr ON ipr.perId = p.perId INNER JOIN inscriptionservice ins ON ins.perId = p.perId LEFT JOIN livraisonpopoteroulante l ON l.perId = p.perId " +
                                           "WHERE timestampdiff(year, p.perDateNaissance, curdate()) >= {0} AND ins.insSuspendu = 0 AND p.staId = (SELECT staId FROM Statut WHERE staNom LIKE 'Actif') AND (l.lprDate BETWEEN '{1}' AND '{2}') GROUP BY p.perId;";

        private Table Recus;
        private int IndexRecu;
        private Gabarit GabaritRecu;

        public frmRecusImpot()
            : base(true, true)
        {
            InitializeComponent();

            Recus = new Table("recupopote");
            IndexRecu = -1;
            GabaritRecu = new Gabarit(Global.GetConfiguration<string>("GABARIT_RECU_POPOTE"));

            dtpDu.ValueChanged += new EventHandler(InformationsChangees);
            dtpAu.ValueChanged += new EventHandler(InformationsChangees);
            dtpDateEmission.ValueChanged += new EventHandler(InformationsChangees);
            nudAgeMinimum.ValueChanged += new EventHandler(InformationsChangees);
            nudPourcentageRemboursement.ValueChanged += new EventHandler(InformationsChangees);
        }

        private void frmRecusImpot_Load(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;

            dtpDu.Value = new DateTime(date.Year, 1, 1);
            dtpAu.Value = new DateTime(date.Year, 12, 31);
            dtpDateEmission.Value = date;

            nudAgeMinimum.Value = Global.GetConfiguration<int>("AGE_MINIMUM_RECU_POPOTE");
            nudPourcentageRemboursement.Value = Global.GetConfiguration<int>("POURCENTAGE_RECU_POPOTE");
        }

        private void InformationsChangees(object sender, EventArgs e)
        {
            lblAvertissement.Visible = true;
        }

        private void btnCalculerRecus_Click(object sender, EventArgs e)
        {
            lblAvertissement.Visible = false;
            Recus.Vider();

            Table infosRecus = Global.BaseDonneesCABS.EnvoyerRequeteSelectionDirect("", String.Format(FORMAT_REQ, Decimal.ToInt32(nudAgeMinimum.Value), dtpDu.Value.ToShortDateString(), dtpAu.Value.ToShortDateString()));
            Champ temp;

            foreach(LigneTable infosRecu in infosRecus.Lignes)
            {
                LigneTable recu = new LigneTable("recupopote");

                int nbRepas = infosRecu.GetValeurChamp<int>("recNbRepas");

                recu.AjouterChamp("recNbRepas1", nbRepas);
                recu.AjouterChamp("recNbRepas2", nbRepas);
                recu.AjouterChamp("recNbRepas3", nbRepas);

                decimal montantClient = infosRecu.GetValeurChamp<decimal>("recMontantClient");

                recu.AjouterChamp("recMontantClient1", montantClient);
                recu.AjouterChamp("recMontantClient2", montantClient);
                recu.AjouterChamp("recMontantClient3", montantClient);

                string dateEmission = dtpDateEmission.Value.ToLongDateString();

                recu.AjouterChamp("recDateEmission1", dateEmission);
                recu.AjouterChamp("recDateEmission2", dateEmission);
                recu.AjouterChamp("recDateEmission3", dateEmission);

                string nom = infosRecu.GetValeurChamp<string>("perPrenom") + " " + infosRecu.GetValeurChamp<string>("perNom");

                recu.AjouterChamp("recNom1", nom);
                recu.AjouterChamp("recNom2", nom);
                recu.AjouterChamp("recNom3", nom);

                string adresse = infosRecu.GetValeurChamp<int>("perNoCivique").ToString() + ", " + infosRecu.GetValeurChamp<string>("perRue");

                if ((temp = infosRecu.GetChamp("perNoAppart")) != null && temp.Valeur != DBNull.Value)
                    adresse += ", app. " + temp.Valeur.ToString();

                if ((temp = infosRecu.GetChamp("perCasePostale")) != null && temp.Valeur != DBNull.Value)
                    adresse += ", CP " + temp.Valeur.ToString();

                adresse += ", " + infosRecu.GetValeurChamp<string>("perVille") + ", Québec, " + infosRecu.GetValeurChamp<string>("perCodePostal");

                recu.AjouterChamp("recAdresse1", adresse);
                recu.AjouterChamp("recAdresse2", adresse);
                recu.AjouterChamp("recAdresse3", adresse);
                
                decimal montantAdmissible = montantClient * (nudPourcentageRemboursement.Value / 100.0m);
                string montantAdmissibleMots = OutilsForms.ConvertirNombreEnMots(montantAdmissible);
                int sousMontantAdmissible = Decimal.ToInt32(Math.Floor((montantAdmissible - Math.Floor(montantAdmissible)) * 100.0m));
                
                recu.AjouterChamp("recMontantMots1", montantAdmissibleMots);
                recu.AjouterChamp("recMontantMots2", montantAdmissibleMots);
                recu.AjouterChamp("recMontantMots3", montantAdmissibleMots);
                recu.AjouterChamp("recSous1", sousMontantAdmissible);
                recu.AjouterChamp("recSous2", sousMontantAdmissible);
                recu.AjouterChamp("recSous3", sousMontantAdmissible);
                recu.AjouterChamp("recMontantGras1", montantAdmissible);
                recu.AjouterChamp("recMontantGras2", montantAdmissible);
                recu.AjouterChamp("recMontantGras3", montantAdmissible);
                recu.AjouterChamp("recMontantAdmis1", montantAdmissible);
                recu.AjouterChamp("recMontantAdmis2", montantAdmissible);
                recu.AjouterChamp("recMontantAdmis3", montantAdmissible);

                string du = dtpDu.Value.ToLongDateString();
                string au = dtpAu.Value.ToLongDateString();

                recu.AjouterChamp("recDu1", du);
                recu.AjouterChamp("recDu2", du);
                recu.AjouterChamp("recDu3", du);
                recu.AjouterChamp("recAu1", au);
                recu.AjouterChamp("recAu2", au);
                recu.AjouterChamp("recAu3", au);

                Recus.AjouterLigne(recu);
            }

            IndexRecu = Recus.EstVide ? -1 : 0;

            ChangerAccesControle(ModeFormulaire.CONSULTATION);
        }

        private void btnPrecedent10_Click(object sender, EventArgs e)
        {
            IndexRecu = IndexRecu < 10 ? 0 : IndexRecu - 10;
            ChangerAccesControle(ModeFormulaire.CONSULTATION);
        }

        private void btnPrecedent_Click(object sender, EventArgs e)
        {
            IndexRecu--;
            ChangerAccesControle(ModeFormulaire.CONSULTATION);
        }

        private void btnSuivant_Click(object sender, EventArgs e)
        {
            IndexRecu++;
            ChangerAccesControle(ModeFormulaire.CONSULTATION);
        }

        private void btnSuivant10_Click(object sender, EventArgs e)
        {
            IndexRecu = IndexRecu + 10 >= Recus.NombreLignes ? Recus.NombreLignes - 1 : IndexRecu + 10;
            ChangerAccesControle(ModeFormulaire.CONSULTATION);
        }

        public override void ChangerAccesControle(ModeFormulaire mode)
        {
            base.ChangerAccesControle(mode);

            btnPrecedent10.Enabled = btnPrecedent.Enabled = IndexRecu > 0;
            btnSuivant10.Enabled = btnSuivant.Enabled = IndexRecu < Recus.NombreLignes - 1;
            btnGenererRecu.Enabled = !Recus.EstVide;

            lblIndexCourant.Text = (IndexRecu + 1).ToString() + " de " + Recus.NombreLignes.ToString();
            lblBeneficiaireCourantValeur.Text = IndexRecu > -1 ? Recus.Lignes[IndexRecu].GetValeurChamp<string>("recNom1") : "";
        }

        private void btnGenererRecu_Click(object sender, EventArgs e)
        {
            GabaritRecu.Generer(Recus.Lignes[IndexRecu]);
        }
    }
}
