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

            
            List<string> jediMaster = new List<string>();
            List<string> jediKnight = new List<string>();
            List<string> padawans = new List<string>();
            List<string> toshkoAndSlav = new List<string>();
            List<string> yodaMaster = new List<string>();
      
            for (int i = 0; i < count; i++)
            {
                var sequanceOfJedis = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int jedi = 0; jedi < sequanceOfJedis.Length; jedi++)
                {
                    var currentJedi = sequanceOfJedis[jedi].ToLower();

                    if (sequanceOfJedis[jedi].StartsWith("m"))
                    {
                        jediMaster.Add(currentJedi);
                    }
                    else if (sequanceOfJedis[jedi].StartsWith("k"))
                    {
                        jediKnight.Add(currentJedi);
                    }
                    else if (sequanceOfJedis[jedi].StartsWith("p"))
                    {
                        padawans.Add(currentJedi);
                    }
                    else if (sequanceOfJedis[jedi].StartsWith("s") || sequanceOfJedis[jedi].StartsWith("t"))
                    {
                        toshkoAndSlav.Add(currentJedi);
                    }
                    else
                    {
                        yodaMaster.Add(currentJedi);
                    }
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

