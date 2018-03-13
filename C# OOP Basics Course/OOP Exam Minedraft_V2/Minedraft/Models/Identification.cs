using System;
using System.Collections.Generic;
using System.Text;


public abstract class Identification
{
    private string id;

    public string Id
    {
        get { return id; }
        set { id = value; }
    }

    protected Identification(string id)
    {
        this.Id = id;
    }
}

