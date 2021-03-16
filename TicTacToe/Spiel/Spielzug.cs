namespace TicTacToe.Spiel
{
    public struct Spielzug
    {
        public Spielzug(Symbol symbol, int zeile, int spalte)
        {
            Symbol = symbol;
            Zeile = zeile;
            Spalte = spalte;
        }

        public Symbol Symbol { get; }
        public int Zeile { get; }
        public int Spalte { get; }

        public override string ToString()
        {
            return $"(Symbol={Symbol}, Zeile={Zeile}, Spalte={Spalte})";
        }
    }
}
