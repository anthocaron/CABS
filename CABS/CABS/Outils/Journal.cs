using System;
using System.IO;
using System.Windows.Forms;

namespace CABS.Outils
{
    public enum TypeMessage
    {
        ERREUR,
        AVERTISSEMENT,
        INFORMATION
    };

    public static class Journal
    {
        private static long LimiteFichierJournal = 10485760;
        private static StreamWriter FichierJournal;
        private static bool AvertissementFait = false;

        private static bool Ouvrir()
        {
            string nomFichierJournal = Global.GetConfiguration<string>("NOM_FICHIER_JOURNAL");

            try
            {
                FileInfo infos = new FileInfo(nomFichierJournal);

                if (!infos.Exists)
                {
                    FileStream f = File.Create(nomFichierJournal);
                    f.Close();
                    infos.Refresh();
                }

                bool ajout = infos.Length <= LimiteFichierJournal;
                FichierJournal = new StreamWriter(nomFichierJournal, ajout);
            }
            catch (Exception ex)
            {
                AvertirUsager(ex);
                return false;
            }

            return true;
        }

        private static void Fermer()
        {
            if (FichierJournal == null)
            {
                AvertirUsager(new ArgumentNullException("FichierRegistre", "Le fichier du journal n'a probablement pas été ouvert."));
                return;
            }

            try
            {
                FichierJournal.Close();
            }
            catch (Exception ex)
            {
                AvertirUsager(ex);
            }
        }

        private static void AvertirUsager(Exception ex)
        {
            if (!AvertissementFait)
            {
                MessageBox.Show("Il y a présentement un problème avec le journal de l'application.\n" +
                                "Prévenez le développeur de l'application et faites lui parvenir ce message d'erreur :\n\n" + ex.Message,
                                "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                AvertissementFait = true;
            }
        }

        public static void AfficherMessage(string message, TypeMessage type, bool ecrireJournal)
        {
            string titre;
            MessageBoxIcon icone;

            switch (type)
            {
                case TypeMessage.ERREUR:
                    titre = "Erreur";
                    icone = MessageBoxIcon.Error;
                    break;

                case TypeMessage.AVERTISSEMENT:
                    titre = "Avertissement";
                    icone = MessageBoxIcon.Warning;
                    break;

                case TypeMessage.INFORMATION:
                    titre = "Information";
                    icone = MessageBoxIcon.Information;
                    break;

                default:
                    titre = "";
                    icone = MessageBoxIcon.None;
                    break;
            }

            MessageBox.Show(message, titre, MessageBoxButtons.OK, icone);

            if (ecrireJournal)
            {
                string messageJournal = String.Format("{0} {1}", titre, message);
                EcrireMessage(messageJournal);
            }
        }

        public static void AfficherException(string message, Exception ex)
        {
            message = String.Format("{0}\nMessage exception :\n{1}", message, ex.Message);
            AfficherMessage(message, TypeMessage.ERREUR, true);
        }

        public static void EcrireException(string message, Exception ex)
        {
            string messageException = String.Format("{0}\nMessage exception :\n{1}\nPile :\n{2}", message, ex.Message, ex.StackTrace);
            EcrireMessage(messageException);
        }

        public static void EcrireMessage(string message)
        {
            string ligneRegistre = String.Format("[ {0} {1} ] {2}\n", DateTime.Now.ToLongDateString(), DateTime.Now.ToLongTimeString(), message);

            if (Ouvrir())
            {
                FichierJournal.WriteLine(ligneRegistre);
            }

            Fermer();
        }
    }
}