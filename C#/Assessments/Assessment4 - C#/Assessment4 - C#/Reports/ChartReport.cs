using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assessment4.Interface;

namespace Assessment4.Reports
{
    public class ChartReport : IReport
    {
        public void GenerateReport()
        {
            Console.WriteLine();
            Console.WriteLine("Generating Chart Report...");
            Console.WriteLine("Chart Report generated successfully!");
        }
    }
}
