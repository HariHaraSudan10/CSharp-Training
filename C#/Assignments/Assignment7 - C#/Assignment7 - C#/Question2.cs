using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//2.) Write a query that returns words starting with letter 'a' and ending with letter 'm'.


namespace Assignment7
{
    internal class Question2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of words : ");
            int size = int.Parse(Console.ReadLine());
            string[] words = new string[size];
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"Enter word {i + 1} : ");
                words[i] = Console.ReadLine();
            }
            List<string> result = GetWords(words);
            Console.WriteLine("-----------Output-----------");
            foreach (var word in result)
            {
                Console.WriteLine(word);
            }
        }

        static List<string> GetWords(string[] words)
        {
            return words
                .Where(w => w.StartsWith("a", StringComparison.OrdinalIgnoreCase) &&
                            w.EndsWith("m", StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}
