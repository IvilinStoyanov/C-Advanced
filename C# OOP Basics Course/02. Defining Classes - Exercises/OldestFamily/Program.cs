using System;


class Program
{
    static void Main(string[] args)
    {
        var family = new Family();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            var splitInput = Console.ReadLine().Split();

            var name = splitInput[0];
            var age = int.Parse(splitInput[1]);

            var person = new Person(name, age);

            family.AddMember(person);
        }
        var olderPerson = family.GetOldestMember();
        if (olderPerson != null)
        {
            Console.WriteLine($"{olderPerson.Name} {olderPerson.Age}");
        }
    }
}


