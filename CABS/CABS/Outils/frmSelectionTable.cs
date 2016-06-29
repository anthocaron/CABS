using CABS.BaseDonnees;
using CABS.Formulaires;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CABS.Outils
{
    public partial class frmSelectionTable : Formulaire
    {
        public LigneTable LigneChoisie { get; private set; }

        public frmSelectionTable(string titreFenetre, Table donnees, List<string> champsAffiches, string champCle)
            : base(false, true)
        {
            InitializeComponent();
            Text = titreFenetre;
            gtChoix.Initialiser(donnees, champsAffiches);
            LigneChoisie = null;
        }

        private void frmSelectionTable_Load(object sender, EventArgs e)
        {
            gtChoix.Charger();
            AjusterInterface();
        }

        private void AjusterInterface()
        {
            int largeurDonnees = gtChoix.LargeurColonnes;

            if (largeurDonnees < SystemInformation.MinimumWindowSize.Width)
                largeurDonnees = SystemInformation.MinimumWindowSize.Width;

            int largeurFenetre = largeurDonnees + SystemInformation.VerticalScrollBarWidth + Global.LARGEUR_BORDURE_DGV;
            ClientSize = new Size(largeurFenetre, ClientSize.Height);

            btnOK.Enabled = !gtChoix.EstVide;
            btnOK.Width = btnAnnuler.Width = ClientSize.Width / 2;
            btnOK.Height = btnAnnuler.Height = ClientSize.Height - gtChoix.Height;
            btnOK.Location = new Point(0, gtChoix.Height);
            btnAnnuler.Location = new Point(btnOK.Width, gtChoix.Height);
        }

        private void gtChoix_RowDoubleClick(object sender, RowDoubleClickEventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void frmSelectionTable_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != System.Windows.Forms.DialogResult.OK)
                return;

            LigneChoisie = gtChoix.GetLigneSelectionnee();
        }
    }
}