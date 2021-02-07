using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe.Spiel
{
    public class Spielstellung
    {
        private readonly Symbol[,] spielbrett;

        public Spielstellung()
        {
            spielbrett = new Symbol[3, 3];
            SpielerAmZug = Symbol.Kreuz;
        }

        private Spielstellung(Spielstellung spielstellung)
        {
            spielbrett = new Symbol[3, 3];
            Array.Copy(spielstellung.spielbrett, spielbrett, spielbrett.Length);
            SpielerAmZug = spielstellung.SpielerAmZug;
        }

        public Symbol SpielerAmZug { get; private set; }

        public Spielstellung Kopie()
        {
            return new Spielstellung(this);
        }

        public Symbol ErhalteSymbol(int zeile, int spalte)
        {
            return spielbrett[zeile, spalte];
        }

        public List<Spielzug> MöglicheZüge()
        {
            List<Spielzug> möglicheZüge = new List<Spielzug>();

            for (int zeile = 0; zeile < 3; zeile++)
            {
                for (int spalte = 0; spalte < 3; spalte++)
                {
                    Spielzug spielzug = new Spielzug(SpielerAmZug, zeile, spalte);

                    if (SpielzugIstGültig(spielzug))
                    {
                        möglicheZüge.Add(spielzug);
                    }
                }
            }

            return möglicheZüge;
        }

        private bool SpielzugIstGültig(Spielzug spielzug)
        {
            return spielzug.Symbol == SpielerAmZug &&
                FeldIstFrei(spielzug.Zeile, spielzug.Spalte);
        }

        public void FühreSpielzugAus(Spielzug spielzug)
        {
            if (!SpielzugIstGültig(spielzug))
            {
                throw new ArgumentException($"Der Spielzug {spielzug} ist ungültig!");
            }

            SetzeSymbol(spielzug.Zeile, spielzug.Spalte, spielzug.Symbol);
            WechsleSpielerAmZug();
        }

        private void WechsleSpielerAmZug()
        {
            SpielerAmZug = SpielerAmZug == Symbol.Kreuz ? Symbol.Kreis : Symbol.Kreuz;
        }

        private bool FeldIstFrei(int zeile, int spalte)
        {
            return spielbrett[zeile, spalte] == Symbol.Keins;
        }

        private void SetzeSymbol(int zeile, int spalte, Symbol symbol)
        {
            spielbrett[zeile, spalte] = symbol;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("0   1   2");
            sb.AppendLine($"{AlsZeichen(0, 0)} | {AlsZeichen(0, 1)} | {AlsZeichen(0, 2)} 0");
            sb.AppendLine("---------");
            sb.AppendLine($"{AlsZeichen(1, 0)} | {AlsZeichen(1, 1)} | {AlsZeichen(1, 2)} 1");
            sb.AppendLine("---------");
            sb.AppendLine($"{AlsZeichen(2, 0)} | {AlsZeichen(2, 1)} | {AlsZeichen(2, 2)} 2");
            return sb.ToString();
        }

        private char AlsZeichen(int zeile, int spalte)
        {
            return AlsZeichen(spielbrett[zeile, spalte]);
        }

        private char AlsZeichen(Symbol symbol)
        {
            if (symbol == Symbol.Kreuz)
            {
                return 'X';
            }
            else if (symbol == Symbol.Kreis)
            {
                return 'O';
            }
            else
            {
                return ' ';
            }
        }
    }
}
