using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft
{
    public static class StudentsRepository
    {
        public static bool isDataInitialized = false;
        private static Dictionary<string, Dictionary<string, List<int>>> studentsByCourse =
            new Dictionary<string, Dictionary<string, List<int>>>();

        public static void InitializeData()
        {
            if(!isDataInitialized)
            {
                OutputWriter.WriteMessageOnNewLine("Reading data...");
                studentsByCourse = new Dictionary<string, Dictionary<string, List<int>>>();
                ReadData();            
            }
            else
            {
                OutputWriter.WriteMessageOnNewLine(ExceptionMessages.InitializingData);
            }
        }

        private static void ReadData()
        {
            string input = Console.ReadLine();

            while(!string.IsNullOrEmpty(input))
            {
                string[] token = input.Split(' ');
                string course = token[0];
                string student = token[1];
                int mark = int.Parse(token[2]);

                if (!studentsByCourse.ContainsKey(course))
                {
                    studentsByCourse.Add(course, new Dictionary<string, List<int>>());
                }
                if(!studentsByCourse[course].ContainsKey(student))
                {
                    studentsByCourse[course].Add(student, new List<int>());
                }
                studentsByCourse[course][student].Add(mark);
                input = Console.ReadLine();
            }
            isDataInitialized = true;
            OutputWriter.WriteMessageOnNewLine("Data read");
        }
    }
}
