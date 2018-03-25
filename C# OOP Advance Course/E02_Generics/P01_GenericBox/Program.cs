using System;


class Program
{
    static void Main(string[] args)
    {
        BoxManager boxManager = new BoxManager();

        //boxManager.GenericBox(); // P01
        //boxManager.GenericBoxOfString(); // P02
        // boxManager.GenericBoxOfInteger(); // P03
       // boxManager.GenericSwapMethodStrings(); // P04
        //boxManager.GenericSwapMethodIntegers(); // P05
        //boxManager.GenericCountMethodStrings(); // P06
        boxManager.GenericCountMethodDoubles(); // P07

    }
}
