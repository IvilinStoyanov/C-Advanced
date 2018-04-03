using System;
using System.Collections.Generic;


public abstract class Command : IExecutable
{

    protected Dictionary<string, IWeapon> Weapons { get; private set; }

    protected Command(Dictionary<string, IWeapon> weapons)
    {
        this.Weapons = weapons;

    }
    public abstract void Execute(string[] args);

}

