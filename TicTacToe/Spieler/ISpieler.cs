using TicTacToe.Spiel;

namespace TicTacToe.Spieler
{
    public interface ISpieler
    {
        Spielzug BerechneNächstenSpielzug(Spielstellung stellung);
    }
}
