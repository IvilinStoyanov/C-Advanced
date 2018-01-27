using System;
using System.Linq;

namespace Task_02.DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeRow = int.Parse(Console.ReadLine());
            int[][] matrixSquare = new int[sizeRow][];

            for (int row = 0; row < matrixSquare.Length; row++)
            {
                matrixSquare[row] = Console.ReadLine()
                        .Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();               
            }
            var primaryDiagonalSum = 0;
            var secondaryDiagonalSum = 0;        
            for (int row = 0, col = sizeRow - 1; row < sizeRow; row++, col--)
            {
                primaryDiagonalSum += matrixSquare[row][row];
                secondaryDiagonalSum += matrixSquare[row][col];
            }
            Console.WriteLine(Math.Abs(primaryDiagonalSum - secondaryDiagonalSum));
        }
    }
}
