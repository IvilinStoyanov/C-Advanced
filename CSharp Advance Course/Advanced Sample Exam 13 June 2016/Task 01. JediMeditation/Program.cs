using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_01._JediMeditation
{
    class Program
    {
        static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());

            var sequanceOfJedis = Console.ReadLine()
                .Split(" ");

            List<string> jediMaster = new List<string>();
            List<string> jediKnight = new List<string>();
            List<string> padawans = new List<string>();
            List<string> toshkoAndSlav = new List<string>();
            List<string> yodaMaster = new List<string>();

            List<string> orderedJedis = new List<string>();

            for (int i = 0; i < sequanceOfJedis.Length; i++)
            {
                var currentJedi = sequanceOfJedis[i].ToLower();

                if (sequanceOfJedis[i].StartsWith('m'))
                {
                    jediMaster.Add(currentJedi);
                }
                else if (sequanceOfJedis[i].StartsWith('k'))
                {
                    jediKnight.Add(currentJedi);
                }
                else if (sequanceOfJedis[i].StartsWith('p'))
                {
                    padawans.Add(currentJedi);
                }
                else if (sequanceOfJedis[i].StartsWith('s') || sequanceOfJedis[i].StartsWith('t'))
                {
                    toshkoAndSlav.Add(currentJedi);
                }
                else
                {
                    yodaMaster.Add(currentJedi);
                }
            }

            if (!yodaMaster.Any())
            {
                Console.WriteLine(string.Join(" ", toshkoAndSlav) + " " + string.Join(" ", jediMaster) + " " + string.Join(" ", jediKnight) +
                  " " + string.Join(" ", padawans));
            }
            else
            {
                Console.WriteLine(string.Join(" ", jediMaster) + " " + string.Join(" ", jediKnight) + " " + string.Join(" ", toshkoAndSlav) + " " +
                    string.Join(" ", padawans));
            }
        }
    }
}

