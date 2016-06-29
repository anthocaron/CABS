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
    public partial class frmGestionSoldes : Formulaire
    {
        private static string RequeteBeneficiaire = "SELECT p.perId, p.perNom, p.perPrenom, ip.iprSolde FROM personne p INNER JOIN inscriptionservice i ON p.perId = i.perId INNER JOIN inscriptionpopoteroulante ip ON p.perId = ip.perId WHERE i.insSuspendu = 0 GROUP BY p.perId ORDER BY p.perNom, p.perPrenom, p.perDateNaissance;";

        private decimal AncienSolde;

        public frmGestionSoldes()
            : base(true, true)
        {
            InitializeComponent();

            AncienSolde = 0.0m;
            dgvSoldes.Columns["Solde"].DefaultCellStyle.Format = "c";
        }

        public override void EntrerPage()
        {
            base.EntrerPage();

            dgvSoldes.Rows.Clear();
            Table beneficiaires = Global.BaseDonneesCABS.EnvoyerRequeteSelectionDirect("Beneficiaire", RequeteBeneficiaire);

            foreach (LigneTable beneficiaire in beneficiaires.Lignes)
            {
                dgvSoldes.Rows.Add(beneficiaire.GetValeurChamp<int>("perId"), beneficiaire.GetValeurChamp<string>("perNom"), 
                                   beneficiaire.GetValeurChamp<string>("perPrenom"), beneficiaire.GetValeurChamp<decimal>("iprSolde"));
            }
        }

        private void dgvSoldes_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgvSoldes.Columns[e.ColumnIndex].Name == "solde")
            {
                decimal temp;

                if (Decimal.TryParse(dgvSoldes.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out temp))
                    AncienSolde = temp;
                else
                    AncienSolde = 0;
            }
        }

        private void dgvSoldes_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSoldes.Columns[e.ColumnIndex].Name == "solde")
            {
                DataGridViewRow ligne = dgvSoldes.Rows[e.RowIndex];

                decimal temp;
                bool reussi = Decimal.TryParse(ligne.Cells[e.ColumnIndex].Value.ToString().Replace('.', ','), out temp);

                if (reussi)
                {
                    RequeteModification reqModif = new RequeteModification(NomTable.inscriptionpopoteroulante, new ConditionRequete(Operateur.EGAL, "perId", ligne.Cells["Id"].Value.ToString()),
                                                                           "iprSolde", temp.ToString().Replace(',', '.'));

                    if (Global.BaseDonneesCABS.EnvoyerRequeteModification(reqModif) < 0)
                    {
                        Journal.AfficherMessage("Une erreur est survenue lors de la modification du solde du bénéficiaire. L'action a été annulée.", TypeMessage.ERREUR, true);
                        reussi = false;
                    }
                }
                else
                {
                    Journal.AfficherMessage("Veuillez entrer un solde valide. Le solde va être remis à l'ancienne valeur.", TypeMessage.INFORMATION, false);
                }

                dgvSoldes.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = reussi ? temp : AncienSolde;
            }
        }
    }
}
