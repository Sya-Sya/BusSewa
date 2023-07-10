using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusSewa.Model
{
    public class TicketBookModel
    {
        public class BookRoot
        {
            public int status { get; set; }
            public string ticketSrlNo { get; set; }
            public string timeOut { get; set; }
            public List<string> boardingPoints { get; set; }
        }

        public class BookRequest
        {
            public string id { get; set; }
            public List<string> seat { get; set; }
        }
    }
}
