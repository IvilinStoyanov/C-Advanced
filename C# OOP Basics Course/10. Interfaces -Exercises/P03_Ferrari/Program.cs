using System;

class Program
{
    static void Main(string[] args)
    {
        string owner = Console.ReadLine();

        ICar car = new Ferrari(owner);

        Console.WriteLine(car.ToString());

      
         
    }
  
}

