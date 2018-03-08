using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // I/O
        int numberLaps = int.Parse(Console.ReadLine());
        int lenghtTrack = int.Parse(Console.ReadLine());

        string command;
        bool IsCompleted = false;

        while(!IsCompleted)
        {
            var splitCommand = 
                Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            //RegisterDriver[0] Aggressive[1] FirstDriver[2] 650[3] 140[4] Ultrasoft[5] 0.2[6] 3.8[7]
                                                                                      //hardness //grip

            var typeCommand = splitCommand[0];

            switch (typeCommand)
            {
                case "RegisterDriver":
                    //variables
                    var name = splitCommand[2];
                    var fuelAmount = double.Parse(splitCommand[3]);
                    var typeOfTyre = splitCommand[5];
                    if(splitCommand.Count == 8)
                    {
                        UltrasoftTyre ultrasoftTyre = new UltrasoftTyre(double.Parse(splitCommand[6]), double.Parse(splitCommand[7]));

                    }
                    




                    if(splitCommand[1] == "Aggressive ")
                    {

                    }
                    else
                    {

                    }
                    break;

                default:
                    break;
            }
        }
    }
}

