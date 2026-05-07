using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    //    1. Create a console application and add class named Employee with following field.
    //    Employee Class :
    //    EmployeeID (Integer)
    //    FirstName (String)
    //    LastName (String)
    //    Title (String)
    //    DOB (Date)
    //    DOJ (Date)
    //    City (String)
    class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DOJ { get; set; }
        public string City { get; set; }
    }
    internal class Program
    {

        //  2. Create a Generic List Collection empList and populate it with the following records.
        //  EmployeeID FirstName    LastName Title       DOB DOJ         City
        //  1001		Malcolm Daruwalla   Manager 	16/11/1984 	8/6/2011 	Mumbai
        //  1002 		Asdin Dhalla     AsstManager 	20/08/1984 	7/7/2012 	Mumbai
        //  1003 		Madhavi Oza         Consultant 	14/11/1987 	12/4/2015 	Pune
        //  1004 		Saba Shaikh       SE 		3/6/1990	 2/2/2016	 Pune
        //  1005 		Nazia Shaikh      SE 		8/3/1991 	2/2/2016	 Mumbai
        //  1006 		Amit Pathak      Consultant 	7/11/1989 	8/8/2014 	Chennai
        //  1007 		Vijay Natrajan    Consultant 	2/12/1989	 1/6/2015 	Mumbai
        //  1008 		Rahul Dubey       Associate	 11/11/1993 	6/11/2014	 Chennai
        //  1009 		Suresh Mistry       Associate 	12/8/1992 	3/12/2014 	Chennai
        //  1010 		Sumit Shah        Manager 	12/4/1991 	2/1/2016 	Pune



        static void CreatePopulate()
        {
            List<Employee> emplist = new List<Employee>()
            {
                new Employee() { EmployeeId = 1001, FirstName = "Malcolm", LastName = "Daruwalla", Title = "Manager", DOB = Convert.ToDateTime("16/11/1984"), DOJ = Convert.ToDateTime("8/6/2011"), City = "Mumbai" },
                new Employee() { EmployeeId = 1002, FirstName = "Asdin", LastName = "Dhalla", Title = "AsstManager", DOB = Convert.ToDateTime("20/08/1984"), DOJ = Convert.ToDateTime("7/7/2012"), City = "Mumbai" },
                new Employee() { EmployeeId = 1003, FirstName = "Madhavi", LastName = "Oza", Title = "Consultant", DOB = Convert.ToDateTime("14/11/1987"), DOJ = Convert.ToDateTime("12/4/2015"), City = "Pune" },
                new Employee() { EmployeeId = 1004, FirstName = "Saba", LastName = "Shaikh", Title = "SE", DOB = Convert.ToDateTime("3/6/1990"), DOJ = Convert.ToDateTime("2/2/2016"), City = "Pune" },
                new Employee() { EmployeeId = 1005, FirstName = "Nazia", LastName = "Shaikh", Title = "SE", DOB = Convert.ToDateTime("8/3/1991"), DOJ = Convert.ToDateTime("2/2/2016"), City = "Mumbai" },
                new Employee() { EmployeeId = 1006, FirstName = "Amit", LastName = "Pathak", Title = "Consultant", DOB = Convert.ToDateTime("7/11/1989"), DOJ = Convert.ToDateTime("8/8/2014"), City = "Chennai" },
                new Employee() { EmployeeId = 1007, FirstName = "Vijay", LastName = "Natrajan", Title = "Consultant", DOB = Convert.ToDateTime("2/12/1989"), DOJ = Convert.ToDateTime("1/6/2015"), City = "Mumbai" },
                new Employee() { EmployeeId = 1008, FirstName = "Rahul", LastName = "Dubey", Title = "Associate", DOB = Convert.ToDateTime("11/11/1993"), DOJ = Convert.ToDateTime("6/11/2014"), City = "Chennai" },
                new Employee() { EmployeeId = 1009, FirstName = "Suresh", LastName = "Mistry", Title = "Associate", DOB = Convert.ToDateTime("12/8/1992"), DOJ = Convert.ToDateTime("3/12/2014"), City = "Chennai" },
                new Employee() { EmployeeId = 1010, FirstName = "Sumit", LastName = "Shah", Title = "Manager", DOB = Convert.ToDateTime("12/4/1991"), DOJ = Convert.ToDateTime("2/1/2016"), City = "Pune" }
            };


        }
        static void Main(string[] args)
        {
            CreatePopulate();


            //1. Display a list of all the employee who have joined before 1/1/2015
            Console.WriteLine("1. Display a list of empkoyee who have hoined before 1/1/2015 :");
            var empbefore2015 = emplist.Where(e => e.DOJ < new DateTime(2015, 1, 1));

            foreach (var emp in empbefore2015)
            {
                Console.WriteLine(emp.FirstName + " " + emp.LastName + " " + emp.EmployeeId);
            }

            //2. Display a list of all the employee whose date of birth is after 1/1/1990
            Console.WriteLine("2. Display a list of all the employee whose date of birth is after 1/1/1990 :");
            var empafter1990 = emplist.Where(e => e.DOB > new DateTime(1990, 1, 1));

            foreach (var emp in empafter1990)
            {
                Console.WriteLine(emp.FirstName + " " + emp.LastName + " " + emp.EmployeeId);
            }

            //3. Display a list of all the employee whose designation is Consultant and Associate

            Console.WriteLine("3. Display a list of all the employee whose designation is Consultant and Associate :");
            var empConsultantAssociate = emplist.Where(e => e.Title == "Consultant" || e.Title == "Associate");

            foreach (var emp in empConsultantAssociate)
            {
                Console.WriteLine(emp.FirstName + " " + emp.LastName + " " + emp.EmployeeId);
            }

            //4. Display total number of employees
            Console.WriteLine("4. Display total number of employees :");
            Console.WriteLine(emplist.Count());

            //5. Display total number of employees belonging to “Chennai”
            Console.WriteLine("5. Display total number of employees belonging to Chennai :");
            var empChennai = emplist.Where(e => e.City == "Chennai");
            Console.WriteLine(empChennai.Count());

            //6. Display highest employee id from the list
            Console.WriteLine("6. Display highest employee id from the list :");
            Console.WriteLine(emplist.Max(e => e.EmployeeId));

            //7. Display total number of employee who have joined after 1/1/2015
            Console.WriteLine("7. Display total number of employee who have joined after 1/1/2015 :");
            var empAfter2015 = emplist.Where(e => e.DOJ > new DateTime(2015, 1, 1));

            foreach (var emp in empAfter2015)
            {
                Console.WriteLine(emp.FirstName + " " + emp.LastName + " " + emp.EmployeeId);
            }

            //8. Display total number of employee whose designation is not “Associate”
            Console.WriteLine("8. Display total number of employee whose designation is not 'Associate' :");
            Console.WriteLine(emplist.Count(e => e.Title != "Associate"));

            //9. Display total number of employee based on City
            Console.WriteLine("9. Display total number of employee based on City :");
            var empByCity = emplist.GroupBy(e => e.City);

            foreach (var group in empByCity)
            {
                Console.WriteLine(group.Key + " : " + group.Count());
            }

            //10. Display total number of employee based on city and title
            Console.WriteLine("10. Display total number of employee based on city and title :");
            var empByCityAndTitle = emplist.GroupBy(e => new { e.City, e.Title });

            foreach (var group in empByCityAndTitle)
            {
                Console.WriteLine(group.Key.City + " - " + group.Key.Title + " : " + group.Count());
            }

            //11. Display total number of employee who is youngest in the list
            Console.WriteLine("11. Display total number of employee who is youngest in the list :");
            var youngestDOB = emplist.Max(e => e.DOB);

            foreach (var emp in emplist.Where(e => e.DOB == youngestDOB))
            {
                Console.WriteLine(emp.FirstName + " " + emp.LastName + " " + emp.EmployeeId);
            }
        }
    }
}