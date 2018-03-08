using System;
using System.Collections.Generic;
using System.Text;


public class EnduranceDriver : Driver
{
    public EnduranceDriver(string name, double totalTime, Car car, double fuelConsumptionPerKm)
        : base(name, totalTime, car, 1.5d)
    {

    }
}

