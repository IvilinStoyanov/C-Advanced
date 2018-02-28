using System;
using System.Collections.Generic;
using System.Text;

namespace P04_Telephony.Interfaces
{
    public interface ISmartphone : IPhone
    {
        string Browse(string url);
    }
}
