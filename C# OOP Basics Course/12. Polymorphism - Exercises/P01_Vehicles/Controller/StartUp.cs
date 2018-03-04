using System;
using System.Collections.Generic;
using System.Text;

namespace P01_Vehicles.Controller
{
    using Models;
    using Interfaces;

    public static class StartUp
    {
        public static void Start()
        {
            var carInfo = Console.ReadLine().Split();
            Vehicles car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));

            var truckInfo = Console.ReadLine().Split();
            Vehicles truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));

            var busInfo = Console.ReadLine().Split();
            Vehicles bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));

            var countOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfCommands; i++)
            {
                var commandArgs = Console.ReadLine().Split();
                var command = commandArgs[0];
                var typeOfVehicle = commandArgs[1];
                var givenParam = double.Parse(commandArgs[2]);

                Vehicles vehicleToOperate;
                if (typeOfVehicle == "Car")
                    vehicleToOperate = car;
                else if (typeOfVehicle == "Truck")
                    vehicleToOperate = truck;
                else
                    vehicleToOperate = bus;

                try
                {
                    switch (command)
                    {
                        case "Drive":
                            vehicleToOperate.Drive(givenParam);
                            Console.WriteLine($"{vehicleToOperate.GetType().Name} travelled {givenParam} km");
                            break;
                        case "DriveEmpty":
                            ((Bus)vehicleToOperate).DriveEmpty(givenParam);
                            Console.WriteLine($"{vehicleToOperate.GetType().Name} travelled {givenParam} km");
                            break;
                        case "Refuel":
                            vehicleToOperate.Refuel(givenParam);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
    }
}


