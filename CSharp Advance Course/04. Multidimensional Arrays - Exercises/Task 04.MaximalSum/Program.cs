using System;
using System.Linq;

namespace Task_04.MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            // reading input of console 
            int[] sizeOfMatrix = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            //initializing matrix
            int[][] matrix = new int[sizeOfMatrix[0]][];
            for (int row = 0; row < matrix.Length; row++) // filling matrix
            {
                matrix[row] = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }
            int currentSum = 0;
            int maxSum = int.MinValue;
            int[][] matrixR = new int[3][];
            for (int row = 0; row < matrix.Length - 2; row++)
            {
                for (int col = 0; col < matrix[row].Length - 2; col++)
                {
                    currentSum = matrix[row][col] + matrix[row][col + 1] + matrix[row][col + 2]
                                + matrix[row + 1][col] + matrix[row + 1][col + 1] + matrix[row + 1][col + 2] +
                                matrix[row + 2][col] + matrix[row + 2][col + 1] + matrix[row + 2][col + 2];
                    if (maxSum < currentSum)
                    {
                        maxSum = currentSum;
                        matrixR[0] = new int[3];
                        matrixR[1] = new int[3];
                        matrixR[2] = new int[3];

                        matrixR[0] = new int[] { matrix[row][col], matrix[row][col + 1], matrix[row][col + 2] };
                        matrixR[1] = new int[] { matrix[row + 1][col], matrix[row + 1][col + 1], matrix[row + 1][col + 2] };
                        matrixR[2] = new int[] { matrix[row + 2][col], matrix[row + 2][col + 1], matrix[row + 2][col + 2] };
                    };
                }
            }
                Console.WriteLine($"Sum = {maxSum}");
                foreach (var m in matrixR)
                {
                    Console.WriteLine(string.Join(" ", m));
                }           
        }
    }
}

