using System;
using System.Collections.Generic;
using System.Text;


public class Citizen : IPerson , IBirthable , IIdentifiable
{
    public Citizen(string name, int age, string id, string birhdate)
    {
        Name = name;
        Age = age;
        Id = id;
        Birthdate = birhdate;
    }

    public string Name { get; set; }
    public int Age { get; set; }

    public string Id { get ; set ; }
    public string Birthdate { get; set; }
}

