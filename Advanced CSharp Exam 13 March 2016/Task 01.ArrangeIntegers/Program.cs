using System;
using System.Linq;

namespace Task_01.ArrangeIntegers
{
    class Program
    {

        private static readonly string[] IntegerNames =
                                    { "zero", "one", "two",
                                    "three", "four", "five", "six",
                                    "seven", "eight", "nine" };

        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

           var orderedInput = input.OrderBy(str => string.Join(string.Empty, str.Select(ch => IntegerNames[ch - '0'])));

            Console.WriteLine(string.Join(", ", orderedInput));
        }
    }
}

