using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_04.CubicAssault
{
    class Program
    {
        public static long maxCount = 1000000;

        static void Main(string[] args)
        {
            var regionInfo = new Dictionary<string, Dictionary<string, long>>();

            var input = Console.ReadLine();

            AddingDataToDictionary(regionInfo, input);

            PrintData(regionInfo);

        }

        private static void PrintData(Dictionary<string, Dictionary<string, long>> regionInfo)
        {
            foreach (var region in regionInfo
                     .OrderByDescending(r => r.Value["Black"])
                     .ThenBy(r => r.Key.Length)
                     .ThenBy(r => r.Key))
            {
                var name = region.Key;
                Console.WriteLine($"{name}");

                foreach (var meteorType in region.Value
                        .OrderByDescending(m => m.Value)
                        .ThenBy(m => m.Key))
                {
                    Console.WriteLine($"-> {meteorType.Key} : {meteorType.Value}");
                }
            }
        }

        private static void AddingDataToDictionary(Dictionary<string, Dictionary<string, long>> regionInfo, string input)
        {
            while (input != "Count em all")
            {
                var splitInput = input.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);

                var regionName = splitInput[0];
                var meteorType = splitInput[1];
                var meteorCount = long.Parse(splitInput[2]);

                if (!regionInfo.ContainsKey(regionName))
                {
                    regionInfo.Add(regionName, new Dictionary<string, long>());

                    for (int i = 0; i < 1; i++)
                    {
                        regionInfo[regionName].Add("Black", 0);
                        regionInfo[regionName].Add("Red", 0);
                        regionInfo[regionName].Add("Green", 0);
                    }
                }
                if (!regionInfo[regionName].ContainsKey(meteorType))
                {
                    regionInfo[regionName].Add(meteorType, new long());
                }
                regionInfo[regionName][meteorType] += meteorCount;

                if (regionInfo[regionName]["Green"] >= maxCount)
                {
                    regionInfo[regionName]["Red"] += regionInfo[regionName]["Green"] / maxCount;
                    regionInfo[regionName]["Green"] %= maxCount;
                }
                if (regionInfo[regionName]["Red"] >= maxCount)
                {
                    regionInfo[regionName]["Black"] += regionInfo[regionName]["Red"] / maxCount;
                    regionInfo[regionName]["Red"] %= maxCount;
                }

                input = Console.ReadLine();
            }
        }
    }
}
