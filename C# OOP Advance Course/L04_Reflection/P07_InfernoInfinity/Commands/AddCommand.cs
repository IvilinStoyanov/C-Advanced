using System;
using System.Collections.Generic;


public class AddCommand : Command
{
    [Inject]
    GemFactory gemFactory;
    [Inject]
    ClarityFactory clarityFactory;
    public AddCommand(Dictionary<string, IWeapon> weapons) : base(weapons)
    {
    }

    public override void Execute(string[] args)
    {
        string weaponName = args[0];
        int socketIndex = int.Parse(args[1]);
        string[] gemType = args[2].Split();
        IClarity clarity = clarityFactory.Create(gemType[0]);
        IGem gem = gemFactory.Create(clarity, gemType[1]);
        Weapons[weaponName].AddGem(socketIndex, gem);
    }
}

