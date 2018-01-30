using System;
using System.Linq;

namespace Task_02.Monopoly
{
    class Program
    {
        static void Main(string[] args)
        {
            // init matrix
            var dimension = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();
            char[][] monopolyDeskMatrix = new char[dimension[0]][];

            FillMatrix(monopolyDeskMatrix , dimension[1]);

            PlayingGame(monopolyDeskMatrix , dimension[1]);                   
        }

        private static void PlayingGame(char[][] monopolyDeskMatrix, int colum)
        {
            int money = 50;
            int hotelCount = 0;
            int turns = 0;

            bool isGoingLeft = true;
          
            for (int row = 0; row < monopolyDeskMatrix.Length; row++)
            {
                var colMove = isGoingLeft ? 0 : colum - 1;
                var colUpdate = isGoingLeft ? 1 : -1;

                while (colMove >= 0 && colMove < colum)
                {
                    if(monopolyDeskMatrix[row][colMove] == 'H')
                    {
                        Console.WriteLine($"Bought a hotel for {money}. Total hotels: {++hotelCount}.");
                        money = 0;                       
                    }

                    if(monopolyDeskMatrix[row][colMove] == 'J')
                    {
                        Console.WriteLine($"Gone to jail at turn {turns}.");
                        turns += 2;
                        for (int i = 0; i < 2; i++)
                        {
                            money += hotelCount * 10;
                        }                    
                    }

                    if (monopolyDeskMatrix[row][colMove] == 'S')
                    {
                        var shopPrice = (row + 1) * (colMove + 1);
                        if(money < shopPrice)
                        {
                            Console.WriteLine($"Spent {money} money at the shop.");
                            money = 0;                         
                        }
                        else
                        {
                            Console.WriteLine($"Spent {shopPrice} money at the shop.");
                            money -= shopPrice;
                        }                      
                    }

                    money += hotelCount * 10;
                    turns++;
                    colMove += colUpdate;

                }
                isGoingLeft = !isGoingLeft;
            }

            Console.WriteLine($"Turns {turns}");
            Console.WriteLine($"Money {money}");
        }

        private static void FillMatrix(char[][] monopolyDeskMatrix , int col)
        {
            for (int row = 0; row < monopolyDeskMatrix.Length; row++)
            {
                var MonopolyObjects = Console.ReadLine()
                    .ToCharArray();
                 
                monopolyDeskMatrix[row] = new char[col];

                monopolyDeskMatrix[row] = MonopolyObjects;
            }
        }
    }
}
