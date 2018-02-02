using System;
using System.Linq;

namespace Task_01.SortEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var unsortedNumber = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var sortNumberFromInput = unsortedNumber
                .Where(u => u % 2 == 0)
                .OrderBy(u => u).ToArray();

            Console.WriteLine(string.Join(", ", sortNumberFromInput));

        }
    }
}
