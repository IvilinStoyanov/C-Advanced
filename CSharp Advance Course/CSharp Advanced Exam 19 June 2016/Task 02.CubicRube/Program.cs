﻿using System;
using System.Linq;

namespace Task_02.CubicRube
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = int.Parse(Console.ReadLine());
            var allCells = dimensions * dimensions * dimensions;
            var particlesSum = 0L;

            var input = Console.ReadLine();

            while (input != "Analyze")
            {
                var bombardingData = input
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                if (bombardingData[0] >= 0 && bombardingData[0] < dimensions &&
                    bombardingData[1] >= 0 && bombardingData[1] < dimensions &&
                    bombardingData[2] >= 0 && bombardingData[2] < dimensions &&
                    bombardingData[3] != 0)
                {
                    particlesSum += bombardingData[3];
                    allCells--;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(particlesSum);
            Console.WriteLine(allCells);
        }
    }
}
