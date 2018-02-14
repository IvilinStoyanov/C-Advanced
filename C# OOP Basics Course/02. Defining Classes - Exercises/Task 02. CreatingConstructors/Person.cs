using System;
using System.Collections.Generic;
using System.Text;


class Person
{
    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    private int age;

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    public Person()
    {
        this.Name = "No Name";
        this.Age = 1;
    }

    public Person(int age) : this()
    {
        this.Age = age;
        // TODO : Rest
    }


}

