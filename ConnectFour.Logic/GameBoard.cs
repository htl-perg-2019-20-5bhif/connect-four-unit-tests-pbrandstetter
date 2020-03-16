using System;

namespace ConnectFour.Logic
{
    public class GameBoard
    {
        private readonly byte[,] board = new byte[7, 6];
        internal bool playerOne = true;
        private int numMoves;

        private byte CheckForDiagonalWinLLtUR(byte column, byte row)
        {
            var diff = Math.Min(column, row);
            var startColumn = column - diff;
            var startRow = row - diff;

            var player = board[startColumn, startRow];
            var counter = 1;

            for (var i = 1; startColumn + i < 7 && startRow + i < 6; i++)
            {
                if (board[startColumn + i, startRow + i] != player)
                {
                    player = board[startColumn + i, startRow + i];
                    counter = 1;
                }
                else
                {
                    counter++;
                    if (counter == 4)
                    {
                        return player;
                    }
                }
            }

            return 0;
        }

        private byte CheckForDiagonalWinULtLR(byte column, byte row)
        {
            var diff = Math.Min(column, row);
            var startColumn = column - diff;
            var startRow = row - diff;

            var player = board[startColumn, startRow];
            var counter = 1;

            for (var i = 1; startColumn + i < 7 && startRow - i >= 0; i++)
            {
                if (board[startColumn + i, startRow - i] != player)
                {
                    player = board[startColumn + i, startRow - i];
                    counter = 1;
                }
                else
                {
                    counter++;
                    if (counter == 4)
                    {
                        return player;
                    }
                }
            }

            return 0;
        }

        private byte CheckForHorizontalWin(byte row)
        {
            byte player = 0;
            var counter = 0;
            for (var i = 0; i < 7; i++)
            {
                if (board[i, row] != player)
                {
                    player = board[i, row];
                    counter = 1;
                }
                else
                {
                    counter++;
                    if (counter == 4)
                    {
                        return player;
                    }
                }
            }
            return 0;
        }

        private byte CheckForVerticalWin(byte column, byte row)
        {
            if (row < 3)
            {
                return 0;
            }
            var player = board[column, row];
            for (var i = 1; i < 4; i++)
            {
                if (board[column, row - i] != player)
                {
                    return 0;
                }
            }
            return player;
        }

        private byte CheckForWin(byte column, byte row)
        {
            var crossWin =
                    Math.Max(CheckForVerticalWin(column, row), CheckForHorizontalWin(row));
            var diagonalWin = Math.Max(CheckForDiagonalWinLLtUR(column, row), CheckForDiagonalWinULtLR(column, row));
            return Math.Max(crossWin, diagonalWin);
        }

        public byte SetStone(byte column)
        {
            var gameOver = false;

            if (column > board.GetLength(0))
            {
                throw new ArgumentOutOfRangeException(nameof(column));
            }
            for (byte row = 0; row < 6 && !gameOver; row++)
            {
                if (gameOver)
                {
                    throw new InvalidOperationException("Game is over");
                }
                
                if (column > 6)
                {
                    throw new InvalidOperationException("Column is full");
                }

                if (board[column, row] == 0)
                {
                    board[column, row] = playerOne ? (byte)1 : (byte)2;
                    playerOne = !playerOne;
                    numMoves++;
                    var winner = CheckForWin(column, row);
                    if (winner == 0)
                    {
                        if (numMoves == 42)
                        {
                            gameOver = true;
                                throw new InvalidOperationException("Table is full");
                            
                        }
                        return winner;
                    }
                    gameOver = false;
                    return winner;
                }
            }
        }
    }
}
