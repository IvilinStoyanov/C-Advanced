using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_05.HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ');
            var toss = int.Parse(Console.ReadLine());
            var childrens = new Queue<string>(input);
            while (childrens.Count != 1)
            {
                for (int i = 1; i < toss; i++)
                {
                    childrens.Enqueue(childrens.Dequeue());
                }
                Console.WriteLine($"Removed {childrens.Dequeue()}");
            }
            Console.WriteLine($"Last is {childrens.Dequeue()}");        
        }      
    }
}
