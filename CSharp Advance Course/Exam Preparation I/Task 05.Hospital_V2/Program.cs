using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_05.Hospital_V2
{
    class Program
    {
        static void Main(string[] args)
        {
            // data storing
            var departmentWithPatients = new Dictionary<string, List<string>>();
            var doctorWithPatiens = new Dictionary<string, List<string>>();

            // Input
            string input;
            while ((input = Console.ReadLine()) != "Output")
            {
                var splitInput = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var department = splitInput[0];
                var doctorFullName = splitInput[1] + " " + splitInput[2];
                var patient = splitInput[3];

                bool isPlaceFree = CheckForPlace(departmentWithPatients, department, patient);
                if (isPlaceFree)
                {
                    departmentWithPatients = AddDepartmentWithPatient(department, patient, departmentWithPatients);
                    doctorWithPatiens = AddDoctorWithPatient(doctorFullName, patient, doctorWithPatiens);
                }
            }

            // Commands
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                var commandSplit = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (departmentWithPatients.ContainsKey(command))
                {
                    PrintPatiens(departmentWithPatients , command);
                }
                else if (doctorWithPatiens.ContainsKey(command)) 
                {
                    PrintDoctorsPatiens(doctorWithPatiens , command);
                }
                else
                {
                    var department = commandSplit[0];
                    var room = int.Parse(commandSplit[1]);

                    var startIndex = 0;
                    var endIndex = 0;
                    for (int i = 1; i <= room; i++)
                    {
                        if (i == 1)
                        {
                            startIndex = 0;
                            endIndex = 2;
                        }
                        else
                        {
                            startIndex += 3;
                            endIndex += 3;
                        }
                    }

                    PringPatiensInRooms(startIndex, endIndex, department, departmentWithPatients);
                   
                }


            }
        }

        private static void PringPatiensInRooms(int startIndex, int endIndex, string department, Dictionary<string, List<string>> departmentWithPatients)
        {
            List<string> patients = new List<string>();
            var lastPatient = departmentWithPatients[department].Count - 1;
            if(startIndex > lastPatient)
            {
                return;
            }
            if(endIndex > lastPatient)
            {
                endIndex = lastPatient;
            }

            for (int i = startIndex; i <= endIndex; i++)
            {
                patients.Add(departmentWithPatients[department][i]);
            }

            foreach (var p in patients.OrderBy(p => p))
            {
                Console.WriteLine(p);
            }
        }

        private static void PrintDoctorsPatiens(Dictionary<string, List<string>> doctorWithPatiens , string doctor)
        {
            foreach (var patient in doctorWithPatiens[doctor].OrderBy(p => p))
            {
                Console.WriteLine(patient);
            }
        }

        private static void PrintPatiens(Dictionary<string, List<string>> departmentWithPatients , string department)
        {
            foreach (var patient in departmentWithPatients[department])
            {
                Console.WriteLine(patient);
            }
        }

        private static Dictionary<string, List<string>> AddDoctorWithPatient(string doctorFullName, string patient, Dictionary<string, List<string>> doctorWithPatiens)
        {
            if (!doctorWithPatiens.ContainsKey(doctorFullName))
            {
                doctorWithPatiens.Add(doctorFullName, new List<string>());
                doctorWithPatiens[doctorFullName].Add(patient);
            }
            else
            {
                doctorWithPatiens[doctorFullName].Add(patient);
            }
            return doctorWithPatiens;
        }

        private static Dictionary<string, List<string>> AddDepartmentWithPatient(string department, string patient, Dictionary<string, List<string>> departmentWithPatients)
        {
            if (!departmentWithPatients.ContainsKey(department))
            {
                departmentWithPatients.Add(department, new List<string>());
                departmentWithPatients[department].Add(patient);
            }
            else
            {
                departmentWithPatients[department].Add(patient);
            }
            return departmentWithPatients;

        }

        private static bool CheckForPlace(Dictionary<string, List<string>> departmentWithPatients, string department, string patient)
        {
            if (!departmentWithPatients.ContainsKey(department))
            {
                return true;
            }
            else if (departmentWithPatients[department].Count < 60)
            {
                return true;
            }           
                return false;           
        }
    }
}
