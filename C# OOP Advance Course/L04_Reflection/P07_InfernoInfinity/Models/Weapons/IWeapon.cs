using System;

public interface IWeapon
{
    
    int MinDamage { get; }

    int MaxDamage { get; }

    string Name { get; }

    int TotalStrength { get; }

    int TotalAgility { get; }

    int TotalVitality { get; }

    void AddGem(int index, IGem gem);

    void RemoveGem(int index);




}

