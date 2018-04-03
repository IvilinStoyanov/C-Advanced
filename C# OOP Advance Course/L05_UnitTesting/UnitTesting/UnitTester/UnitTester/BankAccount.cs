using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTester
{
    public class BankAccount
    {
        public int Balance { get; private set; }

        public void Deposit(int amount)
        {
            Balance += amount;
        }

        public void Widthdraw(int amount)
        {
            if(Balance < amount)
            {
                throw new Exception("Infusfficent funds");
            }
            Balance -= amount;
        }
    }
}
