using System;

namespace Task_02.KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> PrintNameWithSirInFront = name => Console.WriteLine("Sir " + name);

            //input 
            var input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var names in input)
            {
                PrintNameWithSirInFront(names);
            }
        }
    }
}
