using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 2.Write a C# Sharp program to exchange the first and last characters in a given string and return the new string.



namespace Assignment4
{
    internal class Question2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string : ");
            string str = Console.ReadLine();
            if(str.Length > 1)
            {
                char[] arr = str.ToCharArray();
                char temp = arr[0];
                arr[0]= arr[arr.Length - 1];
                arr[arr.Length-1]= temp;

                str = new string(arr);

                Console.WriteLine("-----------------------------------------------------------------------");
                Console.WriteLine("The string after exchanging the first and last characters is : " + str);
            }
            else
            {
                Console.WriteLine(str);
            }
        }
    }
}
