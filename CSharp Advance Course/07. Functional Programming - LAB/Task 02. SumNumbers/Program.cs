using System;
using System.Linq;

namespace Task_02._SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {           
            var numbers = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var countOfNumbers = numbers.Count();
            var sumOfNumbers = numbers.Sum();

            Console.WriteLine(countOfNumbers);
            Console.WriteLine(sumOfNumbers);           
        }
    }
}
