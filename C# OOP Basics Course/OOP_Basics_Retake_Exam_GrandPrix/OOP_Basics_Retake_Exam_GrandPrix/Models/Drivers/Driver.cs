using System;
using System.Collections.Generic;
using System.Text;


public abstract class Driver
{
    //back-end fields
    private string name;
    private double totalTime;
    private Car car;
    private double fuelConsumptionPerKm;

    public Driver(string name, double totalTime, Car car, double fuelConsumptionPerKm)
    {
        this.Name = name;
        this.TotalTime = totalTime;
        this.Car = car;
        this.FuelConsumptionPerKm = fuelConsumptionPerKm;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public double TotalTime
    {
        get { return totalTime; }
        set { totalTime = value; }
    }

    public Car Car
    {
        get { return car; }
        set { car = value; }
    }

    public double FuelConsumptionPerKm
    {
        get { return fuelConsumptionPerKm; }
        set { fuelConsumptionPerKm = value; }
    }

    public virtual double Speed => (this.Car.Hp + this.Car.Tyre.Degradation) / this.Car.FuelAmount;
}

