using CABS.BaseDonnees;
using WordSDK = Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;

namespace CABS.Outils.Word
{
    class Gabarit
    {
        private string NomFichier;

        public Gabarit(string fileName)
        {
            NomFichier = fileName;
        }

        public void Generer(LigneTable donnees)
        {
            WordSDK.Application appWord = null;
            WordSDK.Document doc = null;

            try
            {
                appWord = new WordSDK.Application();
                appWord.DisplayAlerts = WordSDK.WdAlertLevel.wdAlertsNone;

                doc = appWord.Documents.Add(Directory.GetCurrentDirectory() + "\\" + NomFichier, Visible: false);
                doc.Activate();

                foreach (WordSDK.FormField field in doc.FormFields)
                {
                    Champ champ = donnees.GetChamp(field.Name);
                    
                    if (champ != null)
                    {
                        switch(champ.Type)
                        {
                            case TypeChamp.BOOLEEN:
                                field.CheckBox.Value = (bool)champ.ValeurWord;
                                break;
                            default:
                                field.Range.Text = champ.ValeurWord.ToString();
                                break;
                        }
                    }
                }

                appWord.DisplayAlerts = WordSDK.WdAlertLevel.wdAlertsAll;
                appWord.Visible = true;
            }
            catch (Exception ex)
            {
                Journal.AfficherException("Une erreur est survenue lors de la génération du fichier Word. L'action a été annulée.", ex);

                if (appWord != null && doc != null)
                {
                    doc.Close(false);
                    appWord.Quit();
                }
            }
            finally
            {
                if (doc != null) Marshal.ReleaseComObject(doc);
                if (appWord != null) Marshal.ReleaseComObject(appWord);
            }
        }
    }
}
