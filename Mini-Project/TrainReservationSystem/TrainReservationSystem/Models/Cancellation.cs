using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainReservationSystem.Models
{
    class Cancellation
    {
        public int CId { get; set; }

        public int BookingId { get; set; }

        public int NoTickets { get; set; }

        public decimal RefundAmount { get; set; }
    }
}
