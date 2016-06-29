using CABS.Outils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CABS.BaseDonnees
{
    public enum Operateur
    {
        EGAL,
        PP,
        PPE,
        PG,
        PGE,
        DIF,
        COMME   //EGAL pour string
    };

    public class ConditionRequete
    {
        public string Texte { get; private set; }

        public ConditionRequete(Operateur oper, string nomChamp, string valeur)
        {
            if ((nomChamp == null || valeur == null) || (nomChamp == "" || valeur == ""))
            {
                Journal.EcrireMessage("Erreur lors de la création d'une condition.");
                return;
            }

            Texte = nomChamp + " " + GetTexteOperateur(oper) + " " + valeur;
        }

        public ConditionRequete(Operateur oper, Champ champ)
        {
            if ((champ.Nom == null || champ.ValeurSQL == null) || (champ.Nom == "" || champ.ValeurSQL == ""))
            {
                Journal.EcrireMessage("Erreur lors de la création d'une condition.");
                return;
            }

            Texte = champ.Nom + " " + GetTexteOperateur(oper) + " " + champ.ValeurSQL;
        }

        public ConditionRequete(ConditionRequete cond)
        {
            Texte = cond.Texte;
        }

        private string GetTexteOperateur(Operateur oper)
        {
            switch (oper)
            {
                case Operateur.EGAL:
                    return "=";
                case Operateur.PP:
                    return "<";
                case Operateur.PPE:
                    return "<=";
                case Operateur.PG:
                    return ">";
                case Operateur.PGE:
                    return ">=";
                case Operateur.DIF:
                    return "!=";
                case Operateur.COMME:
                    return "LIKE BINARY";
                default:
                {
                    Journal.EcrireMessage("Opérateur non-géré.");
                    return "";
                }
            }
        }

        public void LierCondition(ConditionRequete condition, bool conjonction)
        {
            string lien = conjonction ? " AND " : " OR ";
            Texte += lien + condition.Texte;
        }
    }

    public class RequeteSelection
    {
        private static string ChaineSelection = "SELECT {0} FROM {1}{2}{3};";

        public string NomTable { get; private set; }
        private string NomsChamps;
        public ConditionRequete Condition;
        private string Tris;

        public string Texte
        {
            get
            {
                string conditions = Condition != null ? " WHERE " + Condition.Texte : "";
                string tris = Tris != "" ? " ORDER BY " + Tris : "";

                return String.Format(ChaineSelection, NomsChamps, NomTable, conditions, tris);
            }
            private set { }
        }

        public RequeteSelection(NomTable nomTable)
        {
            NomTable = System.Enum.GetName(typeof(NomTable), nomTable);
            NomsChamps = "*";
            Condition = null;
            Tris = "";
        }

        public RequeteSelection(NomTable nomTable, params string[] nomsChamps)
        {
            NomTable = System.Enum.GetName(typeof(NomTable), nomTable);
            NomsChamps = "*";
            Condition = null;
            Tris = "";

            AjouterChamps(nomsChamps);
        }

        public RequeteSelection(RequeteSelection req)
        {
            NomTable = req.NomTable;
            NomsChamps = req.NomsChamps;
            Condition = req.Condition;
            Tris = req.Tris;
        }

        public void AjouterChamps(params string[] nomsChamps)
        {
            foreach (string nomChamp in nomsChamps)
            {
                if (nomChamp == "" || nomChamp == null)
                {
                    Journal.EcrireMessage("Erreur lors de l'ajout d'un champ dans une requête sélection.");
                    continue;
                }

                if (NomsChamps == "*")
                    NomsChamps = nomChamp;
                else
                    NomsChamps += ", " + nomChamp;
            }
        }

        public void AjouterTri(string nomChamp, bool croissant = true)
        {
            string type = croissant ? "ASC" : "DESC";

            if (Tris != "")
                Tris += ", ";

            Tris += nomChamp + " " + type;
        }
    }

    public class RequeteAjout
    {
        private static string ChaineAjout = "INSERT INTO {0} ({1}) VALUES({2});";

        public string NomTable { get; private set; }
        private string NomsChamps;
        private string Valeurs;

        public string Texte
        {
            get
            {
                return String.Format(ChaineAjout, NomTable, NomsChamps, Valeurs);
            }
            private set { }
        }

        public RequeteAjout(NomTable nomTable, string premierNomChamp, string premiereValeur)
        {
            NomTable = System.Enum.GetName(typeof(NomTable), nomTable);
            NomsChamps = "";
            Valeurs = "";

            AjouterValeur(premierNomChamp, premiereValeur);
        }

        public RequeteAjout(NomTable nomTable, params Champ[] champs)
        {
            NomTable = System.Enum.GetName(typeof(NomTable), nomTable);
            NomsChamps = "";
            Valeurs = "";

            AjouterValeur(champs);
        }

        public RequeteAjout(NomTable nomTable, LigneTable ligne)
        {
            NomTable = System.Enum.GetName(typeof(NomTable), nomTable);
            NomsChamps = "";
            Valeurs = "";

            AjouterValeur(ligne);
        }

        public RequeteAjout(RequeteAjout req)
        {
            NomTable = req.NomTable;
            NomsChamps = req.NomsChamps;
            Valeurs = req.Valeurs;
        }

        public void AjouterValeur(string nomChamp, string valeur)
        {
            if ((nomChamp == null || valeur == null) || (nomChamp == "" || valeur == ""))
            {
                Journal.EcrireMessage("Erreur lors de l'ajout d'une valeur dans une requête ajout.");
                return;
            }

            if (NomsChamps != "")
                NomsChamps += ", ";

            NomsChamps += nomChamp;

            if (Valeurs != "")
                Valeurs += ", ";

            Valeurs += valeur;
        }

        public void AjouterValeur(params Champ[] champs)
        {
            foreach(Champ c in champs)
                AjouterValeur(c.Nom, c.ValeurSQL);
        }

        public void AjouterValeur(LigneTable ligne)
        {
            AjouterValeur(ligne.Champs.ToArray());
        }
    }

    public class RequeteModification
    {
        private static string ChaineModification = "UPDATE {0} SET {1} WHERE {2};";

        public string NomTable { get; private set; }
        private string ChampsModif;

        private ConditionRequete condition;
        public ConditionRequete Condition
        {
            get { return condition; }
            set
            {
                if (value == null)
                {
                    Journal.EcrireMessage("Tentative de mettre la condition d'une requête modification à null (Table : " + NomTable + ").");
                    return;
                }

                condition = value;
            }
        }

        public string Texte
        {
            get
            {
                return String.Format(ChaineModification, NomTable, ChampsModif, Condition.Texte);
            }
            private set { }
        }

        public RequeteModification(NomTable nomTable, ConditionRequete condition, string premierNomChamp, string premiereValeur)
        {
            NomTable = System.Enum.GetName(typeof(NomTable), nomTable);
            ChampsModif = "";
            Condition = condition;

            AjouterChampModif(premierNomChamp, premiereValeur);
        }

        public RequeteModification(NomTable nomTable, ConditionRequete condition, params Champ[] champs)
        {
            NomTable = System.Enum.GetName(typeof(NomTable), nomTable);
            ChampsModif = "";
            Condition = condition;

            AjouterChampModif(champs);
        }

        public RequeteModification(NomTable nomTable, ConditionRequete condition, LigneTable ligne)
        {
            NomTable = System.Enum.GetName(typeof(NomTable), nomTable);
            ChampsModif = "";
            Condition = condition;

            AjouterChampModif(ligne);
        }

        public RequeteModification(RequeteModification req)
        {
            NomTable = req.NomTable;
            ChampsModif = req.ChampsModif;
            Condition = req.Condition;
        }

        public void AjouterChampModif(string nomChamp, string valeur)
        {
            if ((nomChamp == null || valeur == null) || (nomChamp == "" || valeur == ""))
            {
                Journal.EcrireMessage("Erreur lors de l'ajout d'une valeur dans une requête modification.");
                return;
            }

            if (ChampsModif != "")
                ChampsModif += ", ";

            ChampsModif += nomChamp + "=" + valeur;
        }

        public void AjouterChampModif(params Champ[] champs)
        {
            foreach(Champ c in champs)
                AjouterChampModif(c.Nom, c.ValeurSQL);
        }

        public void AjouterChampModif(LigneTable ligne)
        {
            AjouterChampModif(ligne.Champs.ToArray());
        }
    }

    public class RequeteSuppression
    {
        private static string ChaineSuppression = "DELETE FROM {0} WHERE {1};";

        public string NomTable { get; private set; }

        private ConditionRequete condition;
        public ConditionRequete Condition
        {
            get { return condition; }
            set
            {
                if (value == null)
                {
                    Journal.EcrireMessage("Tentative de mettre la condition d'une requête suppression à null (Table : " + NomTable + ").");
                    return;
                }

                condition = value;
            }
        }

        public string Texte
        {
            get
            {
                return String.Format(ChaineSuppression, NomTable, Condition.Texte);
            }
            private set { }
        }

        public RequeteSuppression(NomTable nomTable, ConditionRequete condition)
        {
            NomTable = System.Enum.GetName(typeof(NomTable), nomTable);
            Condition = condition;
        }
    }
}
