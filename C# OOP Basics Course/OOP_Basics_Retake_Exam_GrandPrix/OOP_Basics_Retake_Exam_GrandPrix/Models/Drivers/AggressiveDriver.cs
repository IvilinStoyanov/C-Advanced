using System;
using System.Collections.Generic;
using System.Text;


public class AggressiveDriver : Driver
{
    public AggressiveDriver(string name, double totalTime, Car car, double fuelConsumptionPerKm)
        : base(name, totalTime, car, 2.7d)
    {

    }

    public override double Speed => base.Speed * 1.3;
}

