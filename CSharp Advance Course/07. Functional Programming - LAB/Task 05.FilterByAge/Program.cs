using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_05.FilterByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            var people = new Dictionary<string, int>();

            for (int i = 0; i < count; i++)
            {
                var input = Console.ReadLine()
                    .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
               

                string name = input[0];
                int years = int.Parse(input[1]);

                people.Add(name, years);
            }

            string conditional = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            var format = Console.ReadLine();

            var filter = CreateFilter(conditional, age);
            var printer = CreatePrinter(format);
            foreach (var person in people)
            {
                if(filter(person.Value))
                {
                    printer(person);
                }
                
            }
        }
        static Func<int , bool> CreateFilter(string conditional, int age)
        {
            if(conditional == "younger")
            {
                return x => x < age;
            }
            else
            {
                return x => x >= age;
            }
        }

        static  Action<KeyValuePair<string, int>> CreatePrinter(string format)
        {
            switch (format)
            {
                case "name":
                    return x => Console.WriteLine(x.Key);
                    break;
                case "age":
                    return x => Console.WriteLine(x.Value);
                    break;
                case "name age":
                    return x => Console.WriteLine($"{x.Key} - {x.Value}");
                    break;
                default:
                    throw new NotImplementedException();                
            }
        }
    }
}

