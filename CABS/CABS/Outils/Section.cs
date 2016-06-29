using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CABS.Outils
{
    public class Section : Menu
    {
        public string Nom { get; private set; }
        public List<Page> Pages { get; private set; }

        public Section(string nom)
        {
            Nom = nom;
            Pages = new List<Page>();
        }

        public void AjouterPage(Page page)
        {
            if (page == null || Pages.Exists(p => p.Name == page.Name))
            {
                Journal.EcrireMessage("Erreur lors de l'ajout d'une sous-section.");
                return;
            }

            Pages.Add(page);
        }
    }
}
