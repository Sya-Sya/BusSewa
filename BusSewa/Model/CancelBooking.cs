using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusSewa.Model
{
    public class CancelBooking
    {
        public class CancelTrip
        {
            public int status { get; set; }
            public int noOfColumn { get; set; }
            public bool lockStatus { get; set; }
            public List<SeatLayout> seatLayout { get; set; }
        }

        public class SeatLayout
        {
            public string displayName { get; set; }
            public string bookingStatus { get; set; }
            public string bookedByCustomer { get; set; }
        }

        public class CancelRequest
        {
            public string id { get; set; }
            public string ticketSrlNo { get; set; }
        }
    }
}
