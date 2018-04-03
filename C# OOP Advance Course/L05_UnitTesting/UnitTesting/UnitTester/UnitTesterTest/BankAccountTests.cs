using NUnit.Framework;
using System;
using UnitTester;

namespace UnitTesterTest
{
    public class BankAccountTests
    {
        [Test]
        public void DepositShouldIncreaseBalance()
        {
            var bankAccount = new BankAccount();
            bankAccount.Deposit(10);
            Assert.That(bankAccount.Balance, Is.EqualTo(bankAccount.Balance));
        }

        [Test]
        public void WithDrawTest()
        {
            var bankAccount = new BankAccount();

            Assert.Throws<Exception>(() => bankAccount.Widthdraw(10));

        }
    }
}
