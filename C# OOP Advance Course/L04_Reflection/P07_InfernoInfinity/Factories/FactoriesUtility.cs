using System;
using System.Linq;
using System.Reflection;


public static class FactoriesUtility
{
    
    public static Type GetType(string typeName)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        Type model = assembly.GetTypes().FirstOrDefault(m => m.Name == typeName);
        if (model == null)
        {
            throw new ArgumentException("Not a valid type");
        }

        return model;
    }
}

