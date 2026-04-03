using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 3.Write a C# program to sort the elements of a given stack in descending order. 
namespace Assignment4
{
    internal class Question3
    {
        static void Main(String[] args)
        {
            Stack stack = new Stack();

            Console.WriteLine("Enter the number of elements in the stack : ");
            int num = Convert.ToInt32(Console.ReadLine());

            for(int i = 0; i < num; i++)
            {
                Console.WriteLine("Enter element " + (i + 1) + " : ");
                stack.Push(Convert.ToInt32(Console.ReadLine()));
            }

            ArrayList list = new ArrayList(stack); // new arraylist to store the elements of the stack
            list.Sort();// sorting the arraylist
            list.Reverse();// reversing the arraylist

            stack = new Stack();

            for (int i = list.Count - 1; i >= 0; i--)
            {
                stack.Push(list[i]);
            }
            Console.WriteLine("The elements of the stack in descending order");
            foreach (int element in stack)
            {
                Console.WriteLine(element);
            }
        }
    }
}
