using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_06.TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int carThatCanBePassed = int.Parse(Console.ReadLine());
            var input = Console.ReadLine();
            var cars = new Queue<string>();
            int count = 0;
            while (input != "end")
            {                    
                if(input == "green")
                {
                    int lenght = Math.Min(carThatCanBePassed, cars.Count);
                    for (int i = 0; i < lenght; i++)
                    {
                        Console.WriteLine($"{cars.Dequeue()} passed!");
                        count++;
                    }
                }
                else
                {
                    cars.Enqueue(input);                 
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"{count} cars passed the crossroads.");
        }
    }
}
