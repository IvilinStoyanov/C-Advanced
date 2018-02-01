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
              var elements  = Console.ReadLine()
                    .Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();
                matrix[rows] = elements;
            }
            var maxSum = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                maxSum += matrix[i].Sum();
            }
            Console.WriteLine(matrix.Length);
            Console.WriteLine(matrix[0].Length);
            Console.WriteLine(maxSum);
        }
    }
}
