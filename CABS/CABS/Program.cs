using System;
using System.Windows.Forms;
using CABS.Formulaires;
using CABS.Outils;

namespace CABS
{
    internal static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
#if (!DEBUG)
            try
            {
#endif
                Global.ChargerConfigurations("data/config.xml");
                Global.ChargerDictionnairesChamps("data/tables.xml");
                Global.ChargerDictionnaireFormulairesInscription("data/formulairesInscription.xml");

                if (!Global.BaseDonneesCABS.Connecter())
                {
                    Journal.AfficherMessage("Une erreur est survenue lors de la connexion à la base de données.\nL'application sera fermée.", TypeMessage.ERREUR, false);
                    return;
                }

                Journal.EcrireMessage("Connexion à la base de données réussie.");

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmPrincipal());

                if (Global.BaseDonneesCABS.Deconnecter())
                {
                    Journal.EcrireMessage("Déconnexion à la base de données réussie.");
                }
#if (!DEBUG)
            }
            catch (Exception ex)
            {
                Journal.AfficherException("Une erreur inattendue est survenue. Contactez le développeur de l'application. L'application va se fermer maintenant.", ex);
            }
#endif
        }
    }
}