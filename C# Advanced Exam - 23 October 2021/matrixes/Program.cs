using System;

namespace matrixes
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrix = new char[8, 8];
            var counter = 0;

            for (int row = 0; row < 8; row++)
            {
               var numba = Console.ReadLine();

                for (int col = 0; col < 8; col++)
                {
                    matrix[row, col] = numba[col];
                }
            }

            // find white row pawn

            var whiteRow = 0;
            var whiteCol = 0;

            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (matrix[row,col] == 'w')
                    {
                        whiteRow = row;
                        whiteCol = col;
                    }
                }
            }

            // find black row pawn

            var blackRow = 0;
            var blackCol = 0;

            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (matrix[row, col] == 'b')
                    {
                        blackRow = row;
                        blackCol = col;
                    }
                }
            }

            

            while (true)
            {
                if (counter % 2 == 0)
                {
                    if (CheckIfInside(matrix, whiteRow - 1, whiteCol + 1))
                    {
                        if (matrix[whiteRow - 1, whiteCol + 1] == 'b')
                        {
                            Console.WriteLine($"Game over! White capture on {(char)(blackCol + 97)}{8 - blackRow}.");
                            return;
                        }
                    }
                    
                    if (CheckIfInside(matrix, whiteRow - 1, whiteCol - 1))
                    {
                        if (matrix[whiteRow - 1,whiteCol - 1] == 'b')
                        {
                            Console.WriteLine($"Game over! White capture on {(char)(blackCol + 97)}{8 - blackRow}.");
                            return;
                        }
                    }

                    if (whiteRow == 0)
                    {
                        Console.WriteLine($"Game over! White pawn is promoted to a queen at {(char)(whiteCol + 97)}{8 - whiteRow}.");
                        return;
                    }

                    matrix[whiteRow, whiteCol] = '-';
                    whiteRow--;

                    

                    matrix[whiteRow, whiteCol] = 'w';

                }
                else
                {
                    if (CheckIfInside(matrix, blackRow + 1, blackCol - 1))
                    {
                        if (matrix[blackRow + 1, blackCol - 1] == 'w')
                        {
                            Console.WriteLine($"Game over! White capture on {(char)(whiteCol + 97)}{8 - whiteRow}.");
                            return;
                        }
                    }
                    
                    if (CheckIfInside(matrix, blackRow + 1, blackCol + 1))
                    {
                        if (matrix[blackRow + 1, blackCol + 1] == 'w')
                        {
                            Console.WriteLine($"Game over! Black capture on {(char)(whiteCol + 97)}{8 - whiteRow}.");
                            return;
                        }
                    }

                    if (blackRow == 7)
                    {
                        Console.WriteLine($"Game over! Black pawn is promoted to a queen at {(char)(blackCol + 97)}{8 - blackRow}.");
                        return;
                    }

                    matrix[blackRow, blackCol] = '-';
                    blackRow++;

                   

                    matrix[blackRow, blackCol] = 'b';
                }

                counter++;
            }
        }




        public static bool CheckIfInside(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
