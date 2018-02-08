using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_03._GreedyTimes_V2
{
    class Program
    {
        static void Main(string[] args)
        {
            long bagCapacity = long.Parse(Console.ReadLine());

            var sequenceOfItemQuantity = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var bagWithDifferentValues = new Dictionary<string, Dictionary<string, long>>();

            long goldTotalValue = 0;
            long gemTotalvalue = 0;
            long cashTotalValue = 0;

            long currentBagCapacity = 0;

            for (int i = 0; i < sequenceOfItemQuantity.Length; i += 2)
            {
                string typeOfValue = sequenceOfItemQuantity[i];
                long value = long.Parse(sequenceOfItemQuantity[i + 1]);

                if (bagCapacity >= currentBagCapacity + value)
                {
                    if (typeOfValue == "Gold")
                    {
                        goldTotalValue += value;

                        if (!bagWithDifferentValues.ContainsKey("Gold"))
                        {
                            bagWithDifferentValues.Add("Gold", new Dictionary<string, long>());
                        }
                        if (!bagWithDifferentValues["Gold"].ContainsKey(typeOfValue))
                        {
                            bagWithDifferentValues["Gold"].Add(typeOfValue, 0);
                        }
                        bagWithDifferentValues["Gold"][typeOfValue] += value;

                        currentBagCapacity += value;
                    }

                    if (typeOfValue.ToLower().EndsWith("gem") && sequenceOfItemQuantity.Length >= 4)
                    {
                        if (goldTotalValue >= (gemTotalvalue + value))
                        {
                            gemTotalvalue += value;

                            if (!bagWithDifferentValues.ContainsKey("Gem"))
                            {
                                bagWithDifferentValues.Add("Gem", new Dictionary<string, long>());
                            }
                            if (!bagWithDifferentValues["Gem"].ContainsKey(typeOfValue))
                            {
                                bagWithDifferentValues["Gem"].Add(typeOfValue, 0);
                            }
                            bagWithDifferentValues["Gem"][typeOfValue] += value;

                            currentBagCapacity += value;
                        }
                    }

                    if (typeOfValue.Length == 3)
                    {
                        if (gemTotalvalue >= (cashTotalValue + value))
                        {
                            cashTotalValue += value;

                            if (!bagWithDifferentValues.ContainsKey("Cash"))
                            {
                                bagWithDifferentValues.Add("Cash", new Dictionary<string, long>());
                            }
                            if (!bagWithDifferentValues["Cash"].ContainsKey(typeOfValue))
                            {
                                bagWithDifferentValues["Cash"].Add(typeOfValue, 0);
                            }
                            bagWithDifferentValues["Cash"][typeOfValue] += value;

                            currentBagCapacity += value;
                        }
                    }
                }
            }

            foreach (var bag in bagWithDifferentValues.OrderByDescending(v => v.Value.Values.Sum()))
            {
                Console.WriteLine($"<{bag.Key}> ${bag.Value.Values.Sum()}");

                foreach (var values in bag.Value.OrderByDescending(n => n.Key).ThenBy(v => v.Value))
                {
                    Console.WriteLine($"##{values.Key} - {values.Value}");
                }
            }
        }
    }
}
