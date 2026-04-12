using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//1.) Write a query that returns list of numbers and their squares only if square is greater than 20 

namespace Assignment7
{
    internal class Question1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the no of numbers you want to check : ");
            int size = int.Parse(Console.ReadLine());
            List<int> list = new List<int>();

            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"Enter number {i + 1} : ");
                int num = int.Parse(Console.ReadLine());
                list.Add(num);

            }
            List<(int Number, int Square)> result = Square(list);
            Console.WriteLine("\n----------Output----------");
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Number} - {item.Square}");
            }


        }

        static List<(int Number, int Square)> Square(List<int> numbers)
        {
            return numbers
            .Select(n => (Number: n, Square: n * n))
            .Where(x => x.Square > 20)
            .ToList();
        }
    }
}
