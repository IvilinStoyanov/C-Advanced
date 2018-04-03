using System;

public class WeaponFactory
{
    public IWeapon Create(string typeName,string name, IRarity rarity)
    {
        var type = FactoriesUtility.GetType(typeName+"Weapon");
        if (!typeof(IWeapon).IsAssignableFrom(type))
        {
            throw new ArgumentException("This type is not compatible");
        }

        IWeapon weapon = (IWeapon)Activator.CreateInstance(type, new object[] { rarity, name });

        return weapon;
    }
}

