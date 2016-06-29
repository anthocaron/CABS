using CABS.BaseDonnees;
using ExcelSDK = Microsoft.Office.Interop.Excel;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace CABS.Outils.Excel
{
    public class Feuille
    {
        private const int NB_LETTRES_ALPHABET = 26;
        private const int CODE_ASCII_A = 65;

        private int noLigne;
        private int noColonne;

        public string Nom { get; private set; }
        public List<Tableau> Tableaux { get; private set; }
        public int LigneSeparation { get; set; }

        public Feuille(string nom, int ligneSeparation = 0)
        {
            Nom = nom;
            Tableaux = new List<Tableau>();
            LigneSeparation = ligneSeparation;
        }

        public void AjouterTableau(Tableau tableau)
        {
            Tableaux.Add(tableau);
        }

        public void Remplir(ref ExcelSDK.Worksheet feuille)
        {
            noLigne = 1;

            if (LigneSeparation > 0)
            {
                feuille.Activate();
                feuille.Application.ActiveWindow.SplitRow = LigneSeparation;
                feuille.Application.ActiveWindow.FreezePanes = true;
            }

            foreach (Tableau tab in Tableaux)
            {
                GenererTableau(ref feuille, tab);
            }

            feuille.Columns.AutoFit();

            noLigne = 1;

            foreach (Tableau tab in Tableaux)
            {
                if (tab.HauteurLignes > 0)
                    continue;

                int nbLigneTableau = tab.NombreLignes;
                feuille.get_Range("A" + noLigne.ToString(), "A" + (noLigne + nbLigneTableau - 1).ToString()).Rows.AutoFit();
                noLigne += nbLigneTableau;
            }

            feuille.PageSetup.CenterHeader = Nom;
            feuille.PageSetup.RightHeader = "CAB Des Sources";
            feuille.PageSetup.CenterFooter = "&D &T";
            feuille.PageSetup.RightFooter = "Page &P de &N";

            feuille.PageSetup.PrintArea = feuille.UsedRange.Address;
            feuille.PageSetup.Orientation = ExcelSDK.XlPageOrientation.xlLandscape;
            feuille.PageSetup.CenterHorizontally = true;
            feuille.PageSetup.Zoom = false;
            feuille.PageSetup.FitToPagesWide = 1;
            feuille.PageSetup.FitToPagesTall = false;
        }

        private void GenererTableau(ref ExcelSDK.Worksheet feuille, Tableau tableau)
        {
            ExcelSDK.Range cellules = null;
            Table donnees = tableau.Donnees;
            int nbChamps = donnees.EstVide ? 1 : donnees.NombreChampsParLigne;

            try
            {
                noColonne = 0;

                int noPremiereLigne = noLigne;

                string nomCellule1 = GetNomColonne(noColonne) + noLigne.ToString();
                string nomCellule2 = GetNomColonne(nbChamps - 1) + noLigne.ToString();

                foreach (string titre in tableau.Titres)
                {
                    cellules = feuille.get_Range(nomCellule1, nomCellule2);
                    cellules.Merge();
                    cellules.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    cellules.Value = titre;
                    cellules.Font.Bold = true;

                    ++noLigne;

                    nomCellule1 = GetNomColonne(noColonne) + noLigne.ToString();
                    nomCellule2 = GetNomColonne(nbChamps - 1) + noLigne.ToString();
                }

                if (!donnees.EstVide)
                {
                    foreach (Champ c in donnees.Lignes[0].Champs)
                    {
                        nomCellule1 = GetNomColonne(noColonne) + noLigne.ToString();
                        cellules = feuille.get_Range(nomCellule1);

                        string nom = c.NomEntete;
                        cellules.Value = (nom == null || nom == "") ? c.Nom : nom;

                        cellules.Font.Bold = true;
                        ++noColonne;
                    }

                    foreach (LigneTable ligne in donnees.Lignes)
                    {
                        ++noLigne;
                        noColonne = 0;

                        foreach (Champ c in ligne.Champs)
                        {
                            nomCellule1 = GetNomColonne(noColonne) + noLigne.ToString();
                            cellules = feuille.get_Range(nomCellule1);
                            cellules.Value = c.ValeurExcel;

                            ++noColonne;
                        }
                    }
                }

                if (tableau.HauteurLignes > 0)
                {
                    nomCellule1 = GetNomColonne(0) + noPremiereLigne.ToString();
                    nomCellule2 = GetNomColonne(nbChamps - 1) + noLigne.ToString();
                    cellules = feuille.get_Range(nomCellule1, nomCellule2);
                    cellules.RowHeight = tableau.HauteurLignes;
                }

                nomCellule1 = GetNomColonne(0) + noPremiereLigne.ToString();
                nomCellule2 = GetNomColonne(nbChamps - 1) + noLigne.ToString();

                cellules = feuille.get_Range(nomCellule1, nomCellule2);
                cellules.Borders.LineStyle = ExcelSDK.XlLineStyle.xlContinuous;
                cellules.Borders.Weight = 2;
                cellules.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                if (tableau.GrosseurPolice > 0 && tableau.GrosseurPolice < 410)
                    cellules.Font.Size = tableau.GrosseurPolice;

                noLigne += 2;
            }
            catch (Exception ex)
            {
                Journal.EcrireException("Erreur Excel", ex);
            }
            finally
            {
                if (cellules != null) Marshal.ReleaseComObject(cellules);
            }
        }

        private string GetNomColonne(int indexColonne)
        {
            string nom = "";
            int reste = indexColonne;
            int i = 0;
            int temp;
            char c;

            do
            {
                temp = reste % (int)(Math.Pow(NB_LETTRES_ALPHABET, i + 1));
                c = (char)((temp / (int)Math.Pow(NB_LETTRES_ALPHABET, i)) + CODE_ASCII_A);
                nom = c + nom;
                reste -= temp + 1;
                ++i;
            } while (reste > 0);

            return nom;
        }
    }
}
