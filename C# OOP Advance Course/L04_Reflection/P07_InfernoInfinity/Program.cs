using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, IWeapon> weapons = new Dictionary<string, IWeapon>();
        ClarityFactory clarityFactory = new ClarityFactory();
        GemFactory gemFactory = new GemFactory();
        RarityFactory rarityFactory = new RarityFactory();
        WeaponFactory weaponFactory = new WeaponFactory();
        List<string> printOrder = new List<string>();

        Engine engine = new Engine(weapons, clarityFactory, gemFactory, rarityFactory, weaponFactory,printOrder);
        engine.Execute();

    }
}

