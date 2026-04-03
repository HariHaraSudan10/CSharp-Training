using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//1. Write a C# Sharp program to remove the character at a given position in the string. The given position will be in the range 0..(string length -1) inclusive
namespace Assignment4
{
    internal class Question1
    {
        static void Main(string[] args)
        {
            string str;
            Console.WriteLine("Enter a string : ");
            str = Console.ReadLine();
            Console.WriteLine("Enter the position of the character you want to remove : ");
            int pos = Convert.ToInt32(Console.ReadLine());

            if (pos >= 0 && pos < str.Length)
            {
                Console.WriteLine("The string after removing the character at position " + pos + " is : " + str.Remove(pos, 1));
            }
            else
            {
                Console.WriteLine("Invalid position! Please enter a position between 0 and " + (str.Length - 1));
            }
        }
    }
}
    
