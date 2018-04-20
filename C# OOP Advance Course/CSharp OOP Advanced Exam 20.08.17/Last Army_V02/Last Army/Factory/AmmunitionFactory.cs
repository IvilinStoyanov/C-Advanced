using System;
using System.Linq;
using System.Reflection;

public class AmmunitionFactory : IAmmunitionFactory
{
    public IAmmunition CreateAmmunition(string ammunitionName)
    {
        Type type = Assembly
            .GetCallingAssembly()
            .GetTypes()
            .FirstOrDefault(s => s.Name == ammunitionName);

        return (IAmmunition)Activator
            .CreateInstance(type, ammunitionName);
    }
}
