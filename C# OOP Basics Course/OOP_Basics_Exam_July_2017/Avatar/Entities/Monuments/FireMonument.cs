using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class FireMonument : Monument
{
    private int fireAffinity;

    public FireMonument(string name, int fireAffinity)
        : base(name)
    {
        this.fireAffinity = fireAffinity;
    }

    public override int GetAffinity() => this.fireAffinity;

    public override string ToString() =>
        $"{base.ToString()}, Fire Affinity: {this.fireAffinity}";

}