using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_04.BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ');
            // commands
            var itemsNeedToBeAdded = input[0];
            var itemsNeedToBeRemoved = int.Parse(input[1]);
            var itemNeedToBePrinted = int.Parse(input[2]);
            // items to be added
            var items = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            var queueOfItems = new Queue<int>(items);
            // removing items of the queue
            for (int i = 0; i < itemsNeedToBeRemoved; i++)
            {
                queueOfItems.Dequeue();
            }
            // printing result 
            if (queueOfItems.Count == 0)
            {
                Console.WriteLine(0);
                return;
            }
            if (queueOfItems.Contains(itemNeedToBePrinted))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(queueOfItems.Min());
            }
        }
    }
}
