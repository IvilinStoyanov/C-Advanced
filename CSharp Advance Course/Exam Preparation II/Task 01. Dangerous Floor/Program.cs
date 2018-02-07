using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var matrix = new char[8, 8];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            var line = Console.ReadLine()
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = line[col];
            }
        }

        string commandLine;
        while ((commandLine = Console.ReadLine()) != "END")
        {
            var typeOfPiece = commandLine[0];
            var currentRow = int.Parse(commandLine[1].ToString());
            var currentCol = int.Parse(commandLine[2].ToString());
            var finalRow = int.Parse(commandLine[4].ToString());
            var finalCol = int.Parse(commandLine[5].ToString());

            if (matrix[currentRow, currentCol] == 'x')
            {
                Console.WriteLine("There is no such a piece!");
                continue;
            }

            switch (typeOfPiece)
            {
                case 'K':
                    var isValid = (finalRow == currentRow - 1 && finalCol == currentCol - 1) ||
                                    (finalRow == currentRow && finalCol == currentCol - 1) ||
                                    (finalRow == currentRow + 1 && finalCol == currentCol - 1) ||
                                    (finalRow == currentRow - 1 && finalCol == currentCol) ||
                                    (finalRow == currentRow + 1 && finalCol == currentCol) ||
                                    (finalRow == currentRow - 1 && finalCol == currentCol + 1) ||
                                    (finalRow == currentRow && finalCol == currentCol + 1) ||
                                    (finalRow == currentRow + 1 && finalCol == currentCol + 1);

                    if (!isValid)
                    {
                        Console.WriteLine("Invalid move!");
                        continue;
                    }

                    if (!IsOnTheBoard(finalRow, finalCol, matrix))
                    {
                        continue;
                    }

                    matrix[currentRow, currentCol] = 'x';
                    matrix[finalRow, finalCol] = 'K';
                    break;

                case 'R':
                    if (finalRow != currentRow && finalCol != currentCol)
                    {
                        Console.WriteLine("Invalid move!");
                        continue;
                    }

                    if (!IsOnTheBoard(finalRow, finalCol, matrix))
                    {
                        continue;
                    }

                    matrix[currentRow, currentCol] = 'x';
                    matrix[finalRow, finalCol] = 'R';
                    break;

                case 'B':
                    if (Math.Abs(finalRow - currentRow) != Math.Abs(finalCol - currentCol))
                    {
                        Console.WriteLine("Invalid move!");
                        continue;
                    }

                    if (!IsOnTheBoard(finalRow, finalCol, matrix))
                    {
                        continue;
                    }

                    matrix[currentRow, currentCol] = 'x';
                    matrix[finalRow, finalCol] = 'B';
                    break;

                case 'Q':
                    if ((finalRow != currentRow && finalCol != currentCol) && (Math.Abs(finalRow - currentRow) != Math.Abs(finalCol - currentCol)))
                    {
                        Console.WriteLine("Invalid move!");
                        continue;
                    }
                    if (!IsOnTheBoard(finalRow, finalCol, matrix))
                    {
                        continue;
                    }

                    matrix[currentRow, currentCol] = 'x';
                    matrix[finalRow, finalCol] = 'Q';
                    break;

                case 'P':
                    if (finalRow != currentRow - 1 || finalCol != currentCol)
                    {
                        Console.WriteLine("Invalid move!");
                        continue;
                    }

                    if (!IsOnTheBoard(finalRow, finalCol, matrix))
                    {
                        continue;
                    }

                    matrix[currentRow, currentCol] = 'x';
                    matrix[finalRow, finalCol] = 'P';
                    break;
            }
        }
    }

    public static bool IsOnTheBoard(int finalRow, int finalCol, char[,] matrix)
    {
        if (finalRow < 0 || finalRow >= matrix.GetLength(0) || finalCol < 0 || finalCol >= matrix.GetLength(1))
        {
            Console.WriteLine("Move go out of board!");
            return false;
        }

        return true;
    }
}