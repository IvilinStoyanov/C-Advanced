using System;

namespace Task05.DateModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstDate = Console.ReadLine();
            var secondDate = Console.ReadLine();

            Console.WriteLine($"{DateModifier.CalculateDateDifference(firstDate, secondDate)}");
        }
    }
}
