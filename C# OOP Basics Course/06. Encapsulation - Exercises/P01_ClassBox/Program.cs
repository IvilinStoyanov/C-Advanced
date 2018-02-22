using System;

class Program
{
    static void Main(string[] args)
    {

        double lenght = double.Parse(Console.ReadLine());
        double widht = double.Parse(Console.ReadLine());
        double height = double.Parse(Console.ReadLine());

        var surfaceAre = Box.GetSurfaceArea(lenght, widht, height);

        var lateralSurfaceArea = Box.GetLateralSurfaceArea(lenght, widht, height);

        var volume = Box.GetVolume(lenght, widht, height);

        Console.WriteLine($"Surface Area - {surfaceAre:F2}");
        Console.WriteLine($"Lateral Surface Area - {lateralSurfaceArea:F2}");
        Console.WriteLine($"Volume - {volume:F2}");


    }
}


