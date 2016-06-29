using System.Windows.Forms;
using System.Drawing;
using System;

namespace CABS.Formulaires
{
    public enum ModeFormulaire
    {
        CONSULTATION,
        AJOUT,
        EDITION
    };

    public class Formulaire : Form
    {
        public ModeFormulaire Mode;

        public Formulaire()
        {
        }

        public Formulaire(bool cacherBordures, bool fondBlanc)
        {
            if (cacherBordures)
                FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            
            if(fondBlanc)
                BackColor = Color.White;

            Mode = ModeFormulaire.CONSULTATION;
        }

        public bool AfficherDialogue(IWin32Window fenetreParent)
        {
            return ShowDialog(fenetreParent) == System.Windows.Forms.DialogResult.OK;
        }

        virtual public void EnvoyerMessages(params object[] messages) { }
        virtual public void EntrerPage() { }

        virtual public void ChangerAccesControle(ModeFormulaire mode)
        {
            Mode = mode;
        }

        virtual public void Vider() { }

        virtual public bool ValiderDonnees()
        {
            return true;
        }

        virtual public bool Enregistrer()
        {
            return true;
        }

        virtual public bool Supprimer()
        {
            return true;
        }

        virtual public bool QuitterPage()
        {
            return true;
        }
    }
}