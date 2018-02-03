using System;
using System.Linq;

namespace Task_08.CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var evenNumber = numbers.Where(x => x % 2 == 0).OrderBy(x => x).ToList();
            var oddNumber = numbers.Where(x => x % 2 != 0).OrderBy(x => x).ToList();

            evenNumber.AddRange(oddNumber);

            Console.WriteLine(string.Join(" ", evenNumber));

        }
    }
}
