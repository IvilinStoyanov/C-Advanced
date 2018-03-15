using System;
using System.Collections.Generic;
using System.Text;


public abstract class Driver
{
    public string Name { get; protected set; }
    public Car Car { get; protected set; }

    protected Driver(string name, Car car)
    {
        this.Name = name;
        this.Car = car;
    }

    public abstract double FuelConsumptionPerKm { get; }

    public abstract double Speed { get; }

}

