using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var listOfPerson = new List<Person>();

        int countOfPerson = int.Parse(Console.ReadLine());

        for (int counter = 0; counter < countOfPerson; counter++)
        {
            var inputSplited = Console.ReadLine().Split();
            var person = new Person(inputSplited[0], inputSplited[1], int.Parse(inputSplited[2]));

            listOfPerson.Add(person);
        }

        var orderedListOfPerson =
            listOfPerson.OrderBy(p => p.FirstName)
            .ThenBy(p => p.Age)
            .ToList();

        foreach (var person in orderedListOfPerson)
        {
            Console.WriteLine(person.ToString());
        }

    }
}

