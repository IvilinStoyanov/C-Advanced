using System;
using System.Linq;

namespace Task_01.DangerousFloor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[][] chessBoardMatrix = new string[8][];
            FillMatrix(chessBoardMatrix);   // init matrix

            string command;
            while ((command = Console.ReadLine()) != "END") 
            {
               


                

            }


            PrintMatrix(chessBoardMatrix); // Print matrix
        }

        private static void PrintMatrix(string[][] chessBoardMatrix)
        {
            for (int row = 0; row < chessBoardMatrix.Length; row++)
            {
                Console.WriteLine(string.Join(" ", chessBoardMatrix[row]));
            }
        }

        private static void FillMatrix(string[][] chessBoardMatrix)
        {
            for (int row = 0; row < chessBoardMatrix.Length; row++)
            {
                var input = Console.ReadLine()
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                chessBoardMatrix[row] = new string[8];
                chessBoardMatrix[row] = input;
            }
        }

    }
}
