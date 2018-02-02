using System;

namespace Task_01.ActionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> printNames = names => Console.WriteLine(names);

            var input = Console.ReadLine().Split(' ');
            foreach (var name in input)
            {
                printNames(name);
            }
        }
    }
}
