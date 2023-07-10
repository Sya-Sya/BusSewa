using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusSewa.Model
{
    public class UserDetailModel
    {
        public class UserResponse
        {
            public int status { get; set; }
            public string message { get; set; }
        }

        public class UserRequest
        {
            public string id { get; set; }
            public string name { get; set; }
            public string contactNumber { get; set; }
            public string email { get; set; }
            public string boardingPoint { get; set; }
            public string ticketSrlNo { get; set; }
        }
    }
}
