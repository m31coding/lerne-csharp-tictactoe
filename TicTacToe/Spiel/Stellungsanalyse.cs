namespace TicTacToe.Spiel
{
    public class Stellungsanalyse
    {
        private readonly Spielstellung stellung;

        public Stellungsanalyse(Spielstellung stellung)
        {
            this.stellung = stellung;
        }

        public Spielstand ErhalteSpielstand()
        {
            if(SpielerHatGewonnen(Symbol.Kreuz))
            {
                return Spielstand.KreuzIstSieger;
            }
            else if (SpielerHatGewonnen(Symbol.Kreis))
            {
                return Spielstand.KreisIstSieger;
            }
            else if(AnzahlSymbole() == 9)
            {
                return Spielstand.Unentschieden;
            }
            else
            {
                return Spielstand.Offen;
            }
        }

        private bool SpielerHatGewonnen(Symbol symbol)
        {
            for(int zeile = 0; zeile<3; zeile++)
            {
                if(DreiGleicheInZeile(zeile, symbol))
                {
                    return true;
                }
            }

            for(int spalte = 0; spalte < 3; spalte++)
            {
                if(DreiGleicheInSpalte(spalte, symbol))
                {
                    return true;
                }
            }

            if(DreiGleicheInDiagonaleNachRechtsUnten(symbol))
            {
                return true;
            }

            if(DreiGleicheInDiagonaleNachRechtsOben(symbol))
            {
                return true;
            }

            return false;
        }

        private bool DreiGleicheInZeile(int zeile, Symbol symbol)
        {
            return stellung.ErhalteSymbol(zeile, 0) == symbol &&
                   stellung.ErhalteSymbol(zeile, 1) == symbol &&
                   stellung.ErhalteSymbol(zeile, 2) == symbol;
        }

        private bool DreiGleicheInSpalte(int spalte, Symbol symbol)
        {
            return stellung.ErhalteSymbol(0, spalte) == symbol &&
                   stellung.ErhalteSymbol(1, spalte) == symbol &&
                   stellung.ErhalteSymbol(2, spalte) == symbol;
        }

        private bool DreiGleicheInDiagonaleNachRechtsUnten(Symbol symbol)
        {
            return stellung.ErhalteSymbol(0, 0) == symbol &&
                   stellung.ErhalteSymbol(1, 1) == symbol &&
                   stellung.ErhalteSymbol(2, 2) == symbol;
        }

        private bool DreiGleicheInDiagonaleNachRechtsOben(Symbol symbol)
        {
            return stellung.ErhalteSymbol(2, 0) == symbol &&
                   stellung.ErhalteSymbol(1, 1) == symbol &&
                   stellung.ErhalteSymbol(0, 2) == symbol;
        }

        public int AnzahlSymbole()
        {
            int anzahlSymbole = 0;
            
            for(int zeile = 0; zeile < 3; zeile++)
            {
                for(int spalte = 0; spalte < 3; spalte++)
                {
                    if(stellung.ErhalteSymbol(zeile, spalte) != Symbol.Keins)
                    {
                        anzahlSymbole++;
                    }
                }
            }

            return anzahlSymbole;
        }
    }
}
