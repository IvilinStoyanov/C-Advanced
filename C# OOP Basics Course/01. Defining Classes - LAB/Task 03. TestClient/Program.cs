using System;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        var accounts = new Dictionary<int, BankAccount>();

        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            var commandArgs = command.Split();

            var accountId = int.Parse(commandArgs[1]);

            switch (commandArgs[0])
            {
                case "Create":
                    if (accounts.ContainsKey(accountId))
                    {
                        Console.WriteLine("Account already exists");
                    }
                    else
                    {
                        var account = new BankAccount();
                        account.Id = accountId;

                        accounts.Add(accountId, account);
                    }
                    break;
                case "Deposit":
                    if (ValidateAccount(accounts, accountId))
                    {
                        accounts[accountId].Deposit(int.Parse(commandArgs[2]));
                    }
                    break;
                case "Withdraw":
                    if (ValidateAccount(accounts, accountId))
                    {
                        accounts[accountId].Withdraw(int.Parse(commandArgs[2]));
                    }
                    break;
                case "Print":
                    if (ValidateAccount(accounts, accountId))
                    {
                        Console.WriteLine(accounts[accountId]);
                    }
                    break;
            }
        }
    }

    private static bool ValidateAccount(Dictionary<int, BankAccount> accounts, int accountId)
    {
        if (accounts.ContainsKey(accountId))
        {
            return true;
        }
        else
        {
            Console.WriteLine("Account does not exist");
            return false;
        }
    }
}