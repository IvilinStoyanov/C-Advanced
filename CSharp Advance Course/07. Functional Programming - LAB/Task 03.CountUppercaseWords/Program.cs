using System;
using System.Linq;

namespace Task_03.CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> checker = s => char.IsUpper(s[0]);

            var input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(checker)
                .ToList();

            foreach (var i in input)
            {
                Console.WriteLine(i);
            }
        }
    }
}
