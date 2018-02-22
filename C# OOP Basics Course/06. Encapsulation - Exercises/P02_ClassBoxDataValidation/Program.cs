using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            double lenght = double.Parse(Console.ReadLine());
            double widht = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            var box = new Box(lenght, widht, height);

            Console.WriteLine(box.ToString());
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        

       

    }
}


