using System;
using System.Collections.Generic;
using System.Text;

public class Box
{
    private double lenght;
    private double widht;
    private double height;

    public double Lenght
    {
        get { return lenght; }
        set
        {
            ValidateIfFieldIsNotZero(value);
            this.lenght = value;
        }
    }

    public double Widht
    {
        get { return widht; }
        set
        {
            ValidateIfFieldIsNotZero(value);
            this.widht = value;
        }
    }

    public double Height
    {
        get { return height; }
        set
        {
            ValidateIfFieldIsNotZero(value);
           this.height = value;
        }
    }

    public Box(double lenght, double width, double height)
    {
        this.Lenght = lenght;
        this.Widht = width;
        this.Height = height;
    }
    // Surface Area = 2lw + 2lh + 2wh 
    public double GetSurfaceArea(double lenght, double width, double height)
    {
        return (2 * lenght * width) + (2 * lenght * height) + (2 * width * height);
    }

    //Lateral Surface Area = 2lh + 2wh
    public double GetLateralSurfaceArea(double lenght, double width, double height)
    {
        return (2 * lenght * height) + (2 * width * height);
    }

    //Volume = lwh
    public double GetVolume(double lenght, double width, double height)
    {
        return lenght * width * height;
    }

    //Validation
    private void ValidateIfFieldIsNotZero(double fieldValue)
    {
        if (fieldValue <= 0)
        {
            throw new ArgumentException("Width cannot be zero or negative.");
        }
    }

    public override string ToString()
    {
        var stringBuilder = new StringBuilder()
            .AppendLine($"Surface Area - {GetSurfaceArea(this.Lenght, this.Widht, this.Height):f2}")
            .AppendLine($"Lateral Surface Area - {GetLateralSurfaceArea(this.Lenght, this.Widht, this.Height):f2}")
            .AppendLine($"Volume - {GetVolume(this.Lenght, this.Widht, this.Height):f2}");
        return stringBuilder.ToString();
    }
}

