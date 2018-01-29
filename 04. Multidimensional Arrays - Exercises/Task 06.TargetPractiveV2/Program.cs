using System;
using System.Linq;

namespace Task_06.TargetPractiveV2
{
    class Program
    {
        static void Main(string[] args)
        {
                        //READING INPUT
            int[] sizeOfMatrix = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int matrixRow = sizeOfMatrix[0];
            int matrixCol = sizeOfMatrix[1];
            //init matrix
            char[][] snakeMatrix = new char[matrixRow][];
            string snakeText = Console.ReadLine();

            int[] shotParameters = Console.ReadLine() // impact row, impact column and radius
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int impactRow = shotParameters[0];
            int impactCol = shotParameters[1];
            int raduis = shotParameters[2];
            //END OF READING
            
            snakeMatrix = FillMatrixZigZag(snakeMatrix, matrixCol, snakeText); // Filing matrix

            snakeMatrix = ShotMatrix(snakeMatrix, impactRow, impactCol, raduis); // shotting on matrix

            snakeMatrix = DropCharacter(snakeMatrix);

            PrintMatrix(snakeMatrix);

            

        }

        private static void PrintMatrix(char[][] snakeMatrix)
        {
            for (int row = 0; row < snakeMatrix.Length; row++)
            {
                Console.WriteLine(string.Join(" ", snakeMatrix[row]));
            }
        }

        private static char[][] DropCharacter(char[][] snakeMatrix)
        {
            for (int row = snakeMatrix.Length - 1; row >= 0; row--)
            {
                for (int col = 0; col < snakeMatrix[row].Length; col++)
                {
                    if (snakeMatrix[row][col] != ' ')
                    {
                        continue;
                    }

                    int currentRow = row - 1;
                    while (currentRow >= 0)
                    {
                        if (snakeMatrix[currentRow][col] != ' ')
                        {
                            snakeMatrix[row][col] = snakeMatrix[currentRow][col];
                            snakeMatrix[currentRow][col] = ' ';
                            break;
                        }

                        currentRow--;
                    }
                }              
            }
            return snakeMatrix;
        }

        private static char[][] ShotMatrix(char[][] snakeMatrix, int impactRow, int impactCol, int raduis)
        {
            for (int row = 0; row < snakeMatrix.Length; row++)
            {
                for (int col = 0; col < snakeMatrix[row].Length; col++)
                {
                    if(IsInRaduis(row, col, impactCol, impactRow , raduis))
                    {
                        snakeMatrix[row][col] = ' ';
                    }
                }
            }
          

            return snakeMatrix;
        }

        private static bool IsInRaduis(int row, int col, int impactCol, int impactRow, int raduis)
        {
            var deltaRow = row - impactRow;
            var deltaCol = col - impactCol;

            var impact = deltaRow * deltaRow + deltaCol * deltaCol <= raduis * raduis;

            return impact;

        }

        private static char[][] FillMatrixZigZag(char[][] snakeMatrix, int matrixCol, string snakeText)
        {
            for (int row = 0; row < snakeMatrix.Length; row++)
            {
                snakeMatrix[row] = new char[matrixCol];
            }

            var snakeIndex = 0;
            bool IsGoingLeft = true;

            

            for (int row = snakeMatrix.Length - 1; row >= 0; row--)
            {
                var colUpdate = IsGoingLeft ? -1 : 1;
                var col = IsGoingLeft ? matrixCol - 1 : 0;
                while (0 <= col && col < matrixCol)
                {          
                    if(snakeIndex >= snakeText.Length)
                    {
                        snakeIndex = 0;
                    }
                    snakeMatrix[row][col] = snakeText[snakeIndex];
                    snakeIndex++;
                    col += colUpdate;
                }
                IsGoingLeft = !IsGoingLeft;
               
            }
            return snakeMatrix;
        }
    }
}
