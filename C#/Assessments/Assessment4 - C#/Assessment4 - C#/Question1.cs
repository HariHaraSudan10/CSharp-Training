using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//1. Write a class Distance that has int Kilometer as its member.
//Write a function that adds 2 Distance objects and sums up in the 3rd.
//Display the 3rd object details. Create a Test class to execute the above.

namespace Assessment4
{
    internal class Distance
    {
        public int Kilometer;
        public Distance(int km)
        {
            Kilometer = km;
        }
        public void addDistance(int d1, int d2)
        {
            Kilometer = d1 + d2;
        }

        public void displayDistance()
        {
            Console.WriteLine("Total Distance : " + Kilometer + " km");
        }
    }
    internal class Question1
    {
        public static void calculate()
        {
            Console.WriteLine("Enter the first distance in kilometers:");
            int km1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the second distance in kilometers:");
            int km2 = Convert.ToInt32(Console.ReadLine());

            Distance d1 = new Distance(km1);
            Distance d2 = new Distance(km2);
            Distance d3 = new Distance(0);
            d3.addDistance(d1.Kilometer, d2.Kilometer);
            d3.displayDistance();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("----------Welcome to Distance Calculator----------");
            calculate();
        }
    }
}
