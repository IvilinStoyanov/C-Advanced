using System;

public class KnifeWeapon : Weapon
{
    public KnifeWeapon(IRarity rarity,string name) : base(rarity, minDamage:3, maxDamage:4, numberOfSlots:2,name:name)
    {
    }
}

