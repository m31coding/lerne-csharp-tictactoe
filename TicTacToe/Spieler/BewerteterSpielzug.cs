using TicTacToe.Spiel;

namespace TicTacToe.Spieler
{
    public class BewerteterSpielzug
    {
        public BewerteterSpielzug(Spielzug zug, double wertung)
        {
            Zug = zug;
            Wertung = wertung;
        }

        public Spielzug Zug { get; }
        public double Wertung { get; }

        public override string ToString()
        {
            return $"(Zug={Zug}, Wertung={Wertung})";
        }
    }
}
