using System;
using System.Collections.Generic;
using System.Text;


public class UltrasoftTyre : Tyre
{
    private double degradation;
    public double Grip { get; protected set; }

    public UltrasoftTyre(double hardness, double grip) : base(hardness)
    {
        this.Grip = grip;
    }

    public override string Name => "Ultrasoft";

    public override double Degradation
    {
        get => this.degradation;
        protected set
        {
            if (value < 30)
            {
                throw new ArgumentException("Blown Tyre");
            }
            this.degradation = value;
        }
    }

}

