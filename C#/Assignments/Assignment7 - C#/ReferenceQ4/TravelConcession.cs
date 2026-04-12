using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceQ4
{
    public class TravelConcession
    {
        public static void CalculateConcession(int age, int TotalFare)
        {
            if (age <= 5)
            {
                Console.WriteLine("Little Champs - Free Ticket");
            }
            else if (age > 60)
            {
                double discountedFare = TotalFare - (TotalFare * 0.30);
                Console.WriteLine($"Senior Citizen, Fare after Discount : {discountedFare}");
            }
            else
            {
                Console.WriteLine($"Print Ticket Booked - Fare: {TotalFare}");
            }
        }
    }
}
