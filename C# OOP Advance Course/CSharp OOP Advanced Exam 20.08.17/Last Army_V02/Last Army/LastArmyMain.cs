using System;
using System.Text;

public class LastArmyMain
{
    public static void Main()
    {
        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();
        GameController gameController = new GameController(writer);

        Engine engine = new Engine(writer, reader, gameController);
        // run program
        engine.Run();
    }
    

}
