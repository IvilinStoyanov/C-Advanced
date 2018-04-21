using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Engine
{
    private IWriter writer;
    private IReader reader;
    private GameController gameController;

    private bool isRunning;

    public Engine(IWriter writer, IReader reader, GameController gameController)
    {
        this.writer = writer;
        this.reader = reader;
        this.gameController = gameController;

        this.isRunning = false;
    }

    public void Run()
    {
        this.isRunning = true;

        while (this.isRunning)
        {
            string input = this.reader.ReadLine();
            if(input == OutputMessages.InputTerminateString)
            {
                this.isRunning = false;
                continue;
            }

            try
            {
                gameController.ProcessCommand(input);
            }
            catch (ArgumentException e)
            {
                this.writer.StoreMessage(e.Message);
            }
        }
        this.gameController.ProduceSummury();
        this.writer.WriteLine(this.writer.StoredMessage.Trim());
    }
}

