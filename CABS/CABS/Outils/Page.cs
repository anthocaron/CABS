using CABS.Formulaires;
using System;
using System.Windows.Forms;

namespace CABS.Outils
{
    public class Page : TabPage
    {
        public Formulaire Contenu { get; private set; }

        public Page(string nomPage, string nomFormulaire)
            : base(nomPage)
        {
            Type typeFormulaire = Type.GetType(nomFormulaire);

            try
            {
                Contenu = (Formulaire)Activator.CreateInstance(typeFormulaire);
            }
            catch (Exception)
            {
                Contenu = new Formulaire(true, true);
            }

            Contenu.Dock = DockStyle.Fill;
            Contenu.TopLevel = false;
            Contenu.Name = nomFormulaire;
            Contenu.AutoScroll = true;

            Controls.Add(Contenu);
            Name = nomFormulaire;

            Contenu.Show();
        }
    }
}