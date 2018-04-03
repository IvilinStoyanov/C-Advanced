using System;

public class AxeWeapon : Weapon
{
    public AxeWeapon(IRarity rarity,string name) : base(rarity: rarity, minDamage: 5, maxDamage: 10, numberOfSlots: 4,name:name)
    {
    }
}

