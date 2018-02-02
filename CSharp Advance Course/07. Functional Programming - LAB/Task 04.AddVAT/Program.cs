using System;
using System.Linq;

namespace Task_04.AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                 .Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                 .Select(double.Parse)
                 .Select(n => n * 1.20)
                 .ToArray();

            foreach (var n in numbers)
            {
                Console.WriteLine($"{n:F2}");
            }
        }
    }
}



