using System;
using System.Collections.Generic;
using System.Text;


public class Car
{
    public const int tankMaximumCapacity = 160;
    private double fuelAmount;
    private Tyre tyre;

    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        this.Hp = hp;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;
    }

    public int Hp { get; }
  
    public double FuelAmount
    {
        get { return fuelAmount; }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Out of fuel");
            }
            this.fuelAmount = value > tankMaximumCapacity ? tankMaximumCapacity : value;
        }
    }

    public Tyre Tyre
    {
        get { return tyre; }
       private set
        {
            tyre = value;
        }
    }
}

