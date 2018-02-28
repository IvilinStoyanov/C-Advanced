using System;
using System.Collections.Generic;
using System.Text;


public class Ferrari : ICar
{

    public Ferrari(string owner)
    {
        this.Owner = owner;
    }

    public string Owner { get; set; }
    public string Model { get; } = "488-Spider";
   
    string Brakes()
    {
        return "Brakes!";
    }

    string Gas()
    {
        return "Zadu6avam sA!";
    }

    public override string ToString()
    {
        return $"{this.Model}/{this.Brakes()}/{this.Gas()}/{this.Owner}";
    }

    string ICar.Brakes()
    {
        throw new NotImplementedException();
    }

    string ICar.Gas()
    {
        throw new NotImplementedException();
    }
}



