using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//3. Write a program in C# Sharp to count the number of lines in a file.

namespace Assignment6
{
    internal class Question3
    {
        static void Main(string[] args)
        {
            string filepath = "sample.txt";
            
            string[] lines = File.ReadAllLines(filepath);

            int count = lines.Length;

            Console.WriteLine("Number of lines in the file is : " + count);
            Console.Read();
        }
    }
}
