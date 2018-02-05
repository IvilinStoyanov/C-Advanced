using System;

namespace Task_02.KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int dimension = int.Parse(Console.ReadLine());

            char[][] chessBoard = new char[dimension][];

            for (int row = 0; row < chessBoard.Length; row++)
            {
                var rowInput = Console.ReadLine().ToCharArray();
                chessBoard[row] = new char[dimension];

                chessBoard[row] = rowInput;
            }

            int currentKnightInDanger = 0;
            int maxKnightInDanger = -1;
            int mostDangerousKnightRow = 0;
            int mostDangerousKnightCol = 0;
            int count = 0;

            while(true)
            {
                for (int row = 0; row < chessBoard.Length; row++)
                {
                    for (int col = 0; col < chessBoard[row].Length; col++)
                    {
                        if (chessBoard[row][col].Equals('K'))
                        {
                            //vertical up and left
                            if(IsCellInMatrix(row - 2, col - 1, chessBoard))
                            {
                                if (chessBoard[row - 2][col - 1].Equals('K'))
                                {
                                    currentKnightInDanger++;
                                }
                            }
                            // vertical up and right
                            if(IsCellInMatrix(row - 2, col + 1, chessBoard))
                            {
                                if (chessBoard[row - 2][col + 1].Equals('K'))
                                {
                                    currentKnightInDanger++;
                                }
                            }
                            // vertical down and left
                            if (IsCellInMatrix(row + 2, col - 1, chessBoard))
                            {
                                if (chessBoard[row + 2][col - 1].Equals('K'))
                                {
                                    currentKnightInDanger++;
                                }
                            }
                            // vertical down and right
                            if (IsCellInMatrix(row + 2, col + 1, chessBoard))
                            {
                                if (chessBoard[row + 2][col + 1].Equals('K'))
                                {
                                    currentKnightInDanger++;
                                }
                            }
                            // horizontal up and left
                            if (IsCellInMatrix(row - 1, col - 2, chessBoard))
                            {
                                if (chessBoard[row - 1][col - 2].Equals('K'))
                                {
                                    currentKnightInDanger++;
                                }
                            }
                            // horizontal up and right
                            if (IsCellInMatrix(row - 1, col + 2, chessBoard))
                            {
                                if (chessBoard[row - 1][col + 2].Equals('K'))
                                {
                                    currentKnightInDanger++;
                                }
                            }
                            // horizontal down and left
                            if (IsCellInMatrix(row + 1, col - 2, chessBoard))
                            {
                                if (chessBoard[row + 1][col - 2].Equals('K'))
                                {
                                    currentKnightInDanger++;
                                }
                            }
                            // horizontal down and right
                            if (IsCellInMatrix(row + 1, col + 2, chessBoard))
                            {
                                if (chessBoard[row + 1][col + 2].Equals('K'))
                                {
                                    currentKnightInDanger++;
                                }
                            }
                        }
                        if(currentKnightInDanger > maxKnightInDanger)
                        {
                            maxKnightInDanger = currentKnightInDanger;
                            mostDangerousKnightRow = row;
                            mostDangerousKnightCol = col;
                        }
                        currentKnightInDanger = 0;
                    }
                }
                if(maxKnightInDanger != 0)
                {
                    chessBoard[mostDangerousKnightRow][mostDangerousKnightCol] = 'O';
                    count++;
                    maxKnightInDanger = 0;
                }
                else
                {
                    Console.WriteLine(count);
                    return;
                }
            }


        }

        private static bool IsCellInMatrix(int row, int col, char[][] chessBoard)
        {
            if(0 <= row && row < chessBoard.Length && 0 <= col && col < chessBoard[row].Length)
            {
                return true;
            }
            else
            {
               return false;
            }
        }
    }
}
