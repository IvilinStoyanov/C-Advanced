using System;
using System.Collections.Generic;
using System.Text;

namespace P07_FoodStorage.Interfaces
{
    public interface IBuyer
    {
        int Food { get; }

        void BuyFood();
    }
}