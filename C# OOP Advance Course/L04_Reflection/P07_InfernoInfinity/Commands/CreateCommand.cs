using System;
using System.Collections.Generic;


public class CreateCommand : Command
{
    [Inject]
    private WeaponFactory weaponFactory;
    [Inject]
    private RarityFactory rarityFactory;

    public CreateCommand(Dictionary<string, IWeapon> weapons) : base(weapons)
    {
    }

    public override void Execute(string[] args)
    {
        string[] weaponType = args[0].Split();
        IRarity rarity = rarityFactory.Create(weaponType[0]);
        IWeapon weapon = weaponFactory.Create(weaponType[1], args[1], rarity);
        Weapons.Add(weapon.Name, weapon);
    }
}

