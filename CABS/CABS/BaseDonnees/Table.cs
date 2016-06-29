using CABS.Outils;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace CABS.BaseDonnees
{
    public class Table
    {
        public string Nom { get; private set; }

        public int NombreChampsParLigne
        { 
            get
            {
                return NombreLignes > 0 ? Lignes[0].NombreChamps : 0;
            }
            private set { }
        }

        public int NombreLignes { get { return Lignes.Count; } private set { } }

        public bool EstVide
        {
            get { return NombreLignes == 0; }
            private set { }
        }

        public List<LigneTable> Lignes { get; private set; }

        public Table(string nom)
        {
            Nom = nom;
            Lignes = new List<LigneTable>();
        }

        public Table(string nom, MySqlDataReader donnees)
        {
            Nom = nom;
            Lignes = new List<LigneTable>();
            AjouterLignes(donnees);
        }

        public void AjouterLigne(LigneTable ligne)
        {
            if (NombreLignes > 0 && ligne.NombreChamps != NombreChampsParLigne)
            {
                Journal.EcrireMessage("Tentative d'ajouter une ligne avec un nombre de champs invalide à une table");
                return;
            }

            Lignes.Add(ligne);
        }

        public void AjouterLignes(MySqlDataReader donnees)
        {
            if (NombreLignes > 0 && donnees.FieldCount != NombreChampsParLigne)
            {
                Journal.EcrireMessage("Tentative d'ajouter une ligne avec un nombre de champs invalide à une table");
                return;
            }

            while (donnees.Read())
                AjouterLigne(new LigneTable(Nom, donnees));
        }

        public void Joindre(string nomChamp, Table autreTable, string nomAutreChamp)
        {
            List<LigneTable> nouvelleLignes = new List<LigneTable>();

            foreach (LigneTable ligne in Lignes)
            {
                Champ champ = ligne.GetChamp(nomChamp);

                if (champ == null)
                    return;

                LigneTable autreLigne = null;

                foreach (LigneTable l in autreTable.Lignes)
                {
                    Champ c = l.GetChamp(nomAutreChamp);

                    if (c != null && c.Valeur.Equals(champ.Valeur))
                    {
                        autreLigne = l;
                        break;
                    }
                }

                if (autreLigne == null)
                    continue;

                autreLigne.RetirerChamp(nomAutreChamp);
                ligne.AjouterChamps(autreLigne);
                nouvelleLignes.Add(ligne);
            }

            Lignes = nouvelleLignes;
        }

        public void RetirerChamp(string nomChamp)
        {
            foreach (LigneTable l in Lignes)
                l.RetirerChamp(nomChamp);
        }

        public void Vider()
        {
            Lignes.Clear();
        }
    }
}