using System;
using System.Linq;

namespace Task_01.SumMatrixElements
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
               .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            var row = int.Parse(input[0]);
            // initializing the array
            int[][] matrix = new int[row][];
            for (int rows = 0; rows < matrix.Length; rows++)
            {
                var elements = Console.ReadLine()
                      .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse)
                   .ToArray();
                matrix[rows] = elements;
            }
            var maxSquareRow = 0;
            var maxSquareCol = 0;
            var maxSum = int.MinValue;

            for (int rows = 0; rows < matrix.Length - 1; rows++)
            {
                for (int col = 0; col < matrix[rows].Length - 1; col++)
                {
                    var currentSum = matrix[rows][col] + matrix[rows + 1][col] +
                                     matrix[rows][col + 1] + matrix[rows + 1][col + 1];

                    if (maxSum < currentSum)
                    {
                        maxSum = currentSum;
                        maxSquareRow = rows;
                        maxSquareCol = col;
                    }
                }
            }
            Console.WriteLine($"{matrix[maxSquareRow][maxSquareCol]} {matrix[maxSquareRow][maxSquareCol + 1]}" +
                $"\n{matrix[maxSquareRow + 1][maxSquareCol]} {matrix[maxSquareRow + 1][maxSquareCol + 1]}");
            Console.WriteLine(maxSum);
        }
    }
}
