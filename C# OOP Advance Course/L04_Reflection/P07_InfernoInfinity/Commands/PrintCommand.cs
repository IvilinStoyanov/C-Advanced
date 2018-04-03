using System;
using System.Collections.Generic;


public class PrintCommand : Command
{
    [Inject]
    private List<string> printOrder;

    public PrintCommand(Dictionary<string, IWeapon> weapons) : base(weapons)
    {
    }

    public override void Execute(string[] args)
    {
        printOrder.Add(args[0]);
    }
}

