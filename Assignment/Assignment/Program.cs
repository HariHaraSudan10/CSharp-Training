using System;


namespace Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            checkQ1();//question 1

            checkQ2();//question 2

            checkQ3();//question 3

            checkQ4();//question 4

            checkQ5();//question 5
        }

        //question 1
        static void checkQ1()
        {
            Console.WriteLine("Question 1");

            Console.WriteLine("Input 1st number : ");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Input 2nd number : ");
            int b = int.Parse(Console.ReadLine());
            if (a == b)
            {
                Console.WriteLine($"{a} and {b} are equal");
            }else
            {
                Console.WriteLine($"{a} and {b} are not equal");
            }
        }

        //question 2
        static void checkQ2()
        {
            Console.WriteLine("Question 2");

            Console.WriteLine("Enter a number : ");
            int a = int.Parse(Console.ReadLine());
            if (a==0) 
            {
                Console.WriteLine($"{a} is neutral");
            } else if (a < 0)
            {
                Console.WriteLine($"{a} is negative");
            }
            else
            {
                Console.WriteLine($"{a} is positive");
            }
        }

        //question 3
        static void checkQ3()
        {
            Console.WriteLine("Question 3");
            Console.WriteLine("Enter 1st number : ");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter 2nd number : ");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine($"{a} + {b} = {a+b}");
            Console.WriteLine($"{a} - {b} = {a-b}");
            Console.WriteLine($"{a} * {b} = {a*b}");
            Console.WriteLine($"{a} / {b} = {a/b}");
        }

        //question 4
        static void checkQ4()
        {
            Console.WriteLine("Question 4");

            Console.WriteLine("Enter the number : ");
            int a = int.Parse(Console.ReadLine());
            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine($"{a} * {i} = {a * i}");
            }
        }

        //question 5
        static void checkQ5()
        {
            Console.WriteLine("Question 5");

            Console.WriteLine("Input 1st number : ");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Input 2nd number : ");
            int b = int.Parse(Console.ReadLine());
            if (a == b)
            {
                Console.WriteLine((a+b)*3);
            } else
            {
                Console.WriteLine(a + b);
            }
        }
    }
}
