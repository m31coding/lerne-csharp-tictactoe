namespace TicTacToe.Spiel
{
    public readonly struct Spielzug
    {
        public Symbol Symbol { get; }
        public int Zeile { get; }
        public int Spalte { get; }

        public Spielzug(Symbol symbol, int zeile, int spalte)
        {
            Symbol = symbol;
            Zeile = zeile;
            Spalte = spalte;
        }

        public override string ToString()
        {
            return $"(Symbol={Symbol}, Zeile={Zeile}, Spalte={Spalte})";
        }
    }
}
