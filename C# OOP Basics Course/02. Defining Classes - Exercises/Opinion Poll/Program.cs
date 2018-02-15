using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main(string[] args)
    {
        var people = new List<Person>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            var splitInput = Console.ReadLine()
                .Split();

            var name = splitInput[0];
            var age = int.Parse(splitInput[1]);

            var person = new Person(name, age);

            people.Add(person);
        }
        var orderedPeople = people
             .Where(p => p.Age > 30)
             .OrderBy(p => p.Name)
             .ToList();

        foreach (var p in orderedPeople)
        {
            Console.WriteLine($"{p.Name} - {p.Age}");
        }
    }
}

