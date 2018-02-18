using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_RawData
{  
    class RawData
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                string model;
                Engine engine;
                Cargo cargo;
                Tires[] tires;

                GetAllParameters(out model, out engine, out cargo, out tires);

                cars.Add(new Car(model, engine, cargo, tires));
            }

            string command = Console.ReadLine();
            if (command == "fragile")
            {
                List<string> fragile = cars
                    .Where(x => x.Cargo.Type == "fragile" && x.Tires.Any(y => y.Pressure < 1))
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, fragile));
            }
            else
            {
                List<string> flamable = cars
                    .Where(x => x.Cargo.Type == "flamable" && x.Engine.Power > 250)
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, flamable));
            }
        }

        private static void GetAllParameters(out string model, out Engine engine, out Cargo cargo, out Tires[] tires)
        {
            string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            model = parameters[0];
            engine = GetEngineParameters(parameters);
            cargo = GetCargoParameters(parameters);
            tires = GetTiresParameters(parameters);
        }

        private static Tires[] GetTiresParameters(string[] parameters)
        {
            Tires[] tires;
            double tire1Pressure = double.Parse(parameters[5]);
            int tire1age = int.Parse(parameters[6]);
            double tire2Pressure = double.Parse(parameters[7]);
            int tire2age = int.Parse(parameters[8]);
            double tire3Pressure = double.Parse(parameters[9]);
            int tire3age = int.Parse(parameters[10]);
            double tire4Pressure = double.Parse(parameters[11]);
            int tire4age = int.Parse(parameters[12]);

            tires = new Tires[4];
            tires[0] = new Tires(tire1Pressure, tire1age);
            tires[1] = new Tires(tire2Pressure, tire2age);
            tires[2] = new Tires(tire3Pressure, tire3age);
            tires[3] = new Tires(tire4Pressure, tire4age);
            return tires;
        }

        private static Cargo GetCargoParameters(string[] parameters)
        {
            Cargo cargo;
            int cargoWeight = int.Parse(parameters[3]);
            string cargoType = parameters[4];

            cargo = new Cargo(cargoWeight, cargoType);
            return cargo;
        }

        private static Engine GetEngineParameters(string[] parameters)
        {
            Engine engine;
            int engineSpeed = int.Parse(parameters[1]);
            int enginePower = int.Parse(parameters[2]);
            engine = new Engine(engineSpeed, enginePower);
            return engine;
        }
    }
}
