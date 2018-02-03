using System;
using System.Linq;

namespace Task_05.AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            //Print
            Action<int[]> Print = number => Console.WriteLine(string.Join(" ", number));

            var numbers = Console.ReadLine()
                 .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            
            //Method :add plus 1 to each number
            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                switch (command)
                {
                    case "add":
                        AddPlusOneToEachNumber(numbers);
                        break;
                    case "multiply":
                        MultiplyNumbersByTwo(numbers);
                        break;
                    case "subtract":
                        SubtractOneFromEachNumber(numbers);
                        break;
                    case "print":
                        Print(numbers);
                        break;
                }              
            }
        }

        private static void SubtractOneFromEachNumber(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] -= 1;
            }
        }

        private static void MultiplyNumbersByTwo(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] *= 2;
            }
        }

        private static void AddPlusOneToEachNumber(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] += 1;
            }
        }
    }
}
