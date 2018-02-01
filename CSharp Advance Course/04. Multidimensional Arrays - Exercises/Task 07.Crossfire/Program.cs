using System;
using System.Linq;

namespace Task_07.Crossfire
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine()
                 .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();
            var cols = dimensions[1];

            int[][] matrix = new int[dimensions[0]][];
            // Fill matrix 
            FillMatrix(matrix, cols);
            string command;
            while((command = Console.ReadLine()) != "Nuke it from orbit")
            {
                var commandsArgs = command
               .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();
                var nukeRow = commandsArgs[0];
                var nukeCol = commandsArgs[1];
                var nukeRadius = commandsArgs[2];

                DestroyCellsInMatrix(matrix, nukeRow, nukeCol, nukeRadius);           
            }
            PrintMatrix(matrix);
        }

        private static void PrintMatrix(int[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                Console.WriteLine(string.Join(" ", matrix[row].Where(c => c != -1)));
            }
        }

        private static void DestroyCellsInMatrix(int[][] matrix, int hitRow, int hitCol, int hitWave)
        {
            for (int row = hitRow - hitWave; row <= hitRow + hitWave; row++)
            {
                if (IsInMatrix(row, hitCol, matrix))
                {
                    matrix[row][hitCol] = -1;
                }
            }

            // Mark destroyed part of the row
            for (int col = hitCol - hitWave; col <= hitCol + hitWave; col++)
            {
                if (IsInMatrix(hitRow, col, matrix))
                {
                    matrix[hitRow][col] = -1;
                }
            }
            //Destroy Cells 
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if(matrix[row][col] < 0)
                    {
                        matrix[row] = matrix[row].Where(n => n > 0).ToArray();
                        break;
                    }
                }
                if(matrix[row].Count() < 1)
                {
                    matrix = matrix.Take(row).Concat(matrix.Skip(row + 1)).ToArray();
                    row--;
                }
            }
        }

        private static bool IsInMatrix(int row, int col, int[][] matrix)
        {
            return row >= 0 && col >= 0 && row < matrix.Length && col < matrix[row].Length;
        }

        private static void FillMatrix(int[][] matrix, int cols)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new int[cols];
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = row * cols + (col + 1);
                }
            }
        }
    }
}
