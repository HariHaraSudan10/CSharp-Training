using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assessment4.Interface;
using Assessment4.Reports;
//2. Report Generators.
//Let’s assume we have an analytics application allowing users to generate reports in different formats:
//Chart, Tabular, or Summary.
//Using the Factory Method pattern, instantiate the appropriate report generator based on the user’s selection

namespace Assessment4
{
    public class ReportFactory
    {
        public static IReport CreateReport(string reportType)
        {
            switch (reportType.ToLower())
            {
                case "chart":
                    return new ChartReport();
                case "tabular":
                    return new TabularReport();
                case "summary":
                    return new SummaryReport();
                default:
                    Console.WriteLine("Invalid report type");
                    return null;
            }
        }
    }
    internal class Question2
    {
        public static void generate()
        {
            Console.WriteLine("Please select the type of report you want to generate (Chart, Tabular, Summary):");
            string choice = Console.ReadLine();
            IReport report = ReportFactory.CreateReport(choice);
            report.GenerateReport();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("-----------Welcome to Report Generator!-----------");
            generate();

        }
    }
}
