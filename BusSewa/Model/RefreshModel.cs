using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusSewa.Model
{
    public class RefreshModel
    {
        public class Root
        {
            public int status { get; set; }
            public bool lockStatus { get; set; }
            public int noOfColumn { get; set; }
            public List<SeatLayout> seatLayout { get; set; }
        }

        public class SeatLayout
        {
            public string displayName { get; set; }
            public string bookingStatus { get; set; }
            public string bookedByCustomer { get; set; }
        }

        public class BusId
        {
            public string id { get; set; }
        }
    }
}