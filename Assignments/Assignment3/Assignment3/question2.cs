using Assignment3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//2.Create a class called student which has data members like rollno, name, class, Semester, branch, int [] marks = new int marks[5](marks of 5 subjects)

//- Pass the details of student like rollno, name, class, SEM, branch in constructor

//-For marks write a method called GetMarks() and give marks for all 5 subjects

//-Write a method called displayresult, which should calculate the average marks

//-If marks of any one subject is less than 35 print result as failed
//-If marks of all subject is >35, but average is < 50 then also print result as failed
//-If avg > 50 then print result as passed.

//-Write a DisplayData() method to display all object members values.

namespace Assignment3
{
    class Student
    {
        // Data members
        private int rollNo;
        private string name;
        private string studentClass;
        private int semester;
        private string branch;
        private int[] marks = new int[5];

        // Constructor
        public Student(int r, string n, string c, int sem, string b)
        {
            rollNo = r;
            name = n;
            studentClass = c;
            semester = sem;
            branch = b;
        }

        // Get Marks
        public void GetMarks()
        {
            Console.WriteLine("\nEnter marks for 5 subjects:");
            for (int i = 0; i < 5; i++)
            {
                Console.Write("Subject " + (i + 1) + ": ");
                marks[i] = Convert.ToInt32(Console.ReadLine());
            }
        }

        //Display Result
        public void DisplayResult()
        {
            int total = 0;
            bool fail = false;

            for (int i = 0; i < 5; i++)
            {
                if (marks[i] < 35)
                {
                    fail = true;
                }
                total += marks[i];
            }

            double average = total / 5.0;

            Console.WriteLine("\nAverage Marks: " + average);

            if (fail)
            {
                Console.WriteLine("Result: Failed (One or more subjects < 35)");
            }
            else if (average < 50)
            {
                Console.WriteLine("Result: Failed");
            }
            else
            {
                Console.WriteLine("Result: Passed");
            }
        }

        // Display Details
        public void DisplayData()
        {
            Console.WriteLine("\n--- Student Details ---");
            Console.WriteLine("Roll No: " + rollNo);
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Class: " + studentClass);
            Console.WriteLine("Semester: " + semester);
            Console.WriteLine("Branch: " + branch);

            Console.WriteLine("Marks:");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Subject " + (i + 1) + ": " + marks[i]);
            }
        }
    }

    class question2
    {
        static void Main()
        {
            // Taking input from user
            Console.Write("Enter Roll No: ");
            int rollNo = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Class: ");
            string studentClass = Console.ReadLine();

            Console.Write("Enter Semester: ");
            int semester = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Branch: ");
            string branch = Console.ReadLine();

            
            Student s = new Student(rollNo, name, studentClass, semester, branch);

            // Get marks
            s.GetMarks();

            
            s.DisplayData();
            s.DisplayResult();
        }
    }
}
