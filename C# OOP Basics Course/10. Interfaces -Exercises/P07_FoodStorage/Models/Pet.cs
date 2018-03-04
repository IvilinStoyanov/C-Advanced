using System;
using System.Collections.Generic;
using System.Text;

namespace P07_FoodStorage.Models
{
    public class Pet : LivingBeing
    {
        public Pet(string birthDate, string name) : base(birthDate, name)
        {
        }
    }
}