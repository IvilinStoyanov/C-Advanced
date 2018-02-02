using System;
using System.Linq;

namespace Task_03.CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> FindTheSmallestNumber = number => number.Min();

            Action<int> PrintNumbers = number => Console.WriteLine(number);

            int[] numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            PrintNumbers(FindTheSmallestNumber(numbers));
        }
    }
}
