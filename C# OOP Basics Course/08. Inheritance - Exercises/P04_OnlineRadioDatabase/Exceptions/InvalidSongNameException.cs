using System;
using System.Runtime.Serialization;

public class InvalidSongNameException : InvalidSongException
{
    public InvalidSongNameException() : base()
    {
    }

    public InvalidSongNameException(string message) : base(message)
    {
    }

    public InvalidSongNameException(int minNameLength, int maxNameLength)
        : base($"Song name should be between {minNameLength} and {maxNameLength} symbols.")
    {
    }
}
