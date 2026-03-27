using System;


namespace Assignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            pattern();//Question 1

            checkDay();//Question 2

            Arrays.Q1();//"Arrays"-->Question 1

            Arrays.Q2();//"Arrays"-->Question 2


        }

        //question 1

        static void pattern()
        {
            Console.WriteLine("Question 1");
            Console.WriteLine();
            Console.WriteLine("Enter a digit : ");
            int num = int.Parse(Console.ReadLine());
            for(int i = 0; i < 2; i++)
            {
                Console.WriteLine("{0} {1} {2} {3}", num , num , num, num);
                Console.WriteLine("{0}{1}{2}{3}", num, num, num, num);
            }
        }

        //question 2

        static void checkDay()
        {
            Console.WriteLine("Question 2");
            Console.WriteLine();
            Console.WriteLine("Enter a day in number between 1 to 7 : ");
            int day = int.Parse(Console.ReadLine());
            switch (day)
            {
                case 1: 
                    Console.WriteLine("Monday");
                    break;

                case 2:
                    Console.WriteLine("Tuesday");
                    break;

                case 3:
                    Console.WriteLine("Wednesday");
                    break;

                case 4:
                    Console.WriteLine("Thursday");
                    break;

                case 5:
                    Console.WriteLine("Friday");
                    break;

                case 6:
                    Console.WriteLine("Saturday");
                    break;

                case 7:
                    Console.WriteLine("Sunday");
                    break;

                default : Console.WriteLine("Invalid day");
                    break;
            }
        }
    }
}
