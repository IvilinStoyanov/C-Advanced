using System;
using System.Linq;

namespace P03_JediGalaxy
{
    class Program
    {
        static void Main()
        {
            int[] dimestions = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int x = dimestions[0];
            int y = dimestions[1];

            int[,] matrix = new int[x, y];
            FIllMatrix(x, y, matrix);

            string command = Console.ReadLine();
            long sum = 0;
            while (command != "Let the Force be with you")
            {
                int[] ivoS = command
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int[] evilCordinate = Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                PlayerCordinates evil = new PlayerCordinates(evilCordinate[0], evilCordinate[1]);
                PlayerCordinates ivo = new PlayerCordinates(ivoS[0], ivoS[1]);

                while (evil.Row >= 0 && evil.Col >= 0)
                {
                    if (IsInField(matrix, evil.Row, evil.Col))
                    {
                         matrix[evil.Row, evil.Col] = 0;
                    }
                    evil.Row--;
                    evil.Col--;
                }

                while (ivo.Row >= 0 && ivo.Col < matrix.GetLength(1))
                {
                    if (IsInField(matrix, ivo.Row, ivo.Col))
                    {
                        sum += matrix[ivo.Row, ivo.Col];
                    }
                    ivo.Row--;
                    ivo.Col++;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(sum);
        }

        private static void FIllMatrix(int x, int y, int[,] matrix)
        {
            int value = 0;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    matrix[i, j] = value++;
                }
            }
        }

        private static void DecreaseValuesOfPlayers(int row, int col)
        {
            row--;
            col--;
        }

        private static bool IsInField(int[,] matrix, int row, int col)
        {
            if ((row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1)))
            {
                return true;
            }
            return false;
        }
    }
}

