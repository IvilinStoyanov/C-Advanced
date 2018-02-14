using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02.ParkingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimension = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var basicRow = dimension[0];
            var basicColumn = dimension[1];

            bool[][] parkingMatrix = new bool[dimension[0]][];

            for (int row = 0; row < parkingMatrix.Length; row++)
            {
                parkingMatrix[row] = new bool[dimension[1]];
                for (int col = 0; col < parkingMatrix[row].Length; col++)
                {
                    if (row == 0)
                    {
                        parkingMatrix[row][col] = true;
                    }
                }             
            }
            string command;
            while((command = Console.ReadLine()) != "stop")
            {
                var position = command
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var entryPosition = position[0];
                var desiredRow = position[1];
                var desiredCol = position[2];

                if(parkingMatrix[desiredRow][desiredCol] == false)
                {
                    var step = Math.Abs((desiredRow - basicRow) + (desiredCol - basicColumn)) + 1;
                }
            }
        }
    }
}
