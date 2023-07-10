using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusSewa.Model
{
    public class PaymentConfiramtionModel
    {
        public class PaymentRequestModel
        {
            public string id { get; set; }
            public string refId { get; set; }
            public string ticketSrlNo { get; set; }
        }

        public class PaymentResponseModel
        {
            public int status { get; set; }
            public List<string> contactInfo { get; set; }
            public string message { get; set; }
            public string BusNo { get; set; }
        }
    }
}