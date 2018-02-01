using System;
using System.Linq;

namespace Task_03.GroupNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
          
            // helping array
            var sizes = new int[3];
            foreach (var number in numbers)
            {
                sizes[Math.Abs(number % 3)]++;
            }
            // jagged array 
            int[][] jaggedArray = new int[3][];
            for (int counter = 0; counter < sizes.Length; counter++)
            {
                jaggedArray[counter] = new int[sizes[counter]];
            }
            int[] index = new int[3];
            foreach (var number in numbers)
            {
                var remainder = Math.Abs(number % 3);
                jaggedArray[remainder][index[remainder]] = number;
                index[remainder]++;
            }
            foreach (var array in jaggedArray)
            {
                Console.WriteLine(string.Join(" ", array));
            }

        }
    }
}
