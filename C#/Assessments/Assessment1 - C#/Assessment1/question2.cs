using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;



namespace Assessment1
{
    struct DateOfBirth
    {
        public int day;
        public int month;
        public int year;
    }

    struct Employees
    {
        public string name;
        public DateOfBirth dob; 
    }

    class Question2
    {
        static void Main()
        {
            Console.Write("Enter number of employees: ");
            int n = int.Parse(Console.ReadLine());
            Employees[] emp = new Employees[n];
            for (int i = 0; i < n; i++)
                {
                Console.Write($"Name of the employee {i+1} : ");
                emp[i].name = Console.ReadLine();

                Console.Write("Input day of the birth : ");
                emp[i].dob.day = int.Parse(Console.ReadLine());

                Console.Write("Input month of the birth : ");
                emp[i].dob.month = int.Parse(Console.ReadLine());

                Console.Write("Input year for the birth : ");
                emp[i].dob.year = int.Parse(Console.ReadLine());

                Console.WriteLine();
            }

                Console.WriteLine("\nEmployee Details:");
            Console.WriteLine("-------------------------");

            for (int i = 0; i < emp.Length; i++)
            {
                Console.WriteLine("Name: " + emp[i].name);
                Console.WriteLine("Date of Birth: {0:D2}/{1:D2}/{2}",emp[i].dob.day, emp[i].dob.month, emp[i].dob.year);
                Console.WriteLine();
            }
        }
    }

}
