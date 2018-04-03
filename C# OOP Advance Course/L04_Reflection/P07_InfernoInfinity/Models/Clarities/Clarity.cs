using System;

public abstract class Clarity : IClarity
{
    protected Clarity(int statIncrease)
    {
        this.StatIncrease = statIncrease;
    }

    public int StatIncrease { get; }
}

