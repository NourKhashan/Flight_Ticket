using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Booking_Flight_Ticket.Models
{
    public class ResevationViewModel
    {
        public int Days { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}