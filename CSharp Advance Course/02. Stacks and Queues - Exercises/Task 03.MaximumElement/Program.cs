using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_03.MaximumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                var command = Console.ReadLine();
                switch (command)
                {
                    case "2":
                        stack.Pop();
                        break;
                    case "3":
                        Console.WriteLine(stack.Max());
                        break;
                    default:
                        stack.Push(int.Parse(command.Substring(2)));
                        break;
                }
            }
        }

    }
}
