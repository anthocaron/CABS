using CABS.BaseDonnees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CABS.Outils.Excel
{
    public class Tableau
    {
        public Table Donnees { get; private set; }

        private List<string> titres;
        public List<string> Titres { get { return titres; } private set { } }

        public int HauteurLignes { get; private set; }
        public int GrosseurPolice { get; private set; }

        public int NombreLignes
        {
            get
            {
                int nbLignes = titres.Count;

                if (Donnees != null)
                    nbLignes += Donnees.NombreLignes;

                return nbLignes;
            }
            private set { }
        }

        public Tableau(Table donnees, int hauteurLignes = 0, int grosseurPolice = 11)
        {
            Donnees = donnees;

            titres = new List<string>();
            titres.Add(donnees.Nom);

            HauteurLignes = hauteurLignes;
            GrosseurPolice = grosseurPolice;
        }

        public Tableau(Table donnees, string premierTitre, int hauteurLignes = 0)
        {
            Donnees = donnees;

            titres = new List<string>();
            titres.Add(premierTitre);

            HauteurLignes = hauteurLignes;
        }

        public void AjouterTitre(string titre)
        {
            if (titre == null)
            {
                Journal.EcrireMessage("Tentative d'ajout d'une titre null dans un tableau Excel.");
                return;
            }

            titres.Add(titre);
        }
    }
}
