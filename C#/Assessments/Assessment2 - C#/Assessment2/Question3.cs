using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//3. Write a C# program to implement a method that takes an integer as input and throws an exception if the number is negative.
//Handle the exception in the calling code.

namespace Assessment2
{
    internal class Question3
    { 
        static void CheckNumber(int num)
        {
            if (num < 0)
            {
                throw new ArgumentException("Number cannot be negative.");
            }
            else
            {
                Console.WriteLine($"The number {num} is valid.");
            }
        }

        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter a number: ");
                int number = int.Parse(Console.ReadLine());
                CheckNumber(number);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            catch (FormatException) 
            {
                Console.WriteLine("Please enter a number...");
            }
        }
    }
}
