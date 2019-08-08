using System;
using System.Globalization;
using ExCompositionAndEnumeration.Entities;
using ExCompositionAndEnumeration.Entities.Enums;

namespace ExCompositionAndEnumeration
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter department's name: ");
            string deptName = Console.ReadLine();
            Console.WriteLine("Enter worker data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Level(Junior / Pleno / Senior): ");
            WorkerLevel level = new WorkerLevel();
            Enum.TryParse(Console.ReadLine(), out level);
            Console.Write("Base salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);            

            Department dept = new Department(deptName);
            Worker worker = new Worker(name, level, baseSalary, dept);

            Console.Write("How many contracts to this worker? ");
            int x = int.Parse(Console.ReadLine());

            for(int i=1; i<=x; i++)
            {
                Console.WriteLine($"Enter #{i} contract data:");
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (hours): ");
                int hours = int.Parse(Console.ReadLine());
                HourContract contracts = new HourContract(date, valuePerHour, hours);
                worker.AddContract(contracts);
            }

            Console.WriteLine();
            Console.Write("Enter month and year to calculate income (MM/YYYY): ");
            DateTime monthAndYear = DateTime.Parse(Console.ReadLine());
            double resultIncome = worker.Income(monthAndYear.Year, monthAndYear.Month);

            Console.WriteLine($"Name: {worker.Name}"); 
            Console.WriteLine($"Department: {worker.Department.Name}");
            Console.WriteLine($"Income for {monthAndYear.Month}/{monthAndYear.Year}: ${resultIncome.ToString("F2", CultureInfo.InvariantCulture)}");
        }
    }
}
