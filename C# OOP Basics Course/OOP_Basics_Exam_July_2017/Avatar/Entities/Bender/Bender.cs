using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public abstract class Bender
{
    public string Name { get; }
    public int Power { get; }

    protected Bender(string name, int power)
    {
        this.Name = name;
        this.Power = power;
    }

    public abstract double GetPower();

    public override string ToString()
    {
        string benderType = this.GetType().Name;
        int typeEnd = benderType.IndexOf("Bender");
        benderType = benderType.Insert(typeEnd, " ");

        return $"{benderType}: {this.Name}, Power: {this.Power}";
    }
}
