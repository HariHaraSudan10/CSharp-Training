using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//2. Write a program in C# Sharp to create a file and write an array of strings to the file. Also Read from the file

namespace Assignment6
{
    internal class Question2
    {
        static void Main(string[] args)
        {
            string filepath = "sample.txt";
            Console.WriteLine("Enter the number of lines you want to write in the file");
            int n = Convert.ToInt32(Console.ReadLine());
            string[] lines = new string[n];

            for(int i = 0; i < n; i++)
            {
                Console.WriteLine($"Enter line {i+1}:");
                lines[i] = Console.ReadLine();
            }


            string directory = Path.GetDirectoryName(filepath);
            if (!string.IsNullOrEmpty(directory))
            {
                Directory.CreateDirectory(directory);
            }

            File.WriteAllLines(filepath, lines);

            string[] readLines = File.ReadAllLines(filepath);
            Console.WriteLine("------------------------------");
            Console.WriteLine("File contents:");
            Console.WriteLine("------------------------------");
            foreach (string line in readLines)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine("------------------------------");
            Console.Read();
        }
    }
}
