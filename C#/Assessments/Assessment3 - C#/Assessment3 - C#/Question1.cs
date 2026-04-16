using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//1. Write a program to find the Sum and the Average points scored by the teams in the IPL.
//Create a Class called CricketTeam that has a function called Pointscalculation(int no_of_matches)
//that takes no.of matches as input and accepts that many scores from the user.
//The function should then return the Count of Matches, Average and Sum of the scores.

namespace Assessment3
{
    public class CricketTeam
    {
        public static (int CountOfMatches, double Average, int Sum) Pointscalculation(int matches)
        {
            int sum = 0;
            for (int i = 0; i < matches; i++)
            {
                Console.WriteLine($"Enter the score of match {i + 1} : ");
                int score = Convert.ToInt32(Console.ReadLine());
                sum += score;
            }
            double avg = sum / matches;
            return (matches, avg, sum);
        }
    }
    internal class Question1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----------Welcome to IPL Points Calculation!----------");
            Console.WriteLine("Enter the name of your team : ");
            string teamName = Console.ReadLine();
            Console.WriteLine("Enter the number of matches : ");
            int matches = Convert.ToInt32(Console.ReadLine());

            var result = CricketTeam.Pointscalculation(matches);
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine($"Result of the team : {teamName}");
            Console.WriteLine($"Count of Matches : {result.CountOfMatches}");
            Console.WriteLine($"Average Score : {result.Average}");
            Console.WriteLine($"Total Score : {result.Sum}");

            Console.Read();
        }
    }
}
