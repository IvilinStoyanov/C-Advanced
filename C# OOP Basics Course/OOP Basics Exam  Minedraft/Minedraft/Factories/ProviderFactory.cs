using System;
using System.Collections.Generic;
using System.Text;


public class ProviderFactory
{
    public static Provider CreateProvider(List<string> providerArgs)
    {
        var providerType = providerArgs[0];
        var providerId = providerArgs[1];
        var providerEnergyOutput = double.Parse(providerArgs[2]);

        switch (providerType)
        {
            case "Solar":
                return new SolarProvider(providerId, providerEnergyOutput);
            case "Pressure":
                return new PressureProvider(providerId, providerEnergyOutput);
            default:
                throw new ArgumentException();
        }
    }
}


