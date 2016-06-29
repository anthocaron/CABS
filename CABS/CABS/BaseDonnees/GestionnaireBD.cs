using CABS.Outils;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CABS.BaseDonnees
{
    public class GestionnaireBD
    {
        private MySqlConnection Connexion;
        private MySqlCommand Commande;
        private MySqlTransaction Transaction;

        public bool Connecte { get; private set; }
        
        public GestionnaireBD(string chaineConnexion)
        {
            Connexion = new MySqlConnection(chaineConnexion);
            Commande = new MySqlCommand();
            Transaction = null;
        }

        public bool Connecter()
        {
            if (Connecte)
            {
                Journal.EcrireMessage("Tentative de connexion de la base de données alors qu'elle est déjà connectées.");
                return true;
            }

            try
            {
                Connexion.Open();

                Commande = new MySqlCommand();
                Commande.CommandType = System.Data.CommandType.Text;
                Commande.Connection = Connexion;

                Connecte = true;
                return true;
            }
            catch (InvalidOperationException ex)
            {
                Journal.EcrireException("La chaîne de connexion de la base de données est invalide.", ex);
                return false;
            }
            catch (MySqlException ex)
            {
                Journal.EcrireException("Impossible de connecter la base de données.", ex);
                return false;
            }
        }

        public bool Deconnecter()
        {
            if (!Connecte)
            {
                Journal.EcrireMessage("Tentative de déconnexion de la base de données alors qu'elle est déjà déconnectées.");
                return true;
            }

            try
            {
                Connexion.Close();
                Connecte = false;
                return true;
            }
            catch (MySqlException ex)
            {
                Journal.EcrireException("Impossible de déconnecter la base de données.", ex);
                return false;
            }
        }

        public bool CommencerTransaction()
        {
            if (!Connecte)
            {
                Journal.AfficherMessage("La base de données n'est pas connectée. Impossible d'effectuer la transaction.", TypeMessage.ERREUR, false);
                return false;
            }

            if (Transaction != null)
            {
                Journal.EcrireMessage("Tentative d'overture d'une transaction alors qu'une autre est ouverte.");
                return false;
            }

            try
            {
                Transaction = Connexion.BeginTransaction();
            }
            catch (Exception ex)
            {
                Journal.EcrireException("Erreur lors du début d'une transaction.", ex);
                return false;
            }

            return true;
        }

        public bool ConfirmerTransaction()
        {
            if (!Connecte)
            {
                Journal.AfficherMessage("La base de données n'est pas connectée. Impossible d'effectuer la transaction.", TypeMessage.ERREUR, false);
                return false;
            }

            if (Transaction == null)
            {
                Journal.EcrireMessage("Tentative d'un commit alors qu'aucune transaction n'est ouverte.");
                return false;
            }

            try
            {
                Transaction.Commit();
            }
            catch (Exception ex)
            {
                Journal.EcrireException("Erreur lors du commit d'une transaction.", ex);
                return false;
            }

            Transaction = null;
            return true;
        }

        public bool AnnulerTransaction()
        {
            if (!Connecte)
            {
                Journal.AfficherMessage("La base de données n'est pas connectée. Impossible d'effectuer la transaction.", TypeMessage.ERREUR, false);
                return false;
            }

            if (Transaction == null)
            {
                Journal.EcrireMessage("Tentative de rollback alors qu'aucune transaction n'est ouverte.");
                return false;
            }

            try
            {
                Transaction.Rollback();
            }
            catch (Exception ex)
            {
                Journal.EcrireException("Erreur lors du rollback d'une transaction.", ex);
                return false;
            }

            Transaction = null;
            return true;
        }

        public Table EnvoyerRequeteSelectionProcedure(string nomTable, string nomProcedure, Dictionary<string, object> argumentsProcedure)
        {
            Table selection = new Table(nomTable);
            Commande.CommandText = nomProcedure;
            Commande.CommandType = CommandType.StoredProcedure;

            if (argumentsProcedure != null)
            {
                foreach (KeyValuePair<string, object> argument in argumentsProcedure)
                    Commande.Parameters.AddWithValue(argument.Key, argument.Value);
            }

            try
            {
                MySqlDataReader resultat = Commande.ExecuteReader();
                selection.AjouterLignes(resultat);
                resultat.Close();
            }
            catch (MySqlException ex)
            {
                Journal.EcrireException("Erreur lors de l'exécution de la requête de procédure.", ex);
            }
            catch (InvalidOperationException ex)
            {
                Journal.EcrireException("La requête de procédure est invalide ou la connexion est fermée.", ex);
            }

            Commande.Parameters.Clear();
            return selection;
        }

        public Table EnvoyerRequeteSelection(RequeteSelection requete)
        {
            Table selection = new Table(requete.NomTable);

            if (!Connecte)
            {
                Journal.AfficherMessage("La base de données n'est pas connectée. Impossible d'effectuer la requête sélection (Table : " + requete.NomTable + ").", TypeMessage.ERREUR, true);
                return selection;
            }

            Commande.CommandText = requete.Texte;
            Commande.CommandType = CommandType.Text;

            try
            {
                MySqlDataReader resultat = Commande.ExecuteReader();
                selection.AjouterLignes(resultat);
                resultat.Close();
            }
            catch (MySqlException ex)
            {
                Journal.EcrireException("Erreur lors de l'exécution de la requête sélection (Table : " + requete.NomTable + ").", ex);
            }
            catch (InvalidOperationException ex)
            {
                Journal.EcrireException("La requête sélection est invalide ou la connexion est fermée (Table : " + requete.NomTable + ").", ex);
            }

            return selection;
        }

        public Table EnvoyerRequeteSelectionDirect(string nomTable, string requete)
        {
            Table selection = new Table(nomTable);
            Commande.CommandText = requete;
            Commande.CommandType = CommandType.Text;

            try
            {
                MySqlDataReader resultat = Commande.ExecuteReader();
                selection = new Table(nomTable, resultat);
                resultat.Close();
            }
            catch (MySqlException ex)
            {
                Journal.EcrireException("Erreur lors de l'exécution de la requête sélection (Table : " + nomTable + ").", ex);
            }
            catch (InvalidOperationException ex)
            {
                Journal.EcrireException("La requête sélection est invalide ou la connexion est fermée (Table : " + nomTable + ").", ex);
            }

            return selection;
        }

        public int EnvoyerRequeteAjout(RequeteAjout requete)
        {
            int nouvelIndex = -1;

            if (!Connecte)
            {
                Journal.AfficherMessage("La base de données n'est pas connectée. Impossible d'effectuer la requête d'ajout (Table : " + requete.NomTable + ").", TypeMessage.ERREUR, true);
                return nouvelIndex;
            }

            Commande.CommandText = requete.Texte;
            Commande.CommandType = CommandType.Text;

            try
            {
                if (Commande.ExecuteNonQuery() > 0)
                {
                    Commande.CommandText = "SELECT AUTO_INCREMENT FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = DATABASE() AND TABLE_NAME = '" + requete.NomTable + "'";
                    MySqlDataReader resultat = Commande.ExecuteReader();

                    if (resultat.Read())
                    {
                        object valeurIndex = resultat.GetValue(0);

                        if (valeurIndex != DBNull.Value)
                            nouvelIndex = resultat.GetInt32(0) - 1;
                        else
                            nouvelIndex = 0;

                        resultat.Close();
                    }
                }
            }
            catch (MySqlException ex)
            {
                Journal.EcrireException("Erreur lors de l'exécution de la requête d'ajout (Table : " + requete.NomTable + ").", ex);
            }
            catch (InvalidOperationException ex)
            {
                Journal.EcrireException("La requête d'ajout est invalide ou la connexion est fermée (Table : " + requete.NomTable + ").", ex);
            }

            return nouvelIndex;
        }

        public int EnvoyerRequeteModification(RequeteModification requete)
        {
            if (!Connecte)
            {
                Journal.AfficherMessage("La base de données n'est pas connectée. Impossible d'effectuer la requête de modification (Table : " + requete.NomTable + ").", TypeMessage.ERREUR, true);
                return -1;
            }

            Commande.CommandText = requete.Texte;
            Commande.CommandType = CommandType.Text;

            try
            {
                return Commande.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Journal.EcrireException("Erreur lors de l'exécution de la requête de modification (Table : " + requete.NomTable + ").", ex);
            }
            catch (InvalidOperationException ex)
            {
                Journal.EcrireException("La requête de modification est invalide ou la connexion est fermée (Table : " + requete.NomTable + ").", ex);
            }

            return 0;
        }
        
        public int EnvoyerRequeteSuppression(RequeteSuppression requete)
        {
            if (!Connecte)
            {
                Journal.AfficherMessage("La base de données n'est pas connectée. Impossible d'effectuer la requête de suppression (Table : " + requete.NomTable + ").", TypeMessage.ERREUR, true);
                return -1;
            }

            Commande.CommandText = requete.Texte;
            Commande.CommandType = CommandType.Text;

            try
            {
                return Commande.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Journal.EcrireException("Erreur lors de l'exécution de la requête suppression (Table : " + requete.NomTable + ").", ex);
            }
            catch (InvalidOperationException ex)
            {
                Journal.EcrireException("La requête de suppresion est invalide ou la connexion est fermée (Table : " + requete.NomTable + ").", ex);
            }

            return -1;
        }

        public ConnectionState EcouterConnexion(StateChangeEventHandler handler)
        {
            if (Connexion != null)
                Connexion.StateChange += handler;

            return Connexion.State;
        }
    }
}