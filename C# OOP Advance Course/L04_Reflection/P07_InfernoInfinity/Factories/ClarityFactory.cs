using System;

public class ClarityFactory
{

    public IClarity Create(string typeName)
    {
        Type type = FactoriesUtility.GetType(typeName+"Clarity");

        if (!typeof(IClarity).IsAssignableFrom(type))
        {
            throw new ArgumentException();
        }

        IClarity clarity = (IClarity)Activator.CreateInstance(type);
        return clarity;
    }
}

