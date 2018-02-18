using System;
using System.Collections.Generic;
using System.Text;

public class Tires
{
    public double Pressure { get; set; }
    public int Age { get; set; }

    public Tires(double pressure, int age)
    {
        Pressure = pressure;
        Age = age;
    }
}

