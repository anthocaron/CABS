using CABS.Outils;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace CABS.BaseDonnees
{
    public class LigneTable
    {
        public List<Champ> Champs { get; private set; }

        public string NomTable { get; set; }

        public int NombreChamps
        {
            get { return Champs.Count; }
            private set { }
        }

        public LigneTable(string nomTable)
        {
            Champs = new List<Champ>();
            NomTable = nomTable;
        }

        public LigneTable(string nomTable, MySqlDataReader donnees)
        {
            Champs = new List<Champ>();
            NomTable = nomTable;

            for (int i = 0; i < donnees.FieldCount; ++i)
                AjouterChamp(donnees.GetName(i), donnees.GetValue(i));
        }

        public LigneTable(LigneTable ligne)
        {
            Champs = new List<Champ>(ligne.Champs);
            NomTable = ligne.NomTable;
        }

        public void AjouterChamp(string nomChamp, object valeurChamp)
        {
            AjouterChamp(new Champ(NomTable, nomChamp, valeurChamp), null);
        }

        public void AjouterChamp(string nomChamp, object valeurChamp, string nomChampSuivant)
        {
            AjouterChamp(new Champ(NomTable, nomChamp, valeurChamp), nomChampSuivant);
        }

        public void AjouterChamp(Champ champ)
        {
            AjouterChamp(champ, null);
        }

        public void AjouterChamp(Champ champ, string nomChampSuivant)
        {
            if (champ == null || champ.Nom == null || champ.Nom.Length <= 0)
            {
                Outils.Journal.EcrireMessage("Tentative d'ajout d'un champ null dans la table '" + NomTable + "'.");
                return;
            }

            int indexExistant;

            if ((indexExistant = Champs.FindIndex(c => c.Nom == champ.Nom)) != -1)
            {
                Champs[indexExistant].Valeur = champ.Valeur;
                return;
            }

            if ((indexExistant = Champs.FindIndex(c => c.Nom == nomChampSuivant)) != -1)
            {
                Champs.Insert(indexExistant, champ);
                return;
            }

            Champs.Add(champ);
        }

        public void AjouterChamps(MySqlDataReader donnees)
        {
            for (int i = 0; i < donnees.FieldCount; ++i)
                AjouterChamp(donnees.GetName(i), donnees.GetValue(i));
        }

        public void AjouterChamps(LigneTable ligne)
        {
            foreach(Champ c in ligne.Champs)
                AjouterChamp(c);
        }

        public Champ GetChamp(string nomChamp)
        {
            int indexExistant;

            if ((indexExistant = Champs.FindIndex(c => c.Nom == nomChamp)) < 0)
                return null;

            return Champs[indexExistant];
        }

        public T GetValeurChamp<T>(string nomChamp)
        {
            T valeurParDefault = default(T);
            int index;

            if ((index = Champs.FindIndex(c => c.Nom == nomChamp)) < 0 || Champs[index].Valeur.GetType() == DBNull.Value.GetType())
                return valeurParDefault;
            
            try
            {
                return (T)Global.ConvertirValeur<T>(Champs[index].Valeur);
            }
            catch (InvalidCastException ex)
            {
                Outils.Journal.EcrireException("Erreur de conversion dans la table '" + NomTable + "' pour le champ '" + nomChamp + "'.", ex);
            }

            return valeurParDefault;
        }

        public void RetirerChamp(string nomChamp)
        {
            int indexChamp = Champs.FindIndex(c => c.Nom == nomChamp);

            if (indexChamp >= 0)
                Champs.RemoveAt(indexChamp);
        }
    }
}