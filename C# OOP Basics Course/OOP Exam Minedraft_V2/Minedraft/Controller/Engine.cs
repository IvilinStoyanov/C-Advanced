using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Engine
{
    DraftManager manager = new DraftManager();

    public void Run()
    {
        string command; //run tll Shutdown
        while ((command = Console.ReadLine()) != "Shutdown")
        //Example line : RegisterHarvester[0] Sonic[1] AS-51[2] 100[3] 100[4] 10[5]
        {
            var splitCommand =
                command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var commandType = splitCommand[0];
            switch (commandType)
            {
                case "RegisterHarvester":
                    var harvesterParameters = splitCommand.Skip(1).ToList();
                    Outputter(this.manager.RegisterHarvester(harvesterParameters));
                    break;
                case "RegisterProvider":
                    var providersParameters = splitCommand.Skip(1).ToList();
                    Outputter(this.manager.RegisterProvider(providersParameters));
                    break;
                case "Day":
                    Outputter(this.manager.Day());
                    break;
                case "Mode":
                    Outputter(this.manager.Mode(splitCommand.Skip(1).ToList()));
                    break;
                case "Check":
                    Outputter(this.manager.Check(splitCommand.Skip(1).ToList()));
                    break;
            }
        }
        Outputter(this.manager.ShutDown());
    }
    private void Outputter(string status) => Console.WriteLine(status);
}

