using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusSewa.Model
{
    public class TripModel
    {
        public class TripRequest
        {
            public string from { get; set;}
            public string to { get; set;}
            public string date  { get; set;}
            public string shift { get; set;}
        }

        public class Base
        {
            public int status { get; set; }
            public List<Trip> trips { get; set; }
        }

        public class SeatLayout
        {
            public string displayName { get; set; }
            public string bookingStatus { get; set; }
        }

        public class Trip
        {
            public string id { get; set; }
            public string @operator { get; set; }
            public string date { get; set; }
            public string faceImage { get; set; }
            public string busNo { get; set; }
            public string busType { get; set; }
            public string departureTime { get; set; }
            public string shift { get; set; }
            public int journeyHour { get; set; }
            public string dateEn { get; set; }
            public bool lockStatus { get; set; }
            public bool multiPrice { get; set; }
            public int inputTypeCode { get; set; }
            public int noOfColumn { get; set; }
            public double rating { get; set; }
            public List<object> imgList { get; set; }
            public List<string> amenities { get; set; }
            public List<string> detailImage { get; set; }
            public double ticketPrice { get; set; }
            public List<object> passengerDetail { get; set; }
            public List<SeatLayout> seatLayout { get; set; }
            public string operator_name { get; set; }
        }
    }
}