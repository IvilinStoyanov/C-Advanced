using System;
using System.Collections.Generic;
using System.Text;

namespace P07_FoodStorage.Models
{
    using Interfaces;

    public abstract class LivingBeing : IBirthable
    {
        public LivingBeing(string birthDate, string name)
        {
            this.BirthDate = birthDate;
            this.Name = name;
        }

        public string BirthDate { get; private set; }

        public string Name { get; private set; }
    }
}