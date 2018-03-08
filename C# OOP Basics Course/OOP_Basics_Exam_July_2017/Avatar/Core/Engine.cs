using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Engine
{
    internal void Run()
    {
        string command = string.Empty;

        while((command = Console.ReadLine()) != "Quit")
        {
            var commandArgs = command.Split(' ');
            ExecuteCommand(commandArgs);
        }
    }

    public void ExecuteCommand(string[] commandArgs)
    {

    }
}

