using System;

public class RarityFactory
{

    public IRarity Create(string typeName)
    {
        var type = FactoriesUtility.GetType(typeName+"Rarity");

        if(!typeof(IRarity).IsAssignableFrom(type)){
            throw new ArgumentException();
        }

        IRarity rarity = (IRarity)Activator.CreateInstance(type);
        return rarity;
    }
}

