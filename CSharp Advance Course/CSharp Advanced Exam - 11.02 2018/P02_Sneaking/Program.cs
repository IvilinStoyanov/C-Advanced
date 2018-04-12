using System;

namespace P02_Sneaking
{
    class Program
    {
        static void Main(string[] args)
        {
            // input 
            var rowMatrix = int.Parse(Console.ReadLine());

            var field = new char[rowMatrix][];
            // initialize matrix
            for (int i = 0; i < rowMatrix; i++)
            {
                var matrixColumInput = Console.ReadLine();
                field[i] = matrixColumInput.ToCharArray();
            }

            var PlayerCordinates = Console.ReadLine().ToCharArray();

            //Playing the game
            for (int i = 0; i < PlayerCordinates.Length; i++)
            {
                UpdateEnemy(field);
            }
        }

        private static void UpdateEnemy(char[][] field)
        {
            for (int i = 0; i < field.Length; i++)
            {
                for (int j = 0; j < field[i].Length; j++)
                {
                    if (field[i][j] == 'b')
                    {
                        if (j == field[i].Length - 1)
                        {
                            field[i][j] = 'd';
                        }
                    }
                    else
                    {
                        field[i][j] = '.';
                        field[i][++j] = 'b';
                    }
                    if (field[i][j] == 'd')
                    {
                        if (j == 0)
                        {
                            field[i][j] = 'b';
                        }
                    }
                    else
                    {
                        field[i][j] = '.';
                        field[i][j - 1] = 'd';
                    }
                }
            }
        }
    }
}
