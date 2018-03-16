using System;
using System.Collections.Generic;
using System.Text;


public class CarFactory
{
    public static Car Create(List<string> args, Tyre tyre)
    {
        var hp = int.Parse(args[0]);
        var fuelAmoutn = double.Parse(args[1]);

        return new Car(hp, fuelAmoutn, tyre);
    }
}



