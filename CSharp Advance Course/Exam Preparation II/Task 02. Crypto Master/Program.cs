using System;
using System.Linq;

namespace Task_02._Crypto_Master
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputNumbers = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int maxLenght = 0;
            int currentSteps = 0;

            for (int steps = 1; steps < inputNumbers.Length; steps++)
            {
                for (int startIndex = 0; startIndex < inputNumbers.Length; startIndex++)
                {
                    currentSteps = 1;

                    int currentIndex = startIndex;
                    int nextStep = (currentIndex + steps) % inputNumbers.Length;

                    while (inputNumbers[currentIndex] < inputNumbers[nextStep])
                    {
                        currentSteps++;

                        currentIndex = nextStep;
                        nextStep = (currentIndex + steps) % inputNumbers.Length;
                    }

                    if (currentSteps > maxLenght)
                    {
                        maxLenght = currentSteps;
                    }
                }
            }
            Console.WriteLine(maxLenght);
        }
    }
}
