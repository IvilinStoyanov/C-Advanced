using System;
using System.Collections.Generic;
using System.Text;


public abstract class Driver
{
    public string Name { get; protected set; }
    public Car Car { get; protected set; }
    private double totalTime;

    protected Driver(string name, Car car)
    {
        this.Name = name;
        this.Car = car;
        this.TotalTime = 0;
    }

    public double TotalTime
    {
        get => this.totalTime;
        set => this.totalTime = value;
    }

    public abstract double FuelConsumptionPerKm { get; }

    public abstract double Speed { get; }



    public virtual void ReduceFuelAmount(int length)
    {
        this.Car.ReduceFuel(length, this.FuelConsumptionPerKm);
    }

}

