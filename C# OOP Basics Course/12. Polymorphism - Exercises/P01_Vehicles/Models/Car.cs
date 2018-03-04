using System;
using System.Collections.Generic;
using System.Text;

namespace P01_Vehicles.Models
{
   
    public class Car : Vehicles
    {
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption , tankCapacity)
        {
            this.FuelConsumptionPerKm += carACExtraConsumption;
        }

         
    }
}
