using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CABS.Outils
{
    public class Menu
    {
        public List<Section> Sections { get; private set; }

        public Menu()
        {
            Sections = new List<Section>();
        }

        public void AjouterSection(Section sect)
        {
            if (sect == null || Sections.Exists(s => s.Nom == sect.Nom))
            {
                Journal.EcrireMessage("Erreur lors de l'ajout d'une sous-section.");
                return;
            }

            Sections.Add(sect);
        }

        public List<Page> TrouverPages(string nomSection)
        {
            return TrouverPages(nomSection, Sections);
        }

        private List<Page> TrouverPages(string nomSection, List<Section> sect)
        {
            List<Page> pages = null;

            foreach (Section s in sect)
            {
                if (s.Nom == nomSection)
                    return s.Pages;

                pages = TrouverPages(nomSection, s.Sections);

                if(pages != null)
                    return pages;
            }

            return pages;
        }

        public Section TrouverSection(string nomFormulaire)
        {
            return TrouverSection(nomFormulaire, Sections);
        }

        private Section TrouverSection(string nomFormulaire, List<Section> sect)
        {
            Section section = null;

            foreach (Section s in sect)
            {
                if (s.Pages.Exists(p => p.Name == nomFormulaire))
                    return s;

                section = TrouverSection(nomFormulaire, s.Sections);

                if (section != null)
                    return section;
            }

            return section;
        }
    }
}
