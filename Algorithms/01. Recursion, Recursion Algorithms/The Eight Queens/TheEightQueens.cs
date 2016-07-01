namespace The_Eight_Queens
{
    using System;
    using System.Collections.Generic;

    class TheEightQueens
    {
        const int Size = 8;
        private static bool[,] chessboard = new bool[Size, Size];

        private static HashSet<int> attackedRows = new HashSet<int>(); 
        private static HashSet<int> attackedCols = new HashSet<int>(); 
        private static HashSet<int> attackedLeftDiagonals = new HashSet<int>(); 
        private static HashSet<int> attackedRightDiagonals = new HashSet<int>(); 

        private static void Main(string[] args)
        {
            PutQueens(0);
        }

        private static void PutQueens(int row)
        {
            if (row == Size)
            {
                PrintBoard();
            }
            else
            {
                for (int col = 0; col < Size; col++)
                {
                    if (CanPlaceQueen(row, col))
                    {
                        MarkAllAttackedPositions(row, col);
                        PutQueens(row + 1);
                        UnmarkAllAttackedPositions(row, col);
                    }
                }
            }

        }

        private static bool CanPlaceQueen(int row, int col)
        {
            var positionOcuppied =
                attackedRows.Contains(row) ||
                attackedCols.Contains(col) ||
                attackedLeftDiagonals.Contains(col - row) ||
                attackedRightDiagonals.Contains(col + row);
            return !positionOcuppied;
        }

        private static void PrintBoard()
        {
            for (int col = 0; col < Size; col++)
            {
                for (int row = 0; row < Size; row++)
                {
                    if (chessboard[row, col])
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        if ((row + col)%2 == 0)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Gray;
                        }
                    }
                    Console.Write("  ");
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine();
            }
            Console.WriteLine(new string('=', 16));
        }

        private static void MarkAllAttackedPositions(int row, int col)
        {
            attackedRows.Add(row);
            attackedCols.Add(col);
            attackedLeftDiagonals.Add(col - row);
            attackedRightDiagonals.Add(col + row);
            chessboard[row, col] = true;
        }

        private static void UnmarkAllAttackedPositions(int row, int col)
        {
            attackedRows.Remove(row);
            attackedCols.Remove(col);
            attackedLeftDiagonals.Remove(col - row);
            attackedRightDiagonals.Remove(col + row);
            chessboard[row, col] = false;
        }
    }
}

