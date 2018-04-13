using System;
using System.Linq;

namespace P02_Sneaking
{
    class Program
    {
        static void Main(string[] args)
        {
            // input 
            var rowMatrix = int.Parse(Console.ReadLine());

            var field = new char[rowMatrix][];

            //Sam start position
            int[] samCordinates = null;

            // initialize matrix
            for (int i = 0; i < rowMatrix; i++)
            {
                var matrixColumInput = Console.ReadLine();
                field[i] = matrixColumInput.ToCharArray();

                if (field[i].Contains('S'))
                {
                    samCordinates = new int[] { i, Array.IndexOf(field[i], 'S') };
                }
            }

            var playerCordinates = Console.ReadLine().ToCharArray();

            //Playing the game
            for (int i = 0; i < playerCordinates.Length; i++)
            {
                UpdateEnemy(field);
                EnemyKill(field);
                MovePlayer(field, samCordinates, playerCordinates[i]);
                CheckNikolazde(field);
            }
        }

        private static void CheckNikolazde(char[][] field)
        {
            for (int i = 0; i < field.Length; i++)
            {
                if (field[i].Contains('N') && field[i].Contains('S'))
                {
                    field[i][Array.IndexOf(field[i], 'N')] = 'X';
                    Console.WriteLine("Nikoladze killed!");
                    PrintMatrix(field);
                }
            }
        }

        private static void MovePlayer(char[][] field, int[] samCordinates, char cordinates)
        {
            switch (cordinates)
            {
                case 'U':
                    field[samCordinates[0]][samCordinates[1]] = '.';
                    field[--samCordinates[0]][samCordinates[1]] = 'S';
                    break;
                case 'D':
                    field[samCordinates[0]][samCordinates[1]] = '.';
                    field[++samCordinates[0]][samCordinates[1]] = 'S';
                    break;
                case 'L':
                    field[samCordinates[0]][samCordinates[1]] = '.';
                    field[samCordinates[0]][--samCordinates[1]] = 'S';
                    break;
                case 'R':
                    field[samCordinates[0]][samCordinates[1]] = '.';
                    field[samCordinates[0]][++samCordinates[1]] = 'S';
                    break;
                default:
                    break;
            }
        }

        private static void EnemyKill(char[][] matrix)
        {
            for (var line = 0; line < matrix.Length; line++)
            {
                if (matrix[line].Contains('b') && matrix[line].Contains('S'))
                {
                    if (Array.IndexOf(matrix[line], 'b') < Array.IndexOf(matrix[line], 'S'))
                    {
                        matrix[line][Array.IndexOf(matrix[line], 'S')] = 'X';
                        Console.WriteLine($"Sam died at {line}, {Array.IndexOf(matrix[line], 'X')}");
                        PrintMatrix(matrix);
                    }
                }
                else if (matrix[line].Contains('d') && matrix[line].Contains('S'))
                {
                    if (Array.IndexOf(matrix[line], 'd') > Array.IndexOf(matrix[line], 'S'))
                    {
                        matrix[line][Array.IndexOf(matrix[line], 'S')] = 'X';
                        Console.WriteLine($"Sam died at {line}, {Array.IndexOf(matrix[line], 'X')}");
                        PrintMatrix(matrix);
                    }
                }
            }
        }

        private static void PrintMatrix(char[][] field)
        {
            for (int i = 0; i < field.Length; i++)
            {
                Console.WriteLine(string.Join("", field[i]));
            }
            Environment.Exit(0);
        }

        private static void PlayerKilled(int row, int col)
        {
            Console.WriteLine($"Sam died at {row}, {col}");
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

                        else
                        {
                            field[i][j] = '.';
                            field[i][++j] = 'b';
                        }
                    }
                    else if (field[i][j] == 'd')
                    {
                        if (j == 0)
                        {
                            field[i][j] = 'b';
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
}
