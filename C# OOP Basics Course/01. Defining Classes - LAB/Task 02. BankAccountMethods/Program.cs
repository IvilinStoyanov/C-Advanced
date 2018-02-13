using System;

namespace Task_02._BankAccountMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            var bankAccount = new BankAccount();
            bankAccount.Id = 1;
            bankAccount.Deposit(15);
            bankAccount.Withdraw(10);
          
            Console.WriteLine(bankAccount);
        }
    }
}
