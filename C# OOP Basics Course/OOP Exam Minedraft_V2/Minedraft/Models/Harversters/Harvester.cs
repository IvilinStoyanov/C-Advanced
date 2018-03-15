using System;
using System.Collections.Generic;
using System.Text;

public abstract class Harvester : Identification
{
    //backend fields
    private double oreOutput;
    private double energyRequirement;

    //const
    protected Harvester(string id, double oreOutput, double energyRequirement)
        : base(id)
    {
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }

    public double OreOutput
    {
        get { return oreOutput; }
        protected set
        {
            if (value < 0) // is negative = true
            {
                throw new ArgumentException
                    ($"Harvester is not registered, because of it's {nameof(OreOutput)}");
            }
            oreOutput = value;
        }
    }

    public double EnergyRequirement
    {
        get { return energyRequirement; }
        protected set
        {
            if (value <= 0 || value > 20000) // is negative = true
            {
                throw new ArgumentException
                    ($"Harvester is not registered, because of it's {nameof(EnergyRequirement)}");
            }
            energyRequirement = value;
        }
    }

    public override string ToString()
    {
        var type = this.GetType().Name;
        var endIndex = type.IndexOf("Harvester");
        type = type.Substring(0, endIndex);


        var builder = new StringBuilder();
        builder
            .AppendLine($"{type} Harvester - {this.Id}")
            .AppendLine($"{type} - {this.Id}")
            .AppendLine($"Ore Output: {this.OreOutput}")
            .AppendLine($"Energy Requirement: {this.EnergyRequirement}");

        return builder.ToString().Trim();
    }
}

