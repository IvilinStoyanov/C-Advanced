using System;
using System.Collections.Generic;
using System.Text;

namespace P07_FoodStorage.Models
{
    using Interfaces;

    public abstract class Buyer : LivingBeing, IBuyer
    {
        public Buyer(string birthDate, string name) : base(birthDate, name)
        {
        }

        public int Food { get; protected set; }

        public abstract void BuyFood();
    }
}