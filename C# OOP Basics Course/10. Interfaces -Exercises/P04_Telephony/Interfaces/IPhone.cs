using System;
using System.Collections.Generic;
using System.Text;

namespace P04_Telephony.Interfaces
{
    public interface IPhone
    {
        string Model { get; }

        string Call(string phoneNumber);
    }
}