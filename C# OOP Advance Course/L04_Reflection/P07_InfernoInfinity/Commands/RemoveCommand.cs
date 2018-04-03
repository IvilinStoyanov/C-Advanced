using System;
using System.Collections.Generic;


public class RemoveCommand : Command
{
    public RemoveCommand(Dictionary<string, IWeapon> weapons) : base(weapons)
    {
    }

    public override void Execute(string[] args)
    {
        string weaponName = args[0];
        int socketIndex = int.Parse(args[1]);
        Weapons[weaponName].RemoveGem(socketIndex);
    }
}

