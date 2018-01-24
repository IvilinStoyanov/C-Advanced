using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02.BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ');
            // commands
            var itemsNeedToBePushed = int.Parse(input[0]);
            var itemsNeedToBePop = int.Parse(input[1]);
            var itemsNeedToBeChecked = int.Parse(input[2]);

            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var stack = new Stack<int>();
            for (int i = 0; i < itemsNeedToBePushed; i++)
            {
                stack.Push(numbers[i]);
            }
            for (int i = 0; i < itemsNeedToBePop; i++)
            {
                stack.Pop();
            }
            // priting
            if(stack.Count == 0 ) // checking if stack contains elements
            {
                Console.WriteLine(0);
                return;
            }
            if(stack.Contains(itemsNeedToBeChecked))
            {
                Console.WriteLine("true");
            }
            else
            {
               var smallestNumberOfStack =  stack.ToArray().Min();
                Console.WriteLine(smallestNumberOfStack);
            }
        }
    }
}
