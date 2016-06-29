using CABS.BaseDonnees;
using ExcelSDK = Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;

namespace CABS.Outils.Excel
{
    public class Classeur
    {
        public List<Feuille> Feuilles { get; private set; }

        public Classeur()
        {
            Feuilles = new List<Feuille>();
        }

        public void AjouterFeuille(Feuille nouvelleFeuille)
        {
            if (Feuilles.Exists(f => f.Nom == nouvelleFeuille.Nom))
            {
                Journal.EcrireMessage("Tentative d'ajout d'une feuille avec un nom existant!");
                return;
            }

            Feuilles.Add(nouvelleFeuille);
        }

        public void Generer()
        {
            ExcelSDK.Application appExcel = null;
            ExcelSDK.Workbooks classeurs = null;
            ExcelSDK.Workbook classeur = null;
            ExcelSDK.Worksheet feuille = null;

            try
            {
                appExcel = new ExcelSDK.Application();
                appExcel.DisplayAlerts = false;

                classeurs = appExcel.Workbooks;
                classeur = classeurs.Add();

                if (classeur.Worksheets.Count < Feuilles.Count)
                {
                    while (classeur.Worksheets.Count < Feuilles.Count)
                        classeur.Worksheets.Add(After: classeur.Worksheets[classeur.Worksheets.Count]);
                }
                else
                {
                    while (classeur.Worksheets.Count > Feuilles.Count && classeur.Worksheets.Count > 1)
                        classeur.Worksheets[classeur.Worksheets.Count].Delete();
                }

                int numFeuille = 1;

                foreach (Feuille f in Feuilles)
                {
                    feuille = classeur.Worksheets[numFeuille];
                    f.Remplir(ref feuille);
                    feuille.Name = f.Nom;

                    numFeuille++;

                    if(feuille != null)
                        Marshal.ReleaseComObject(feuille);
                }

                classeur.Worksheets[1].Activate();
                classeur.Worksheets.Select();

                appExcel.DisplayAlerts = true;
                appExcel.Visible = true;
            }
            catch (Exception ex)
            {
                Journal.AfficherException("Une erreur est survenue lors de la génération du fichier Excel. L'action a été annulée.", ex);

                if (appExcel != null && classeur != null)
                {
                    classeur.Close(false);
                    appExcel.Quit();
                }
            }
            finally
            {
                if (feuille != null) Marshal.ReleaseComObject(feuille);
                if (classeur != null) Marshal.ReleaseComObject(classeur);
                if (classeurs != null) Marshal.ReleaseComObject(classeurs);
                if (appExcel != null) Marshal.ReleaseComObject(appExcel);
            }
        }
    }
}