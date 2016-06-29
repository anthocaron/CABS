using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CABS.Formulaires.Inscription
{
    public partial class frmInscriptionIndisponible : Formulaire
    {
        public frmInscriptionIndisponible()
            : base(true, false)
        {
            InitializeComponent();
        }

        public override bool Enregistrer()
        {
            return false;
        }
    }
}
