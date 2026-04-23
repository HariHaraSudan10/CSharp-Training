using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assessment4.Interface;

namespace Assessment4.Reports
{
    public class SummaryReport : IReport
    {
        public void GenerateReport()
        {
            Console.WriteLine();
            Console.WriteLine("Generating Summary Report...");
            Console.WriteLine("Summary Report generated successfully!");
        }
    }

}
