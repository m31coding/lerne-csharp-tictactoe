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

            if (spielstand == Spielstand.KreuzIstSieger)
            {
                Console.WriteLine("Kreuz hat gewonnen!");
            }
            else if (spielstand == Spielstand.KreisIstSieger)
            {
                Console.WriteLine("Kreis hat gewonnen!");
            }
            else if (spielstand == Spielstand.Unentschieden)
            {
                Console.WriteLine("Unentschieden!");
            }
            else
            {
                throw new ArgumentException($"Unerwartetes Ergebnis: {spielstand}.");
            }
        }
    }
}
