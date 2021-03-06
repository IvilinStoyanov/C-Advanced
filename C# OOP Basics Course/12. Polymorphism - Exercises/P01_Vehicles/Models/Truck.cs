﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P01_Vehicles.Models
{

    public class Truck : Vehicles
    {
        public Truck(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
       : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
        {
            this.FuelConsumptionPerKm += truckACExtraConsumption;
        }

        public override void Refuel(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException(FuelAmountError);
            }

            if (this.FuelQuantity + amount * FuelLossRatio > this.TankCapacity)
            {
                throw new ArgumentException(string.Format(ExessFuelErrorMessage, amount));
            }
            this.FuelQuantity += amount * FuelLossRatio;
        }
    }
}

