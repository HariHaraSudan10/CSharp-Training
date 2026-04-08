using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//1.Create an Abstract class Student with Name, StudentId, Grade as members and also an abstract method Boolean Ispassed(grade) which takes grade as an input and checks whether student passed the course or not.  
 
//Create 2 Sub classes Undergraduate and Graduate that inherits all members of the student and overrides Ispassed(grade) method
 
//For the UnderGrad class, if the grade is above 70.0, then isPassed returns true, otherwise it returns false. For the Grad class, if the grade is above 80.0, then isPassed returns true, otherwise returns false.
 
//Test the above by creating appropriate objects


namespace Assessment2
{
    public abstract class Student
    {
        public string Name { get; set; }
        public int StudentId { get; set; }
        public double Grade { get; set; }
        public abstract bool IsPassed(double grade);
    }

    public class Undergraduate : Student
    {
        public override bool IsPassed(double grade)
        {
            return grade > 70.0;
        }
    }
    public class Graduate : Student
    {
        public override bool IsPassed(double grade)
        {
            return grade > 80.0;
        }
    }
    internal class Question1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the name of the undergraduate student:");
            string ugName = Console.ReadLine();
            Console.WriteLine("Enter the student ID of the undergraduate student:");
            int ugId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the grade of the undergraduate student:");
            double ugGrade = double.Parse(Console.ReadLine());
            Undergraduate ug = new Undergraduate { Name = ugName, StudentId = ugId, Grade = ugGrade };
            bool ugCheck = ug.IsPassed(ugGrade);
            Console.WriteLine("\n--------------------------------------------------------------------------");
            Console.WriteLine("-----------Result----------");
            Console.WriteLine($"Undergraduate student {ug.Name} with ID {ug.StudentId} has {(ugCheck ? "passed" : "failed")}.");
            Console.WriteLine("\n--------------------------------------------------------------------------");
            Console.WriteLine("Enter the name of the graduate student:");
            string gName = Console.ReadLine();
            Console.WriteLine("Enter the student ID of the graduate student:");
            int gId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the grade of the graduate student:");
            double gGrade = double.Parse(Console.ReadLine());
            Undergraduate g = new Undergraduate { Name = gName, StudentId = gId, Grade = gGrade };
            bool gCheck = g.IsPassed(gGrade);
            Console.WriteLine("\n--------------------------------------------------------------------------");
            Console.WriteLine("-----------Result----------");
            Console.WriteLine($"Graduate student {g.Name} with ID {g.StudentId} has {(gCheck ? "passed" : "failed")}.");
            Console.WriteLine("\n--------------------------------------------------------------------------");
        }
    }
}
