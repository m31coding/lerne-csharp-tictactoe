using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToe.Spiel;

namespace TicTacToe.Spieler
{
    public class MinMaxSpieler : ISpieler
    {
        public Spielzug BerechneNächstenSpielzug(Spielstellung stellung)
        {
            BewerteterSpielzug bewerteterSpielzug = ErhalteDenBestenZug(stellung);
            return bewerteterSpielzug.Zug;
        }

        private BewerteterSpielzug ErhalteDenBestenZug(Spielstellung stellung)
        {
            List<Spielzug> züge = stellung.MöglicheZüge();
            List<BewerteterSpielzug> bewerteteZüge =
                züge.Select(z => ErhalteBewertetenSpielzug(z, stellung.Kopie())).ToList();

            if (stellung.SpielerAmZug == Symbol.Kreuz)
            {
                return ErhalteSpielzugMitHöchsterBewertung(bewerteteZüge);
            }
            else // Kreis ist am Zug
            {
                return ErhalteSpielzugMitNiedrigsterBewertung(bewerteteZüge);
            }
        }

        private BewerteterSpielzug ErhalteSpielzugMitHöchsterBewertung(List<BewerteterSpielzug> züge)
        {
            return züge.Aggregate((z1, z2) => z2.Wertung > z1.Wertung ? z2 : z1);
        }

        private BewerteterSpielzug ErhalteSpielzugMitNiedrigsterBewertung(List<BewerteterSpielzug> züge)
        {
            return züge.Aggregate((z1, z2) => z2.Wertung < z1.Wertung ? z2 : z1);
        }

        private BewerteterSpielzug ErhalteBewertetenSpielzug(Spielzug spielzug, Spielstellung stellung)
        {
            return new BewerteterSpielzug(spielzug, BewerteSpielzug(spielzug, stellung));
        }

        private double BewerteSpielzug(Spielzug spielzug, Spielstellung stellung)
        {
            stellung.FühreSpielzugAus(spielzug);
            Spielstand spielstand = new Stellungsanalyse(stellung).ErhalteSpielstand();

            if(spielstand == Spielstand.KreuzIstSieger)
            {
                return 1;
            }
            else if(spielstand == Spielstand.KreisIstSieger)
            {
                return -1;
            }
            else if(spielstand == Spielstand.Unentschieden)
            {
                return 0;
            }
            else
            {
                return ErhalteDenBestenZug(stellung).Wertung;
            }
        }
    }
}
