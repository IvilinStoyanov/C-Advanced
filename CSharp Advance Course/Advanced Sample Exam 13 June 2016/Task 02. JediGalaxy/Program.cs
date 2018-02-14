using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Task_02.JediGalaxy
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var galaxyRow = dimensions[0];
            var galaxyColumn = dimensions[1];

            int counter = 0;

            BigInteger result = 0;

            // init matrix 
            int[][] matrix = new int[dimensions[0]][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new int[galaxyColumn];
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = counter++;
                }
            }

            string command = Console.ReadLine();
            while (command != "Let the Force be with you")
            {
                // first Ivo 
                var cordinates = command
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var ivoRow = cordinates[0];
                var ivoColum = cordinates[1];

                var dartVeidarCordinates = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var veidarRow = dartVeidarCordinates[0];
                var veidarColum = dartVeidarCordinates[1];


                while(veidarRow >= 0 && veidarColum >= 0)
                {
                    if(IsInMatrix(veidarRow, veidarColum , galaxyRow , galaxyColumn))
                    {
                        matrix[veidarRow][veidarColum] = 0;                     
                    }
                    veidarRow--;
                    veidarColum--;
                }

                while(ivoRow >= 0 && ivoColum < galaxyColumn)
                {
                    if (IsInMatrix(ivoRow, ivoColum, galaxyRow, galaxyColumn))
                    {
                        result += matrix[ivoRow][ivoColum];                      
                    }
                    ivoRow--;
                    ivoColum++;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(result);
        }

        private static bool IsInMatrix(int row, int col, int galaxyRow, int galaxyColumn)
        {
            if(row >= 0 && row < galaxyRow && col >= 0 && col < galaxyColumn)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
