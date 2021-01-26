using System;
using TicTacToe.Spiel;
using TicTacToe.Spieler;

namespace TicTacToe
{
    public class Partie
    {
        private readonly ISpieler spieler1;
        private readonly ISpieler spieler2;

        public Partie(ISpieler spieler1, ISpieler spieler2)
        {
            this.spieler1 = spieler1;
            this.spieler2 = spieler2;
        }

        public Spielstand SpielePartie()
        {
            Spielstellung stellung = new Spielstellung();
            Spielstand spielstand = Spielstand.Offen;

            Console.WriteLine(stellung.ToString());

            while (spielstand == Spielstand.Offen)
            {
                Spielzug nächsterZug = ErhalteNächstenSpielzug(new Spielstellung(stellung));
                stellung.FühreSpielzugAus(nächsterZug);
                Stellungsanalyse stellungsanalyse = new Stellungsanalyse(stellung);
                spielstand = stellungsanalyse.ErhalteSpielstand();
                Console.WriteLine();
                Console.WriteLine(stellung.ToString());
            }

            return spielstand;
        }

        private Spielzug ErhalteNächstenSpielzug(Spielstellung stellung)
        {
            if (stellung.SpielerAmZug == Symbol.Kreuz)
            {
                return spieler1.BerechneNächstenSpielzug(stellung);
            }
            else if (stellung.SpielerAmZug == Symbol.Kreis)
            {
                return spieler2.BerechneNächstenSpielzug(stellung);
            }
            else
            {
                throw new ArgumentException("Kein Spieler ist am Zug");
            }
        }
    }
}
