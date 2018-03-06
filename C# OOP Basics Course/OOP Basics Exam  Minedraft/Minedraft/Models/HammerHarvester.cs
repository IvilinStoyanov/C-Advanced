using System;
using System.Collections.Generic;
using System.Text;

public class HammerHarvester : Harvester
{

    public HammerHarvester(string id, double oreOutput, double energyRequirement)
        : base(id, oreOutput, energyRequirement)
    {
        oreOutput *= 3;
        energyRequirement *= 2;
    }
}

