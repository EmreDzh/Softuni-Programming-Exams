using System;

namespace _02._Matrix
{
    class Program
    {
        static void Main(string[] args)
        {

            var matrix = new char[8][];
            
            for (int i = 0; i < 8; i++)
            {
                var chars = Console.ReadLine().ToCharArray();
                matrix[i] = chars;
            }

            // find white Pawn

            var whiteRow = 0;
            var whiteCol = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 'w')
                    {
                        whiteRow = i;
                        whiteCol = j;
                    }
                }
            }

            // find black Pawn
            var blackRow = 0;
            var blackCol = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 'b')
                    {
                        blackRow = i;
                        blackCol = j;
                    }
                }
            }

            var didWeWin = "";
            var winnerRow = 0;
            var winnerCol = 0;

            var winner = true;

            while (winner == true)
            {
                var forNowWhiteRow = whiteRow;
                var fornowWhiteCol = whiteCol;
                
                
                
                var fornowBlackRow = blackRow;
                var fornowBlackCol = blackCol;
                if (matrix[whiteRow - 1][whiteCol - 1] == 'b')
                {
                    winner = false;
                    didWeWin = "White";
                    winnerRow = whiteRow - 1;
                    winnerCol = whiteCol - 1;
                    matrix[whiteRow - 1][whiteCol - 1] = 'w';
                    matrix[forNowWhiteRow][fornowWhiteCol] = '-';
                    break;
                }
                
                
                if (matrix[whiteRow - 1][whiteCol + 1] == 'b')
                {
                    winner = false;
                    didWeWin = "White";
                    winnerRow = whiteRow - 1;
                    winnerCol = whiteCol + 1;
                    matrix[whiteRow - 1][whiteCol + 1] = 'w';
                    matrix[forNowWhiteRow][fornowWhiteCol] = '-';
                    break;
                }
                if (whiteRow == 0)
                {
                    winner = false;
                    didWeWin = "White";
                    winnerRow = whiteRow;
                    winnerCol = whiteCol;
                    break;
                }



                if (whiteRow - 1 >= 0)
                {
                    whiteRow--;
                    matrix[whiteRow][whiteCol] = 'w';
                    matrix[forNowWhiteRow][fornowWhiteCol] = '-';
                }

                


                if (matrix[blackRow - 1][blackCol - 1] == 'w')
                {
                    winner = false;
                    didWeWin = "Black";
                    winnerRow = blackRow - 1;
                    winnerCol = blackCol - 1;
                    matrix[blackRow - 1][blackCol - 1] = 'b';
                    break;
                }
                
                
                if (matrix[blackRow - 1][blackCol + 1] == 'w')
                {
                    winner = false;
                    didWeWin = "Black";
                    winnerRow = blackRow - 1;
                    winnerCol = blackCol + 1;
                    matrix[blackRow - 1][blackCol + 1] = 'b';
                    matrix[fornowBlackRow][fornowBlackCol] = '-';
                    break;
                }

                if (blackRow == 7)
                {
                    winner = false;
                    didWeWin = "Black";
                    winnerRow = blackRow;
                    winnerCol = blackCol;
                    break;
                }



                if (blackRow + 1 <= 7)
                {
                    blackRow++;
                    matrix[blackRow][blackCol] = 'b';
                    matrix[fornowBlackRow][fornowBlackCol] = '-';
                }

                
            }


            if (winnerCol == 0)
            {
                winnerCol = 'a';
            }

            if (winnerCol == 1)
            {
                winnerCol = 'b';
            }

            if (winnerCol == 7)
            {
                winnerCol = 'h';
            }
            if (winnerCol == 6)
            {
                winnerCol = 'g';
            }
            if (winnerCol == 5)
            {
                winnerCol = 'f';
            }
            if (winnerCol == 4)
            {
                winnerCol = 'e';
            }
            if (winnerCol == 3)
            {
                winnerCol = 'd';
            }
            if (winnerCol == 2)
            {
                winnerCol = 'c';
            }
            
            if (winnerRow == 0)
            {
                winnerRow = 8;
            }
            if (winnerRow == 1)
            {
                winnerRow = 7;
            }
            if (winnerRow == 2)
            {
                winnerRow = 6;
            }
            if (winnerRow == 3)
            {
                winnerRow = 5;
            }
            if (winnerRow == 4)
            {
                winnerRow = 4;

            }
            if (winnerRow == 5)
            {
                winnerRow = 3;
            }
            if (winnerRow == 6)
            {
                winnerRow = 2;
            }
            if (winnerRow == 7)
            {
                winnerRow = 1;
            }




            Console.WriteLine($"Game over! {didWeWin} pawn is promoted to a queen at {(char)winnerCol}{winnerRow}.");
        }
    }
    
    
}
