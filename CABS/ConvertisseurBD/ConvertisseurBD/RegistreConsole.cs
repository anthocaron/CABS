using System;

namespace ConvertisseurBD
{
    public static class RegistreConsole
    {
        public static void Ecrire(string message, ConsoleColor couleur)
        {
            Console.ForegroundColor = couleur;
            Console.Out.WriteLine(message);
            Console.ResetColor();
        }
    }
}