using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using CABS.BaseDonnees;

namespace CABS.Outils
{
    public partial class GrilleTable : UserControl
    {
        private Table Donnees;
        private Table DonneesNonFiltrees;
        private List<string> ChampsAffiches;

        public delegate void RowDoubleClickEventHandler(object sender, RowDoubleClickEventArgs e);

        public event RowDoubleClickEventHandler RowDoubleClick;

        public int LargeurColonnes
        {
            get
            {
                int largeur = 0;

                foreach (DataGridViewColumn colonne in dgvGrille.Columns)
                    largeur += colonne.Width;

                return largeur;
            }

            private set { LargeurColonnes = value; }
        }

        public bool EstVide
        {
            get
            {
                return Donnees == null || Donnees.EstVide;
            }

            private set { EstVide = value; }
        }

        public GrilleTable()
        {
            InitializeComponent();

            Donnees = null;
            DonneesNonFiltrees = null;
            ChampsAffiches = null;
        }

        public void Initialiser(Table donnees, List<string> champsAffiches)
        {
            if (donnees != null)
            {
                Donnees = donnees;
                DonneesNonFiltrees = donnees;
            }

            if (champsAffiches != null)
                ChampsAffiches = champsAffiches;
        }

        public void Rafraichir(Table donnees, List<string> champsAffiches)
        {
            Vider();
            Initialiser(donnees, champsAffiches);
            Charger();
            Refresh();
        }

        public void Vider()
        {
            dgvGrille.DataSource = null;
            dgvGrille.Rows.Clear();
            dgvGrille.Columns.Clear();
        }

        public void Charger()
        {
            DataTable table = new DataTable();

            if (Donnees != null && !Donnees.EstVide)
            {
                int indexLigne = 0;
                table.Columns.Add("Index");

                Donnees.Lignes[0].Champs.Where(c => ChampsAffiches.Contains(c.Nom)).ToList().ForEach(c => table.Columns.Add(c.NomEntete));

                foreach (LigneTable ligne in Donnees.Lignes)
                {
                    List<object> nouvelleLigne = new List<object>();

                    nouvelleLigne.Add(indexLigne);
                    indexLigne++;

                    foreach (Champ champ in ligne.Champs.Where(c => ChampsAffiches.Contains(c.Nom)))
                    {
                        switch (champ.Type)
                        {
                            case TypeChamp.DATE:
                                DateTime date;

                                if (DateTime.TryParse(champ.Valeur.ToString(), out date))
                                    nouvelleLigne.Add(date.ToShortDateString());
                                break;

                            case TypeChamp.TELEPHONE:
                                UInt64 telephone;

                                if (UInt64.TryParse(champ.Valeur.ToString(), out telephone))
                                    nouvelleLigne.Add(telephone.ToString("( 000 ) 000-0000"));
                                break;

                            default:
                                nouvelleLigne.Add(champ.Valeur);
                                break;
                        }
                    }

                    table.Rows.Add(nouvelleLigne.ToArray());
                }
            }

            dgvGrille.DataSource = table.AsDataView();

            if (Donnees != null && !Donnees.EstVide)
            {
                dgvGrille.Columns["Index"].Width = 0;
                dgvGrille.Columns["Index"].Visible = false;
            }
        }

        private void txtRecherche_TextChanged(object sender, EventArgs e)
        {
            if (dgvGrille.DataSource == null)
                return;

            DataTable table = ((DataView)dgvGrille.DataSource).Table;

            EnumerableRowCollection<DataRow> requete = from ligne in table.AsEnumerable()
                                                       where ligne.ItemArray.ToList().Where(i => i.ToString().IndexOf(txtRecherche.Text, StringComparison.OrdinalIgnoreCase) >= 0).Count() > 0
                                                       select ligne;

            dgvGrille.DataSource = requete.AsDataView();
        }

        public LigneTable GetLigneSelectionnee()
        {
            if (dgvGrille.SelectedRows.Count <= 0)
                return null;

            int indexLigneSelectionnee = Int32.Parse(dgvGrille.SelectedRows[0].Cells["Index"].Value.ToString());
            return Donnees.Lignes[indexLigneSelectionnee];
        }

        private void dgvGrille_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (RowDoubleClick != null && e.ColumnIndex > -1 && e.RowIndex > -1)
            {
                RowDoubleClick(this, new RowDoubleClickEventArgs(GetLigneSelectionnee()));
            }
        }
    }

    public class RowDoubleClickEventArgs
    {
        public RowDoubleClickEventArgs(LigneTable ligneCliquee)
        {
            LigneCliquee = ligneCliquee;
        }

        public LigneTable LigneCliquee { get; private set; }
    }
}