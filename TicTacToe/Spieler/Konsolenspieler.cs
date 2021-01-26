using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToe.Spiel;

namespace TicTacToe.Spieler
{
    public class Konsolenspieler : ISpieler
    {
        public Konsolenspieler()
        {

        }

        public Spielzug BerechneNächstenSpielzug(Spielstellung stellung)
        {
            List<Spielzug> möglicheZüge = stellung.MöglicheZüge();
            string möglicheZügeAlsString = string.Join(", ", möglicheZüge.Select(AlsString));

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine($"Spieler {stellung.SpielerAmZug}, gib deinen Zug ein!: {möglicheZügeAlsString}.");
                string? eingabe = Console.ReadLine();
                Spielzug? spielzug = ErhalteSpielzug(eingabe, stellung.SpielerAmZug);

                if (spielzug != null && möglicheZüge.Contains(spielzug.Value))
                {
                    return spielzug.Value;
                }
                else
                {
                    Console.WriteLine("Ungültiger Spielzug!");
                }
            }
        }

        Spielzug? ErhalteSpielzug(string? eingabe, Symbol symbol)
        {
            if (eingabe == null) return null;
            string[] split = eingabe.Split("/");
            if (split.Length != 2) return null;
            if (!int.TryParse(split[0], out int zeile)) return null;
            if (zeile < 0 || zeile > 2) return null;
            if (!int.TryParse(split[1], out int spalte)) return null;
            if (spalte < 0 || spalte > 2) return null;
            return new Spielzug(symbol, zeile, spalte);
        }

        private string AlsString(Spielzug spielzug)
        {
            return $"{spielzug.Zeile}/{spielzug.Spalte}";
        }
    }
}
