using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class DraftManager
{
    HarvestFactory harvestFactory;
    ProviderFactory providerFactory;
    // data store
    string mode;
    double totalEnergyStored;
    double totalMinedOre;

    List<Harvester> harversters;
    List<Provider> providers;

    public DraftManager()
    {
        this.harversters = new List<Harvester>();
        this.providers = new List<Provider>();
        harvestFactory = new HarvestFactory();
        providerFactory = new ProviderFactory();
        this.mode = "Full";
    }

    public string RegisterHarvester(List<string> arguments)
    {
        //variables
        var harversterType = arguments[0];

        string msg = string.Empty;
        try
        {

            Harvester harvester = harvestFactory.CreateHarvest(arguments);
            this.harversters.Add(harvester);
            msg = $"Successfully registered {harversterType} Harvester - {harvester.Id}";

        }
        catch (ArgumentException e)
        {
            msg = e.Message;
        }
        return msg;
    }


    public string RegisterProvider(List<string> arguments)
    {
        var providerType = arguments[0];
        string msg = string.Empty;
        try
        {

            Provider provider = providerFactory.CreateProvider(arguments);
            this.providers.Add(provider);

            msg = $"Successfully registered {providerType} Provider - {provider.Id}";
        }
        catch (ArgumentException ex)
        {
            msg = ex.Message;
        }

        return msg;
    }


    public string Day()
    {
        double dailyEnergy = 0;
        double dailyOre = 0;
        double isEnergyEnough = 0;

        dailyEnergy = providers.Sum(v => v.EnergyOutput);

        totalEnergyStored += dailyEnergy; // total energy

        isEnergyEnough += harversters.Sum(v => v.EnergyRequirement);
        if (totalEnergyStored >= isEnergyEnough)
        {
            switch (mode)
            {
                case "Full":
                    dailyOre += harversters.Sum(v => v.OreOutput);
                    totalEnergyStored -= isEnergyEnough;
                    break;
                case "Half":
                    dailyOre += harversters.Sum(v => (v.OreOutput * 50)) / 100;
                    totalEnergyStored -= (isEnergyEnough * 60) / 100;
                    break;
            }
        }

        totalMinedOre += dailyOre;


        StringBuilder sb = new StringBuilder();
        sb.AppendLine("A day has passed.");
        sb.AppendLine($"Energy Provided: {dailyEnergy}");
        sb.AppendLine($"Plumbus Ore Mined: {dailyOre}");

        return sb.ToString().Trim();
    }

    public string Mode(List<string> arguments)
    {
        string TypeMode = arguments[0];
        return $"Successfully changed working mode to {TypeMode} Mode";
    }

    public string Check(List<string> arguments)
    {
        var id = arguments[0];
        Identification unit = (Identification)harversters.FirstOrDefault(h => h.Id == id) ??
            providers.FirstOrDefault(p => p.Id == id);
        if (unit != null)
        {
            return unit.ToString();
        }
        else
        {
            return $"No element found with id - {id}";
        }
    }

    public string ShutDown()
    {
        var sb = new StringBuilder();

        sb.AppendLine("System Shutdown");
        sb.AppendLine($"Total Energy Stored: {totalEnergyStored}");
        sb.AppendLine($"Total Mined Plumbus Ore: {totalMinedOre}");

        return sb.ToString().Trim();
    }
}



