using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_09.ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            if (n < 0)
            {
                return;
            }

            var numbers = new List<int>(Enumerable.Range(1, n));

            var divisor = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            Predicate<int> IsDivisible = (x) =>
            {
                bool divisible = true;
                foreach (var num in divisor)
                {
                    if (x % num != 0)
                    {
                        divisible = false;
                        break;
                    }
                }
                return divisible;
            };

            numbers = numbers.Where(x => IsDivisible(x)).ToList();

            Console.WriteLine(string.Join(" ", numbers));

        }
    }
}
