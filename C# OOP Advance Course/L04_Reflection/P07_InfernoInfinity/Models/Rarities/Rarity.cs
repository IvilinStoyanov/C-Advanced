using System;

public abstract class Rarity : IRarity
{
    protected Rarity(int damageMultiplier)
    {
        this.DamageMultiplier = damageMultiplier;
    }

    public int DamageMultiplier { get; }
}

