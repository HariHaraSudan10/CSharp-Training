using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assessment4.Interface;

namespace Assessment4.Reports
{
    public class TabularReport : IReport
    {
        public void GenerateReport()
        {
            Console.WriteLine();
            Console.WriteLine("Generating Tabular Report...");
            Console.WriteLine("Tabular Report generated successfully!");
        }
    }
}
