using System;
using TicTacToe.Spiel;
using TicTacToe.Spieler;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            ISpieler spieler1 = new Konsolenspieler();
            ISpieler spieler2 = new Konsolenspieler();

            Partie partie = new Partie(spieler1, spieler2);
            Spielstand spielstand = partie.SpielePartie();
            VerkündeErgebnis(spielstand);
        }

        private static void VerkündeErgebnis(Spielstand spielstand)
        {
            Console.WriteLine();
            Symbol sieger = SpielstandKonvertierung.NachSymbol(spielstand);

            if (sieger == Symbol.Kreuz)
            {
                Console.WriteLine("Kreuz hat gewonnen!");
            }
            else if (sieger == Symbol.Kreis)
            {
                Console.WriteLine("Kreis hat gewonnen!");
            }
            else
            {
                Console.WriteLine("Unentschieden!");
            }
        }
    }
}
