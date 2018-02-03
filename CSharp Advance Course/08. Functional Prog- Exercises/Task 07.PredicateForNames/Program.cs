using System;
using System.Linq;

namespace Task_07.PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            var nameLenght = int.Parse(Console.ReadLine());
            
            Predicate<string> IsNameCorrect = name => name.Length <= nameLenght;
            var names = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(n => IsNameCorrect(n))
                .ToArray();

            Console.WriteLine(string.Join("\n", names));
        }
    }
}
