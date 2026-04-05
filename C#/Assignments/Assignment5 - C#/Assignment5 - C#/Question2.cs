using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    public class InvalidScolarshipException : Exception
    {
        public InvalidScolarshipException(string message) : base(message)
        {
        }
    }
    class Scholarship
    {
        public double Merit(int marks, double fees)
        {
            if (marks >= 70 && marks <= 80)
            {
                return fees * 0.20;
            }
            else if (marks > 80 && marks <= 90)
            {
                return fees * 0.30;
            }
            else if (marks > 90)
            {
                return fees * 0.50;
            }
            else
            {
            throw new InvalidScolarshipException("Marks not eligible for scholarship!");
            }
        }
    }

    internal class Question2
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter Marks: ");
                int marks = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Fees: ");
                double fees = Convert.ToDouble(Console.ReadLine());

                Scholarship obj = new Scholarship();

                double scholarshipAmount = obj.Merit(marks, fees);

                Console.WriteLine("Scholarship Amount: " + scholarshipAmount);
            }
            catch (InvalidScolarshipException ex)
            {
                Console.WriteLine("Custom Exception: " + ex.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input! Please enter correct data.");
            }
            finally
            {
                Console.WriteLine("Process Completed.");
            }
        }
    }
}
