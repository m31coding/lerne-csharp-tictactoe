namespace TicTacToe.Spiel
{
    public static class SpielstandKonvertierung
    {
        public static Symbol NachSymbol(Spielstand spielstand)
        {
            if(spielstand == Spielstand.KreuzIstSieger)
            {
                return Symbol.Kreuz;
            }
            else if(spielstand == Spielstand.KreisIstSieger)
            {
                return Symbol.Kreis;
            }
            else
            {
                return Symbol.Keins;
            }
        }
    }
}
