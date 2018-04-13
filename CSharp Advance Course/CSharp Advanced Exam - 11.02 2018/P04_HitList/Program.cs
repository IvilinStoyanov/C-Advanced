using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        var dataStore = new Dictionary<string, Dictionary<string, string>>();

        // input
        var targetInfoIndex = int.Parse(Console.ReadLine());

        string command;
        while ((command = Console.ReadLine()) != "end transmissions")
        {
            var splitCommand = command
                .Split('=', StringSplitOptions.RemoveEmptyEntries);

            string name = splitCommand[0];
            if (!dataStore.ContainsKey(name))
            {
                dataStore[name] = new Dictionary<string, string>();
            }

            splitCommand = splitCommand[1]
                .Split(';', StringSplitOptions.RemoveEmptyEntries);

            foreach (var pair in splitCommand)
            {
                var tokens = pair
                    .Split(':', StringSplitOptions.RemoveEmptyEntries);

                dataStore[name][tokens[0]] = tokens[1];
            }
        }

        // kill command at the end
        var killByName = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Last();

        Console.WriteLine($"Info on {killByName}:");

        var man = dataStore[killByName];

        foreach (var key in man.Keys.OrderBy(k => k))
        {
            Console.WriteLine($"---{key}: {man[key]}");
        }

        int infoIndex = dataStore[killByName]
            .Select(k => k.Key.Length + k.Value.Length)
            .Sum();

        Console.WriteLine($"Info index: {infoIndex}");

        if (infoIndex >= targetInfoIndex)
        {
            Console.WriteLine("Proceed");
        }
        else
        {
            Console.WriteLine($"Need {targetInfoIndex - infoIndex} more info.");
        }
    }
}


