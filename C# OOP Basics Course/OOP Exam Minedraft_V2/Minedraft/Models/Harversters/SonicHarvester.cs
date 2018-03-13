using System;
using System.Collections.Generic;
using System.Text;


public class SonicHarvester : Harvester
{
    private int sonicFactor;

    public SonicHarvester(string id, double oreOutput, double energyRequirement, int sonicFactor)
        : base(id, oreOutput, energyRequirement)
    {
        this.EnergyRequirement = energyRequirement / sonicFactor;
        this.SonicFactor = sonicFactor;
    }

    public int SonicFactor
    {
        get { return sonicFactor; }
        set { sonicFactor = value; }
    }

}

