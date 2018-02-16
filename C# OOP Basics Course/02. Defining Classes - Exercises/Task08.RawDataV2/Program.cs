using System;
using System.Collections.Generic;
using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var carList = new List<Car>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var splitInput = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string model = splitInput[0];

                int engineSpeed = int.Parse(splitInput[1]);
                int enginePower = int.Parse(splitInput[2]);
                int cargoWeight = int.Parse(splitInput[3]);

                string cargoType = splitInput[4];

                double tireOnePressure = double.Parse(splitInput[5]);
                int tireOneAge = int.Parse(splitInput[6]);
                double tireTwoPressure = double.Parse(splitInput[7]);
                int tireTwoAge = int.Parse(splitInput[8]);
                double tireTreePressure = double.Parse(splitInput[9]);
                int tireTreeAge = int.Parse(splitInput[10]);
                double tireFourPressure = double.Parse(splitInput[11]);
                int tireFourAge = int.Parse(splitInput[12]);

                var engine = new Engine(engineSpeed, enginePower);
                var cargo = new Cargo(cargoWeight, cargoType);
                var tires = new Tires[4];
                tires[0] = new Tires(tireOnePressure, tireOneAge);
                tires[1] = new Tires(tireTwoPressure, tireTwoAge);
                tires[2] = new Tires(tireTreePressure, tireTreeAge);
                tires[3] = new Tires(tireFourPressure, tireFourAge);

                var car = new Car(model, engine, cargo, tires);

                carList.Add(car);
            }

            var orderedlistWithCards = new List<Car>();

            string command = Console.ReadLine();
            if(command == "fragile")
            {
                orderedlistWithCards = carList
                    .Where(c => c.Cargo.Type == "fragile" && c.Tires.Any(t => t.Pressure < 1))
                    .ToList();
            }
            if(command == "flamable")
            {
                orderedlistWithCards = carList
                                    .Where(c => c.Cargo.Type == "flamable" && c.Engine.Power > 250)
                                    .ToList();
            }

            foreach (var car in orderedlistWithCards)
            {
                Console.WriteLine(car.Model);
            }
        }
    }

