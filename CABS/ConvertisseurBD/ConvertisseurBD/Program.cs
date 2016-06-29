using System;
using CABS.BaseDonnees;

namespace ConvertisseurBD
{
    internal class Program
    {
        private static GestionnaireBD Source = new GestionnaireBD("SERVER=127.0.0.1;DATABASE=source;PORT=3306;UID=client;PASSWORD=client;");
        private static GestionnaireBD Destination = new GestionnaireBD("SERVER=127.0.0.1;DATABASE=destination;PORT=3306;UID=client;PASSWORD=client;");

        private static void Main(string[] args)
        {
            RegistreConsole.Ecrire("ConvertisseurBD\n", ConsoleColor.Blue);

            Source.Connecter();
            Destination.Connecter();

            if (Source.Connecte && Destination.Connecte)
            {
                ExecuterTache();

                Source.Deconnecter();
                Destination.Deconnecter();
            }

            RegistreConsole.Ecrire("Appuyez sur une touche pour terminer...", ConsoleColor.White);
            Console.ReadKey();
        }

        private static void ExecuterTache()
        {
        }
    }
}