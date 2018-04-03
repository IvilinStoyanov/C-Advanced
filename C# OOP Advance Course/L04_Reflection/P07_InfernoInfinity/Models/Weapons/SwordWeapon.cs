using System;

public class SwordWeapon : Weapon
{
    public SwordWeapon(IRarity rarity,string name) : base(rarity, minDamage: 4, maxDamage: 6, numberOfSlots: 3,name:name)
    {
    }
}

