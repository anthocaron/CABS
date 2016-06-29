using System;
using CABS.Outils;

namespace CABS.BaseDonnees
{
    public enum TypeChamp
    {
        DEFAUT,
        BOOLEEN,
        DATE,
        TELEPHONE,
        ARGENT,
        NULL
    };

    public class Champ
    {
        public string NomTable { get; private set; }

        public string Nom { get; private set; }

        private string nomEntete;

        public string NomEntete
        {
            get
            {
                if (nomEntete == null)
                {
                    nomEntete = Global.GetEnteteChamp(NomTable, Nom);
                }

                return nomEntete;
            }

            private set { nomEntete = value; }
        }

        private TypeChamp type;

        public TypeChamp Type
        {
            get
            {
                if (type == TypeChamp.NULL)
                {
                    type = Global.GetTypeChamp(NomTable, Nom);
                }

                return type;
            }

            private set { type = value; }
        }

        public object Valeur { get; set; }

        public string ValeurSQL
        {
            get
            {
                string nomType = Valeur.GetType().Name.ToLower();

                switch (nomType)
                {
                    case "string":
                        return "'" + Valeur.ToString().Replace(@"'", @"\'") + "'";    //On ajoute un \ avant les ' pour empêcher les injections SQL
                    case "boolean":
                        return (bool)Valeur ? "1" : "0";
                    case "datetime":
                        if (type == TypeChamp.DATE)
                            return "'" + ((DateTime)Valeur).ToShortDateString() + "'";
                        else
                            return "'" + ((DateTime)Valeur).ToString() + "'";
                    case "decimal":
                        return Valeur.ToString().Replace(',', '.');
                    case "dbnull":
                        return "NULL";
                    default:
                        return Valeur.ToString();
                }
            }
            private set { }
        }

        public string ValeurExcel
        {
            get
            {
                string nomType = Valeur.GetType().Name.ToLower();

                switch (nomType)
                {
                    case "boolean":
                        return (bool)Valeur ? "Oui" : "Non";
                    case "datetime":
                        if (Type == TypeChamp.DATE)
                            return ((DateTime)Valeur).ToShortDateString();
                        else
                            return ((DateTime)Valeur).ToString();
                    case "string":
                        if (Type == TypeChamp.TELEPHONE)
                        {
                            UInt64 telephone;

                            if (UInt64.TryParse((string)Valeur, out telephone))
                                return telephone.ToString("( 000 ) 000-0000");
                            else
                                return (string)Valeur;
                        }
                        else
                            return (string)Valeur;
                    case "decimal":
                        if (Type == TypeChamp.ARGENT)
                            return ((decimal)Valeur).ToString("c");
                        else
                            return Valeur.ToString();
                    default:
                        return Valeur.ToString();
                }
            }
            private set { }
        }

        public object ValeurWord
        {
            get
            {
                string nomType = Valeur.GetType().Name.ToLower();

                switch (nomType)
                {
                    case "datetime":
                        if (Type == TypeChamp.DATE)
                            return ((DateTime)Valeur).ToShortDateString();
                        else
                            return ((DateTime)Valeur).ToString();
                    case "string":
                        if (Type == TypeChamp.TELEPHONE)
                        {
                            UInt64 telephone;

                            if (UInt64.TryParse((string)Valeur, out telephone))
                                return telephone.ToString("( 000 ) 000-0000");
                            else
                                return (string)Valeur;
                        }
                        else
                            return (string)Valeur;
                    case "decimal":
                        if (Type == TypeChamp.ARGENT)
                            return ((decimal)Valeur).ToString("c");
                        else
                            return Valeur.ToString();
                    default:
                        return Valeur;
                }
            }
            private set { }
        }

        public Champ(string nomTable, string nom, object valeur)
        {
            NomTable = nomTable;
            Nom = nom;
            Valeur = valeur;
            nomEntete = null;
            type = TypeChamp.NULL;
        }
    }
}