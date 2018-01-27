using System;
using System.Linq;

namespace Task_03._2x2SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var rowAndColums = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            string[][] jaggedArray = new string[rowAndColums[0]][];
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                jaggedArray[row] = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
               
            }
            int counter = 0;
            for (int row = 0; row < jaggedArray.Length - 1; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length - 1; col++)
                {
                    if (jaggedArray[row][col] == jaggedArray[row][col + 1] 
                        & jaggedArray[row][col] == jaggedArray[row +1][col]
                        & jaggedArray[row][col] == jaggedArray[row + 1][col + 1])
                    {
                        counter++;
                    }
                }
            }
            Console.WriteLine(counter);
        }
    }
}
