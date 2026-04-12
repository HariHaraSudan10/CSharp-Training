using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Create a list of employees with following property EmpId, EmpName, EmpCity, EmpSalary. Populate some data to match the below conditions

//Write a program for following requirement
//a.	To display all employees data
//b.	To display all employees data whose salary is greater than 45000
//c.	To display all employees data who belong to Bangalore Region
//d.	To display all employees data by their names is Ascending order


namespace Assignment7
{
    internal class Question3
    {
        public class Employee
        {
            public int EmpId { get; set; }
            public string EmpName { get; set; }
            public string EmpCity { get; set; }
            public double EmpSalary { get; set; }
        }
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee { EmpId = 1, EmpName = "Arun", EmpCity = "Bangalore", EmpSalary = 50000 },
                new Employee { EmpId = 2, EmpName = "Priya", EmpCity = "Chennai", EmpSalary = 42000 },
                new Employee { EmpId = 3, EmpName = "Rahul", EmpCity = "Bangalore", EmpSalary = 60000 },
                new Employee { EmpId = 4, EmpName = "Sneha", EmpCity = "Mumbai", EmpSalary = 45000 },
                new Employee { EmpId = 5, EmpName = "Kiran", EmpCity = "Bangalore", EmpSalary = 48000 }
            };

            //a.	To display all employees data
            Console.WriteLine("All Employees:");
            Display(employees);

            //b.	To display all employees data whose salary is greater than 45000
            Console.WriteLine("All Employees data salary is greater than 45000");
            var Salary45k = employees.Where(e => e.EmpSalary > 45000);
            Display(Salary45k);

            //c.	To display all employees data who belong to Bangalore Region
            Console.WriteLine("All Employees data who belong to Banglore region");
            var BlrEmployees = employees.Where(e => e.EmpCity == "Bangalore");
            Display(BlrEmployees);

            //d.	To display all employees data by their names is Ascending order
            Console.WriteLine("Employees in ascending oreder");
            var sortedEmployees = employees.OrderBy(e => e.EmpName);
            Display(sortedEmployees);
        }

        static void Display(IEnumerable<Employee> employees)
        {
            foreach (var emp in employees)
            {
                Console.WriteLine($"ID: {emp.EmpId}, Name: {emp.EmpName}, City: {emp.EmpCity}, Salary: {emp.EmpSalary}");
            }
        }

        
    }
}
