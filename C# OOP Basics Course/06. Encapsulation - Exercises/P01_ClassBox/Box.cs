using System;
using System.Collections.Generic;
using System.Text;

public class Box
{
    public double Lenght { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }

    public Box(double lenght, double width, double height)
    {
        this.Lenght = lenght;
        this.Width = width;
        this.Height = height;
    }
    // Surface Area = 2lw + 2lh + 2wh 
    public static double GetSurfaceArea(double lenght, double width, double height)
    {
        return (2 * lenght * width) + (2 * lenght * height) + (2 * width * height);
    }

    //Lateral Surface Area = 2lh + 2wh
    public static double GetLateralSurfaceArea(double lenght , double width, double height)
    {
        return (2 * lenght * height) + (2 * width * height);
    }

    //Volume = lwh
    public static double GetVolume(double lenght, double width, double height)
    {
        return lenght * width * height;
    }
}

