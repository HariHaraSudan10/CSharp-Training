using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainReservationSystem.Models
{
    class Train
    {
        public int TrainNo { get; set; }
        public string TrainName { get; set; }
        public string FromStation { get; set; }
        public string ToStation { get; set; }
        public string TrainClass { get; set; }
        public int Availability { get; set; }
        public decimal Charges { get; set; }
    }
}
