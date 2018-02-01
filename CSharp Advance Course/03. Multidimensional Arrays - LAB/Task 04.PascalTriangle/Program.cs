using System;

namespace Task_04.PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            long height = long.Parse(Console.ReadLine());

            long[][] triangle = new long[height][];
            for (long currentHeight = 0; currentHeight < height; currentHeight++)
            {
                triangle[currentHeight] = new long[currentHeight + 1];
                triangle[currentHeight][0] = 1;
                triangle[currentHeight][currentHeight] = 1;
                if(currentHeight >= 2)
                {
                    for (long widthCounter = 1; widthCounter < currentHeight; widthCounter++)
                    {
                        triangle[currentHeight][widthCounter] =
                            triangle[currentHeight - 1][widthCounter - 1] +
                            triangle[currentHeight - 1][widthCounter];
                    }
                }              
            }
            for (long row = 0; row < triangle.Length; row++)
            {
                for (long colums = 0; colums < triangle[row].Length; colums++)
                {
                    Console.Write(triangle[row][colums] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
