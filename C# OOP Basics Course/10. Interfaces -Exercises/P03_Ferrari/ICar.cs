using System;
using System.Collections.Generic;
using System.Text;


public interface ICar
{
    string Owner { get; set; }

    string Brakes();
    string Gas();
}

