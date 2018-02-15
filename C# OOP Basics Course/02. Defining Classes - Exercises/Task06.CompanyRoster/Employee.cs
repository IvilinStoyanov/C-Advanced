using System;
using System.Collections.Generic;
using System.Text;


public class Employee
{
    private string name;
    private decimal salary;
    private string position;
    private string department;
    private string email;
    private int age;


    public Employee(string name, decimal salary, string position, string department)
    {
        this.name = name;
        this.salary = salary;
        this.position = position;
        this.department = department;
        this.email = "n/a";
        this.age = -1;
    }

    public Employee(string name, decimal salary, string position, string department, string email, int age)
        : this(name, salary, position, department)
    {
        this.email = email;
        this.age = age;
    }


    public string Name
    {
        get { return name; }
    }

    public decimal Salary
    {
        get { return salary; }
    }

    public string Department
    {
        get { return department; }
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    public string Email
    {
        get { return email; }
        set { email = value; }
    }
}

