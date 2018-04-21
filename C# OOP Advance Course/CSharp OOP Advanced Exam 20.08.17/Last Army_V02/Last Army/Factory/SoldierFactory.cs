using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class SoldierFactory : ISoldierFactory
{
    public ISoldier CreateSoldier(string soldierTypeName, string name, int age, double experience, double endurance)
    {
        Type type = Assembly
            .GetCallingAssembly()
            .GetTypes()
            .FirstOrDefault(s => s.Name == soldierTypeName);

        return (ISoldier)Activator
            .CreateInstance(type, name, age, experience, endurance);
    }
}

