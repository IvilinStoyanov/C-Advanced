using System;

public class Program
{
    public static void Main()
    {
        ThreeupleSolution();
    }

    private static void ThreeupleSolution()
    {

        var input = Console.ReadLine().Split();
        var name = $"{input[0]} {input[1]}";
        var address = input[2];
        var town = input[3];
        Console.WriteLine(new Threeuple<string, string, string>(name, address, town));


        input = Console.ReadLine().Split();
        name = input[0];
        var beerLiterrs = int.Parse(input[1]);
        var drunkOrNot = input[2] == "drunk";
        Console.WriteLine(new Threeuple<string, int, bool>(name, beerLiterrs, drunkOrNot));


        input = Console.ReadLine().Split();
        name = input[0];
        var accountBalance = double.Parse(input[1]);
        var bankName = input[2];
        Console.WriteLine(new Threeuple<string, double, string>(name, accountBalance, bankName));
    }
}

