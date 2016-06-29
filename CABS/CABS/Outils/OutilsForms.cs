using System;
using System.Windows.Forms;

namespace CABS.Outils
{
    static public class OutilsForms
    {
        static private string[] Unites = { "zéro", "un", "deux", "trois", "quatre", "cinq", "six", "sept", "huit", "neuf", "dix", "onze", "douze", "treize", "quatorze", "quinze", "seize", "dix-sept", "dix-huit", "dix-neuf" };
        static private string[] Dizaines = { "zéro", "dix", "vingt", "trente", "quarante", "cinquante", "soixante", "soixante-dix", "quatre-vingt", "quatre-vingt-dix" };
        static private string Cent = "cent";
        static private string Mille = "mille";
        static private string Separateur = "-";
        static private string Et = "et";
        static private string Pluriel = "s";

        static public bool VerifierCondition(bool condition, string message)
        {
            if (condition)
            {
                Journal.AfficherMessage(message, TypeMessage.INFORMATION, false);
                return false;
            }

            return true;
        }

        static public bool PoserQuestion(string titre, string question)
        {
            return MessageBox.Show(question, titre, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        static public string ConvertirNombreEnMots(decimal nombre)
        {
            return ConvertirNombreEnMots(Decimal.ToInt32(Math.Floor(nombre)));
        }

        static public string ConvertirNombreEnMots(int nombre)
        {
            if (nombre > 0)
                return ConvertirNombreEnMotsInterne(nombre);

            return Unites[0];
        }

        static private string ConvertirNombreEnMotsInterne(int nombre)
        {
            string mots = "";
            int reste = 0;

            if (nombre > 999)
            {
                int nombreMillier = nombre / 1000;

                reste = nombre % 1000;

                if (nombreMillier > 1)
                {
                    mots = ConvertirNombreEnMotsInterne(nombreMillier);

                    if (mots.EndsWith("vingts") || mots.EndsWith("cents"))
                        mots = mots.TrimEnd('s');

                    mots += Separateur + Mille;
                }
                else
                    mots = Mille;
            }
            else if (nombre > 99)
            {
                int nombreCentaine = nombre / 100;

                reste = nombre % 100;

                if (nombreCentaine > 1)
                {
                    mots = Unites[nombre / 100] + Separateur + Cent;

                    if (reste == 0)
                        mots += Pluriel;
                }
                else
                    mots = Cent;
            }
            else if (nombre > 19)
            {
                int nombreDizaine = nombre / 10;

                reste = nombre % 10;

                if ((nombreDizaine == 7 || nombreDizaine == 9) && reste > 0)
                {
                    nombreDizaine--;
                    reste += 10;
                }

                mots = Dizaines[nombreDizaine];

                if ((reste == 1 || reste == 11) && nombreDizaine <= 7)
                    mots += Separateur + Et;
                else if (nombreDizaine == 8 && reste == 0)
                    mots += Pluriel;
            }
            else
            {
                mots = Unites[nombre];
                reste = 0;
            }

            if (reste > 0)
                return mots + Separateur + ConvertirNombreEnMotsInterne(reste);

            return mots;
        }
    }

    public class ComboBoxItem
    {
        public string Text { get; set; }

        public object Value { get; set; }

        public ComboBoxItem(string text, object value)
        {
            Text = text;
            Value = value;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}