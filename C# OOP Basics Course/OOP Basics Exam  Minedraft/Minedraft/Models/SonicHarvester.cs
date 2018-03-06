using System;
using System.Collections.Generic;
using System.Text;


public class SonicHarvester : Harvester
{
    private double energyRequirement;
    private int sonicFactor;

    public SonicHarvester(string id, double oreOutput, double energyRequirement, int sonicFactor)
        : base(id, oreOutput, energyRequirement)
    {
        this.energyRequirement = energyRequirement / sonicFactor;
        this.SonicFactor = sonicFactor;
    }

    public int SonicFactor
    {
        get { return sonicFactor; }
        private set
        {
            sonicFactor = value;
        }
    }
}


