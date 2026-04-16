using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//2. Write a program in C# Sharp to append some text to an existing file.
//If the file is not available, then create one in the same workspace.

namespace Assessment3
{
    internal class Question2
    {
        static void AppendTextFile(string filePath)
        {
            
            Console.WriteLine("Enter the text to append:");
            string textToAppend = Console.ReadLine();

            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine(textToAppend);
            }
            Console.WriteLine("Text appended successfully.");
        }
        static void Main(string[] args)
        {
            string filePath = "example.txt";
            AppendTextFile(filePath);
            Console.Read();
        }
    }
}