using System;

public abstract class Gem : IGem
{
    private IClarity clarity;

    protected Gem(IClarity clarity, int strength, int agility, int vitality)
    {
        this.clarity = clarity;
        this.Strength = strength + this.clarity.StatIncrease;
        this.Agility = agility + this.clarity.StatIncrease;
        this.Vitality = vitality + this.clarity.StatIncrease;
    }

    public int AdditionalDamageMin { get => ((this.Strength * 2) + Agility); }

    public int AdditionalDamageMax { get => (this.Strength * 3) + (this.Agility * 4); }

    public int Strength { get; }

    public int Agility { get; }

    public int Vitality { get; }
}

