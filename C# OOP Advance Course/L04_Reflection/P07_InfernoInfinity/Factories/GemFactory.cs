using System;

public class GemFactory
{
    public IGem Create(IClarity clarity, string typeName)
    {
        Type type = FactoriesUtility.GetType(typeName+"Gem");

        if (!typeof(IGem).IsAssignableFrom(type))
        {
            throw new ArgumentException();
        }

        IGem gem = (IGem)Activator.CreateInstance(type, new object[]{clarity});
        return gem;
    }
}

