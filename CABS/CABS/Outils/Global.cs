using CABS.BaseDonnees;
using CABS.Outils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CABS.Outils
{
    public struct InfosChamp
    {
        public string NomEntete;
        public TypeChamp Type;
    }

    public struct InfosTable
    {
        public string NomService;
        public Dictionary<string, InfosChamp> Champs;
    }

    public static class Global
    {
        private static Dictionary<string, string> Configurations = new Dictionary<string, string>();
        private static Dictionary<string, InfosTable> TablesMySQL = new Dictionary<string, InfosTable>();
        private static Dictionary<string, string> DictionnairesFormulairesInscription = new Dictionary<string, string>();

        public const int LARGEUR_BORDURE_DGV = 3;

        private static GestionnaireBD baseDonneesCABS;

        public static GestionnaireBD BaseDonneesCABS
        {
            get
            {
                if (baseDonneesCABS == null)
                {
                    string chaineConnexion = String.Format("SERVER={0};DATABASE={1};PORT={2};UID={3};PASSWORD={4};Convert Zero DateTime=TRUE",
                                                           Global.GetConfiguration<string>("SERVEUR"), Global.GetConfiguration<string>("BD"),
                                                           Global.GetConfiguration<string>("PORT"), Global.GetConfiguration<string>("UTILISATEUR"),
                                                           Global.GetConfiguration<string>("MOT_DE_PASSE"));
                    baseDonneesCABS = new GestionnaireBD(chaineConnexion);
                }

                return baseDonneesCABS;
            }
            private set { }
        }

        public static void ChargerConfigurations(string nomFichier)
        {
            try
            {
                XDocument configurations = XDocument.Load(nomFichier);

                foreach (XElement config in configurations.Root.Elements())
                {
                    if (config.Name != "config")
                        continue;

                    XAttribute nom = config.Attributes().FirstOrDefault(a => a.Name == "nom");
                    XAttribute valeur = config.Attributes().FirstOrDefault(a => a.Name == "valeur");

                    if(nom != null && valeur != null)
                        Configurations.Add(nom.Value, valeur.Value);
                }
            }
            catch (Exception ex)
            {
                Journal.EcrireException("Erreur lors du chargement des configurations", ex);
            }
        }

        public static T GetConfiguration<T>(string nomConfiguration)
        {
            string valeurConfiguration;

            if (!Configurations.TryGetValue(nomConfiguration, out valeurConfiguration))
                return default(T);

            try
            {
                return (T)ConvertirValeur<T>(valeurConfiguration);
            }
            catch (InvalidCastException ex)
            {
                Outils.Journal.EcrireException("Erreur de conversion de la configuration '" + nomConfiguration + "'.", ex);
            }

            return default(T);
        }

        public static void ChargerDictionnairesChamps(string nomFichier)
        {
            try
            {
                XDocument tables = XDocument.Load(nomFichier);
                Dictionary<string, InfosChamp> champs;

                foreach (XElement table in tables.Root.Elements())
                {
                    if (table.Name != "table")
                        continue;

                    string nomTable = table.Attributes().FirstOrDefault(a => a.Name == "nom").Value;

                    InfosTable infosTable;
                    infosTable.NomService = table.Attributes().FirstOrDefault(a => a.Name == "service").Value;
                    champs = new Dictionary<string, InfosChamp>();

                    foreach (XElement champ in table.Elements())
                    {
                        string nomChamp = champ.Attributes().FirstOrDefault(a => a.Name == "nom").Value;

                        InfosChamp infos;

                        XAttribute nomEntete = champ.Attributes().FirstOrDefault(a => a.Name == "nomEntete");
                        infos.NomEntete = nomEntete != null ? nomEntete.Value : "";

                        XAttribute type = champ.Attributes().FirstOrDefault(a => a.Name == "type");
                        if (type == null || !Enum.TryParse<TypeChamp>(type.Value, out infos.Type))
                            infos.Type = TypeChamp.DEFAUT;

                        champs.Add(nomChamp, infos);
                    }

                    infosTable.Champs = champs;
                    TablesMySQL.Add(nomTable, infosTable);
                }
            }
            catch (Exception ex)
            {
                Journal.EcrireException("Erreur lors du chargement du dictionnaire de champs", ex);
            }
        }

        public static string GetEnteteChamp(string nomTable, string nomChamp)
        {
            if (nomTable == null || nomChamp == null)
                return "";

            InfosTable table;
            InfosChamp champ;
            string temp = nomTable.ToLower();

            if (TablesMySQL.TryGetValue(temp, out table) && table.Champs.TryGetValue(nomChamp, out champ))
            {
                return champ.NomEntete;
            }
            else
            {
                //On fouille dans toutes les tables si on avait pas le bon nom de table
                foreach (KeyValuePair<string, InfosTable> t in TablesMySQL)
                {
                    if (t.Value.Champs.TryGetValue(nomChamp, out champ))
                        return champ.NomEntete;
                }
            }

            return "";
        }

        public static TypeChamp GetTypeChamp(string nomTable, string nomChamp)
        {
            if (nomTable == null || nomChamp == null)
            {
                Journal.EcrireMessage("Tentative de GetTypeChamp avec un nom de table ou de champ invalide");
                return TypeChamp.DEFAUT;
            }

            InfosTable table;
            InfosChamp champ;

            if (TablesMySQL.TryGetValue(nomTable.ToLower(), out table) && table.Champs.TryGetValue(nomChamp, out champ))
            {
                return champ.Type;
            }
            else
            {
                //On fouille dans toutes les tables si on avait pas le bon nom de table
                foreach (KeyValuePair<string, InfosTable> t in TablesMySQL)
                {
                    if (t.Value.Champs.TryGetValue(nomChamp, out champ))
                        return champ.Type;
                }
            }

            return TypeChamp.DEFAUT;
        }

        public static void ChargerDictionnaireFormulairesInscription(string nomFichier)
        {
            try
            {
                XDocument categories = XDocument.Load(nomFichier);

                foreach (XElement categorie in categories.Root.Descendants())
                {
                    if (categorie.Name != "service")
                        continue;

                    string nomService = categorie.Attributes().First(a => a.Name == "nom").Value;
                    string nomFormulaire = categorie.Attributes().First(a => a.Name == "nomFormulaire").Value;

                    DictionnairesFormulairesInscription.Add(nomService, nomFormulaire);
                }
            }
            catch (Exception ex)
            {
                Journal.EcrireException("Erreur lors du chargement de la liste des formulaires d'inscription", ex);
            }
        }

        public static string GetNomFormulaireInscription(string nomService)
        {
            if (nomService == null)
                return "";

            string nomFormulaire;

            if (DictionnairesFormulairesInscription.TryGetValue(nomService, out nomFormulaire))
                return nomFormulaire;

            return "";
        }

        public static Menu GenererMenu(string nomFichier)
        {
            Menu m = new Menu();

            try
            {
                XDocument menu = XDocument.Load(nomFichier);

                foreach (XElement section in menu.Root.Elements())
                {
                    if (section.Name != "section")
                        continue;

                    m.AjouterSection(TraiterSection(section));
                }
            }
            catch (Exception ex)
            {
                Journal.EcrireException("Erreur lors de la génération du menu principal", ex);
            }

            return m;
        }

        private static Section TraiterSection(XElement section)
        {
            string nomSection = section.Attributes().First(a => a.Name == "nom").Value;
            Section nouvelleSection = new Section(nomSection);

            foreach (XElement enfant in section.Elements())
            {
                if (enfant.Name == "section")
                {
                    nouvelleSection.AjouterSection(TraiterSection(enfant));
                }
                else if (enfant.Name == "page")
                {
                    string nomPage = enfant.Attributes().First(a => a.Name == "nom").Value;
                    string nomFormulaire = enfant.Attributes().First(a => a.Name == "nomFormulaire").Value;

                    nouvelleSection.AjouterPage(new Page(nomPage, nomFormulaire));
                }
            }

            return nouvelleSection;
        }

        public static string GetNomTableService(string nomService)
        {
            string nService = nomService.ToLower();

            foreach (KeyValuePair<string, InfosTable> t in TablesMySQL)
            {
                if (t.Value.NomService.ToLower() != nService)
                    continue;

                return t.Key;
            }

            return "";
        }

        public static object ConvertirValeur<T>(object valeurNonConvertie)
        {
            string type = typeof(T).Name.ToLower();

            switch (type)
            {
                case "boolean":
                    bool booleen;
                    if (Boolean.TryParse(valeurNonConvertie.ToString(), out booleen))
                        return booleen;
                    break;

                case "string":
                    return valeurNonConvertie.ToString();

                case "int32":
                    int entier;
                    if (Int32.TryParse(valeurNonConvertie.ToString(), out entier))
                        return entier;
                    break;

                case "datetime":
                    DateTime date;
                    if (DateTime.TryParse(valeurNonConvertie.ToString(), out date))
                        return date;
                    break;

                case "decimal":
                    Decimal nombre;
                    if (Decimal.TryParse(valeurNonConvertie.ToString().Replace(".", ","), out nombre))
                        return nombre;
                    break;
            }

            throw new InvalidCastException();
        }
    }
}