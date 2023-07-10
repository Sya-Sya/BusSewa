using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusSewa.Model
{
    public class TicketQuery
    {
        public class SuccessQuery
        {
            public int status { get; set; }
            public string message { get; set; }
            public string passenger { get; set; }
            public string tripDate { get; set; }
            public string @operator { get; set; }
            public string boardingPoint { get; set; }
            public string seat { get; set; }
            public double amount { get; set; }
        }

        public class RequestQuery
        {
            public string id { get; set; }
            public string ticketSrlNo { get; set; }
        }
    }
}