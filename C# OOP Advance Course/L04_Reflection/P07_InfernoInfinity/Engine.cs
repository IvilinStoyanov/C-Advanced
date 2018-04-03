using System;
using System.Collections.Generic;


public class Engine
{


    Dictionary<string, IWeapon> weapons;
    ClarityFactory clarityFactory;
    GemFactory gemFactory;
    RarityFactory rarityFactory;
    WeaponFactory weaponFactory;
    CommandInterpreter interpreter;
    List<string> printOrder;

    public Engine(Dictionary<string, IWeapon> weapons, ClarityFactory clarityFactory, GemFactory gemFactory, RarityFactory rarityFactory, WeaponFactory weaponFactory, List<string> printOrder)
    {
        this.weapons = weapons;
        this.clarityFactory = clarityFactory;
        this.gemFactory = gemFactory;
        this.rarityFactory = rarityFactory;
        this.weaponFactory = weaponFactory;
        this.printOrder = printOrder;
        this.interpreter = new CommandInterpreter(weapons, clarityFactory, gemFactory, rarityFactory, weaponFactory,ref printOrder);
       
    }

    public void Execute()
    {
        while (true)
        {

            string[] arguments = Console.ReadLine().Split(';');
            if (arguments[0] == "END")
            {
                foreach(var print in printOrder){
                    Console.WriteLine(weapons[print]);
                }
                break;
            }
            interpreter.Run(arguments);

        }
    }
}

