using enums;
using obj.impl;

namespace tic_tac_toe.helpers
{
    class CheckWinner
    {
        private static Winner winner = Winner.NoneOf;
        public static Winner whoIsWin()
        {
            checkHorizontalLines();
            checkVerticalLines();
            checkDiagonalLines();
            checkFullHolders();
            return winner;
        }
        public static void Reset()
        {
            winner = Winner.NoneOf;
        }
        private static void checkHorizontalLines()
        {
            for (int x = 0; x < Board.ROW; x++)
            {
                if (Board.Holders[x, 0] == Figures.X &&
                    Board.Holders[x, 1] == Figures.X &&
                    Board.Holders[x, 2] == Figures.X)
                    winner = Winner.X;

                if (Board.Holders[x, 0] == Figures.O &&
                    Board.Holders[x, 1] == Figures.O &&
                    Board.Holders[x, 2] == Figures.O)
                    winner = Winner.O;
            }
        }
        private static void checkVerticalLines()
        {
            for (int y = 0; y < Board.COLUMN; y++)
            {
                if (Board.Holders[0, y] == Figures.X &&
                    Board.Holders[1, y] == Figures.X &&
                    Board.Holders[2, y] == Figures.X)
                    winner = Winner.X;

                if (Board.Holders[0, y] == Figures.O &&
                    Board.Holders[1, y] == Figures.O &&
                    Board.Holders[2, y] == Figures.O)
                    winner = Winner.O;
            }
        }
        private static void checkDiagonalLines()
        {
            for (int x = 0; x < Board.ROW; x++)
            {
                switch (x)
                {
                    case 0:
                        if (Board.Holders[x, 0] == Figures.X &&
                            Board.Holders[x + 1, 1] == Figures.X &&
                            Board.Holders[x + 2, 2] == Figures.X)
                            winner = Winner.X;

                        if (Board.Holders[x, 0] == Figures.O &&
                            Board.Holders[x + 1, 1] == Figures.O &&
                            Board.Holders[x + 2, 2] == Figures.O)
                            winner = Winner.O;
                        break;


                    case 2:
                        if (Board.Holders[x, 0] == Figures.X &&
                            Board.Holders[x - 1, 1] == Figures.X &&
                            Board.Holders[x - 2, 2] == Figures.X)
                            winner = Winner.X;

                        if (Board.Holders[x, 0] == Figures.O &&
                            Board.Holders[x - 1, 1] == Figures.O &&
                            Board.Holders[x - 2, 2] == Figures.O)
                            winner = Winner.O;
                        break;
                }
            }
        }
        private static void checkFullHolders()
        {
            int fullHoldersCount = 0;
            for (int x = 0; x < Board.ROW; x++)
                for (int y = 0; y < Board.COLUMN; y++)
                    if (Board.Holders[x, y] != Figures.B)
                        fullHoldersCount++;
            if(fullHoldersCount == Board.ROW*Board.COLUMN && winner == Winner.NoneOf)
                winner = Winner.Draw;
        }
    }
}