using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Task_01.Regeh
{
    class Program
    {
        static void Main(string[] args)
        {
            // input : [asdSd[asdasd<4REGEH23>asdUsd]
            string pattern = @"\[[^\[\s]+<(\d+)REGEH(\d+)>[^\s]*?\]";
            Regex regex = new Regex(pattern);

            var input = Console.ReadLine();

            MatchCollection matches = regex.Matches(input);
            int index = 0;
            int lenght = input.Length;
            
            StringBuilder sb = new StringBuilder();

            foreach (Match match in matches)
            {
                int digitOne = int.Parse(match.Groups[1].Value);
                int digitTwo = int.Parse(match.Groups[2].Value);

                index += digitOne;
                // Index One
                if(index >= input.Length)
                {
                    sb.Append(input[0]);                  
                }
                else
                {                
                    sb.Append(input[index]);
                }

                index += digitTwo;
                // Index Two
                if (index >= input.Length)
                {                                
                    sb.Append(input[0]);
                }
                else
                {               
                    sb.Append(input[index]);
                }
            }
            Console.WriteLine(sb.ToString());     
        }
    }
}
