using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class DraftManager
{
    // data store
    string mode;
    double totalEnergyStored;
    double totalMinedOre;

    Dictionary<string, Harvester> harversters;
    Dictionary<string, Provider> providers;

    public DraftManager()
    {
        this.harversters = new Dictionary<string, Harvester>();
        this.providers = new Dictionary<string, Provider>();
    }

    public string RegisterHarvester(List<string> arguments)
    {
        //variables
        var harversterType = arguments[0];

        string msg = string.Empty;
        try
        {

            Harvester harvester = HarvestFactory.CreateHarvest(arguments);
            this.harversters[harvester.Id] = harvester;
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
        string msg = string.Empty;
        try
        {
            var providerType = arguments[0];
            Provider provider = ProviderFactory.CreateProvider(arguments);
            this.providers[provider.Id] = provider;

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

        dailyEnergy = providers.Sum(v => v.Value.EnergyOutput);

        totalEnergyStored += dailyEnergy; // total energy

        isEnergyEnough += harversters.Sum(v => v.Value.EnergyRequirement);
        if (totalEnergyStored >= isEnergyEnough)
        {
            switch (mode)
            {
                case "Full":
                    dailyOre += harversters.Sum(v => v.Value.OreOutput);
                    totalEnergyStored -= isEnergyEnough;
                    break;
                case "Half":
                    dailyOre += harversters.Sum(v => (v.Value.OreOutput * 50)) / 100;
                    totalEnergyStored -= (isEnergyEnough * 60) / 100;
                    break;
                default:
                    dailyOre += harversters.Sum(v => v.Value.OreOutput);
                    totalEnergyStored -= isEnergyEnough;
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
        if (TypeMode == "Full")
        {
            this.mode = TypeMode;
        }
        else if (TypeMode == "Half")
        {
            this.mode = TypeMode;
        }
        else
        {
            this.mode = TypeMode;
        }
        return $"Successfully changed working mode to {this.mode} Mode";
    }

    public string Check(List<string> arguments)
    {
        var id = arguments[0];
        var sb = new StringBuilder();

        if (providers.ContainsKey(id))
        {
            var type = providers[id].GetType().Name;
            var index = type.IndexOf("Provider");
            type = type.Remove(index);

            sb.AppendLine($"{type} Provider - {id}");
            sb.AppendLine($"Energy Output: {providers[id].EnergyOutput}");
        }
        if (harversters.ContainsKey(id))
        {
            var type = harversters[id].GetType().Name;
            var index = type.IndexOf("Harvester");
            type = type.Remove(index);

            sb.AppendLine($"{type} Harvester - {id}");
            sb.AppendLine($"Ore Output: {harversters[id].OreOutput}");
            sb.AppendLine($"Energy Requirement: {harversters[id].EnergyRequirement}");
        }
        if (sb.Length != 0)
        {
            return sb.ToString().Trim();
        }
        return $"No element found with id - {id}";
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

