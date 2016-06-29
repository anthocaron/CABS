using CABS.BaseDonnees;
using CABS.Outils;
using System;
using System.IO;

namespace GenerateurInfosBD
{
    internal class Program
    {
        private static string DebutFichier =    "namespace CABS.BaseDonnees\n" +
                                                "{\n";
        private static string FinFichier =      "}\n";

        private static void Main(string[] args)
        {
            Global.ChargerConfigurations("data/config.xml");

            if (!Global.BaseDonneesCABS.Connecter())
            {
                Console.WriteLine("Erreur lors de la connexion à la base de données. Impossible de mettre à jour le fichier.");
                return;
            }

            try
            {
                string contenu = DebutFichier;
                string enumNomsTables = "\tpublic enum NomTable\n" +
                                    "\t{\n";
                bool premiereTable = true;
                Table tables = Global.BaseDonneesCABS.EnvoyerRequeteSelectionDirect("Tables", "SELECT TABLE_NAME FROM information_schema.tables WHERE TABLE_SCHEMA = DATABASE();");

                string classesTables = "";

                foreach (LigneTable table in tables.Lignes)
                {
                    string nomTable = table.GetValeurChamp<string>("TABLE_NAME");

                    if (nomTable.Length <= 0)
                        continue;
                    else if (!premiereTable)
                        enumNomsTables += ",\n";
                    else
                        premiereTable = false;

                    enumNomsTables += "\t\t" + nomTable;
                    classesTables += "\n\tpublic static class " + nomTable + "\n\t{\n";

                    bool premiereColonne = true;
                    Table colonnes = Global.BaseDonneesCABS.EnvoyerRequeteSelectionDirect("Colonnes", "SELECT COLUMN_NAME FROM information_schema.columns WHERE TABLE_SCHEMA = DATABASE() AND TABLE_NAME = '" + nomTable + "';");

                    foreach (LigneTable colonne in colonnes.Lignes)
                    {
                        string nomColonne = colonne.GetValeurChamp<string>("COLUMN_NAME");

                        if (nomColonne.Length <= 0)
                            continue;
                        else if (!premiereColonne)
                            classesTables += "\n";
                        else
                            premiereColonne = false;

                        classesTables += "\t\tpublic static string " + nomColonne + " = \"" + nomColonne + "\";";
                    }

                    classesTables += "\n\t};\n";
                }

                enumNomsTables += "\n\t};\n";

                contenu += enumNomsTables + classesTables + FinFichier;
                File.WriteAllText(args[0], contenu);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : " + ex.Message);
            }
        }
    }
}