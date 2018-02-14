using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class JediCodeX
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string input = string.Empty;
        List<string> encodedText = new List<string>();
        List<string> jedis = new List<string>();
        List<string> messages = new List<string>();

        for (int i = 0; i < n; i++)
        {
            input = Console.ReadLine();
            encodedText.Add(input);
        }

        string firstPattern = Console.ReadLine();
        string secondPattern = Console.ReadLine();
        int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

        for (int i = 0; i < encodedText.Count; i++)
        {
            Match matchName = Regex.Match(encodedText[i], @"(" + firstPattern + ")([a-zA-Z]{" + firstPattern.Length + "})(?![a-zA-Z])");
            Match matchMessage = Regex.Match(encodedText[i], @"(" + secondPattern + @")([a-zA-Z\d]{" + secondPattern.Length + @"})(?![a-zA-Z\d])");

            while (matchName.Success)
            {
                jedis.Add(matchName.Groups[2].Value);
                matchName = matchName.NextMatch();
            }
            while (matchMessage.Success)
            {
                messages.Add(matchMessage.Groups[2].Value);
                matchMessage = matchMessage.NextMatch();
            }
        }

        int index = 0;
        foreach (var jedi in jedis)
        {
            for (int i = index; i < indexes.Length; i++)
            {
                index++;
                if (messages.Count >= indexes[i])
                {
                    Console.WriteLine($"{jedi} - {messages[indexes[i] - 1]}");
                    break;
                }
            }
        }
    }
}