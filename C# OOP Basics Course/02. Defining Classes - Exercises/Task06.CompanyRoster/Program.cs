using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var employees = new List<Employee>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            var splitInput = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var name = splitInput[0];
            var salary = decimal.Parse(splitInput[1]);
            var positon = splitInput[2];
            var department = splitInput[3];


            var employee = new Employee(name, salary, positon, department);


            if (splitInput.Length > 4)
            {
                var ageOrEmail = splitInput[4];
                if (splitInput[4].Contains("@"))
                {
                    employee.Email = ageOrEmail;
                }
                else
                {
                    employee.Age = int.Parse(ageOrEmail);
                }
            }

            if (splitInput.Length > 5)
            {
                var age = int.Parse(splitInput[5]);
                employee.Age = age;
            }

            employees.Add(employee);
        }

        var orderedEmployees = employees
            .GroupBy(e => e.Department)
            .Select(d => new
            {
                Department = d.Key,
                AverageSalary = d.Average(e => e.Salary),
                Employees = d.OrderByDescending(emp => emp.Salary)
                .ToList()
            })
            .OrderByDescending(e => e.AverageSalary)
            .FirstOrDefault();

        if (orderedEmployees != null)
        {
            Console.WriteLine($"Highest Average Salary: {orderedEmployees.Department}");

            foreach (var employee in orderedEmployees.Employees)
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:f2} {employee.Email} {employee.Age}");
            }
        }
    }
}
