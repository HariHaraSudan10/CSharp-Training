using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1
{
    internal class Question1
    {
        static void Main(string[] args)
        {
            
            Employee emp = new Employee();
            int choice;
            do
            {
                Console.WriteLine("Enter your choice : 1. Add New Employee \n2. View All Employees \n3. Search Employee by ID \n4. Update Employee Details \n5. Delete Employee \n6. Exit");
                choice = int.Parse(Console.ReadLine());
                Console.WriteLine("------------------------------------------------------------------");
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter no of employees to add : ");
                        int n = int.Parse(Console.ReadLine());
                        for (int i = 0; i < n; i++)
                        {
                            Console.WriteLine($"Enter Employee {i + 1} ID : ");
                            int id = int.Parse(Console.ReadLine());
                            Console.WriteLine($"Enter Employee {i + 1} Name : ");
                            string name = Console.ReadLine();
                            Console.WriteLine($"Enter Employee {i + 1} Department : ");
                            string dept = Console.ReadLine();
                            Console.WriteLine($"Enter Employee {i + 1} Salary : ");
                            int salary = int.Parse(Console.ReadLine());
                            emp.AddEmp(id, name, dept, salary);
                            Console.WriteLine($"Employee {i+1} added successfully!");
                            Console.WriteLine("------------------------------------------------------------------");
                            Console.WriteLine();
                        }
                        break;

                    case 2:
                        ArrayList viewList = emp.ViewEmp();
                        foreach (Employee e in viewList)
                        {
                            Console.WriteLine($"ID: {e.ID} \nName: {e.Name} \nDepartment: {e.Department} \nSalary: {e.Salary}");
                            Console.WriteLine();
                        }
                        Console.WriteLine("------------------------------------------------------------------");
                        Console.WriteLine();
                        break;

                    case 3:
                        Console.WriteLine("Enter Employee ID to search : ");
                        int searchId = int.Parse(Console.ReadLine());
                        emp.SearchEmp(searchId);
                        Console.WriteLine("------------------------------------------------------------------");
                        Console.WriteLine();
                        break;

                    case 4:
                        Console.WriteLine("Enter Employee ID to update : ");
                        int updateId = int.Parse(Console.ReadLine());
                        Console.WriteLine($"Enter new name for Employee {updateId} : ");
                        string newName = Console.ReadLine();
                        Console.WriteLine($"Enter new department for Employee {updateId} : ");
                        string newDept = Console.ReadLine();
                        Console.WriteLine($"Enter new salary for Employee {updateId} : ");
                        int newSalary = int.Parse(Console.ReadLine());
                        emp.UpdateEmp(updateId, newName, newDept, newSalary);
                        Console.WriteLine($"Employee {updateId} updated successfully!");
                        Console.WriteLine("------------------------------------------------------------------");
                        Console.WriteLine();
                        break;

                    case 5:
                        Console.WriteLine("Enter Employee ID to delete : ");
                        int deleteId = int.Parse(Console.ReadLine());
                        emp.DeleteEmp(deleteId);
                        Console.WriteLine($"Employee {deleteId} deleted successfully!");
                        Console.WriteLine("------------------------------------------------------------------");
                        Console.WriteLine();
                        break;

                    case 6:
                        Console.WriteLine("Exiting the program...");
                        break;

                    default:
                         Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                        break ;
                }
            }
            while (choice < 6 );
        }
    }

    class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public int Salary { get; set; }

        static ArrayList emparray = new ArrayList();

        //add employee
        public void AddEmp(int id, string name, string dept, int salary)
        {
            emparray.Add(new Employee { ID = id , Name = name, Department = dept, Salary = salary});
        }

        //display employee
        public ArrayList ViewEmp()
        {
            return emparray;
        }

        //search employee 
        public  Employee SearchEmp(int id)
        {
            foreach (Employee emp in emparray)
            {
                if (emp.ID == id)
                {
                    string details = $"ID: {emp.ID} \nName: {emp.Name} \nDepartment: {emp.Department} \nSalary: {emp.Salary}";
                    Console.WriteLine(details);
                    
                }

            }
            return null;
        }

        //update employee
        public void UpdateEmp(int id, string name, string dept, int salary)
        {
            for (int i = 0; i < emparray.Count; i++)
            {
                Employee emp = (Employee)emparray[i];
                if (emp.ID == id)
                {
                    emp.Name = name;
                    emp.Department = dept;
                    emp.Salary = salary;
                    break;
                }
            }
        }

        //delete employee
        public void DeleteEmp(int id)
        {
            for (int i = 0; i < emparray.Count; i++)
            {
                Employee emp = (Employee)emparray[i];
                if (emp.ID == id)
                {
                    emparray.RemoveAt(i);
                    break;
                }
            }
        }
    }
}
