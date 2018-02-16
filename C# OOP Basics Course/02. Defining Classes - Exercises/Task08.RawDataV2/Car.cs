using System;
using System.Collections.Generic;
using System.Text;

class Car
{
    private string model;
    private Engine engine;
    private Cargo cargo;
    private Tires[] tires;

    public Car(string model , Engine engine , Cargo cargo, Tires[] tires)
    {
        this.model = model;
        this.engine = engine;
        this.cargo = cargo;
        this.tires = tires;
    }

    public string Model
    {
        get { return model; }
    }

    public Engine Engine
    {
        get { return engine; }
    }

    public Cargo Cargo
    {
        get { return cargo; }
    }

    public Tires[] Tires
    {
        get { return tires; }
    }
}

