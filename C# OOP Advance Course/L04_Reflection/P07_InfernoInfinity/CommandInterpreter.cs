using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class CommandInterpreter
{
    private Dictionary<string,IWeapon> weapons;
    private ClarityFactory clarityFactory;
    private GemFactory gemFactory;
    private RarityFactory rarityFactory;
    private WeaponFactory weaponFactory;
    List<string> printOrder;

    public CommandInterpreter(Dictionary<string, IWeapon> weapons, ClarityFactory clarityFactory,GemFactory gemFactory,RarityFactory rarityFactory,WeaponFactory weaponFactory,ref List<string> printOrder)
    {
        this.weapons = weapons;
        this.clarityFactory = clarityFactory;
        this.gemFactory = gemFactory;
        this.rarityFactory = rarityFactory;
        this.weaponFactory = weaponFactory;
        this.printOrder = printOrder;
    }

    public void Run(string[] args){
       
            
            Type type = FactoriesUtility.GetType(args[0]+"Command");

            if (!typeof(IExecutable).IsAssignableFrom(type))
            {
                throw new ArgumentException();
            }

            IExecutable exec = (IExecutable)Activator.CreateInstance(type,new object[]{weapons});
            InjectCustomFields(exec);
            exec.Execute(args.Skip(1).ToArray());
            
    }

    private void InjectCustomFields(IExecutable command){
        Type type = command.GetType();

        FieldInfo[] cmdFields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance).Where(f => f.GetCustomAttribute(typeof(InjectAttribute))!=null).ToArray();

        FieldInfo[] cIFields = this.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance).ToArray();

        for (int i = 0; i < cmdFields.Length;i++){
            cmdFields[i].SetValue(command, cIFields.First(interpreterField => interpreterField.FieldType == cmdFields[i].FieldType).GetValue(this));
        }


    }


}

