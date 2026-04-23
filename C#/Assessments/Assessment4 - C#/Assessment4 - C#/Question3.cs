using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Create a Generic List Collection empList and populate it with the following records.
namespace Assessment4
{
    class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string DOB { get; set; }
        public string DOJ { get; set; }
        public string City { get; set; }
    }
    internal class Question3
    {
        public static List<Employee> empList = new List<Employee>();
        public static void CreatePopulate()
        {
            empList = new List<Employee>
            {
                new Employee {EmployeeID=1001, FirstName="Malcolm", LastName="Daruwalla", Title="Manager", DOB="16/11/1984", DOJ="8/6/2011", City="Mumbai"},
                new Employee { EmployeeID=1002, FirstName="Asdin", LastName="Dhalla", Title="AsstManager", DOB="20/08/1984", DOJ="7/7/2012", City="Mumbai"},
                new Employee { EmployeeID=1003, FirstName="Madhavi", LastName="Oza", Title="Consultant", DOB="14/11/1987", DOJ="12/4/2015", City="Pune"},
                new Employee { EmployeeID=1004, FirstName="Saba", LastName="Shaikh", Title="SE", DOB="3/6/1990", DOJ="2/2/2016", City="Pune"},
                new Employee { EmployeeID=1005, FirstName="Nazia", LastName="Shaikh", Title="SE", DOB="8/3/1991", DOJ="2/2/2016", City="Mumbai"},
                new Employee { EmployeeID=1006, FirstName="Amit", LastName="Pathak", Title="Consultant", DOB="7/11/1989", DOJ="8/8/2014", City="Chennai"},
                new Employee { EmployeeID=1007, FirstName="Vijay", LastName="Natrajan", Title="Consultant", DOB="2/12/1989", DOJ="1/6/2015", City="Mumbai"},
                new Employee { EmployeeID=1008, FirstName="Rahul", LastName="Dubey", Title="Associate", DOB="11/11/1993", DOJ="6/11/2014", City="Chennai"},
                new Employee { EmployeeID=1009, FirstName="Suresh", LastName="Mistry", Title="Associate", DOB="12/8/1992", DOJ="3/12/2014", City="Chennai"},
                new Employee { EmployeeID=1010, FirstName="Sumit", LastName="Shah", Title="Manager", DOB="12/4/1991", DOJ="2/1/2016", City="Pune"}
            };
        }
        static void Display(IEnumerable<Employee> empList)
        {
            foreach (var emp in empList)
            {
                Console.WriteLine($"ID: {emp.EmployeeID} \nName: {emp.FirstName} {emp.LastName} \nTitle: {emp.Title} \nDOB: {emp.DOB} \nDOJ: {emp.DOJ} \nCity: {emp.City}");
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            CreatePopulate(); // Creating and populating the empList with employee records

            //a. Display detail of all the employee

            var allEmployee = empList;
            Console.WriteLine("----------Details of all employees----------");
            Display(allEmployee);

            //b. Display details of all the employee whose location is not Mumbai

            var notMumbai = empList.Where(e => e.City != "Mumbai");
            Console.WriteLine("----------Details of employees not located in Mumbai----------");
            Display(notMumbai);

            //c. Display details of all the employee whose title is AsstManager
            var asstManager = empList.Where(e => e.Title == "AsstManager");
            Console.WriteLine("----------Details of employees with title AsstManager----------");
            Display(asstManager);

            //d. Display details of all the employee whose Last Name start with S
            var lastNameS = empList.Where(e => e.LastName.StartsWith("S"));
            Console.WriteLine("----------Details of employees whose last name starts with S----------");
            Display(lastNameS);


        }
    }
}
