using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_04.FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            Predicate<int> isEven = n => n % 2 == 0;

            int[] input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int start = input[0];
            int end = input[1];
            int count = (end - start) + 1;

            List<int> numbers = new List<int>(Enumerable.Range(start, count));

            string oddOrEven = Console.ReadLine();

            if (oddOrEven == "odd")
            {
                Console.WriteLine(string.Join(" ", numbers.Where(n => isEven(n) == false)));
            }
            else
            {
                Console.WriteLine(string.Join(" ", numbers.Where(n => isEven(n) == true)));
            }
        }
    }
}
