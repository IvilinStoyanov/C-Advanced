using System;
using System.Collections.Generic;
using System.Text;


public class Car
{
    public const int TANK_MAXIMUM_CAPCITY = 160;
    private double fuelAmount;
    public Tyre Tyre { get; protected set; }

    public int Hp { get; set; }

    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        this.Hp = hp;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;
    }

    public double FuelAmount
    {
        get { return fuelAmount; }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException($"Out of fuel");
            }
            else if(value > TANK_MAXIMUM_CAPCITY)
            {
                value = TANK_MAXIMUM_CAPCITY;
            }
            this.fuelAmount = value;
        }
    }
}

