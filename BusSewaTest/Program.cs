using BusSewa;
using BusSewa.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using static BusSewa.Model.TripModel;

namespace BusSewaTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            var requestType = "CancelBookTrip";
            ServiceCall SC = new ServiceCall();

            TestDynamicModel DummyTest = new TestDynamicModel()
            {
                to = "Pokhara",
                from = "Kathmandu",
                date = "2023-07-3",
                shift = "Day",
                id = "ODc0NDU2OjA6MA==",
                ticketSrlNo = "2219711-B"
            };
            dynamic data = DummyTest;
            var MySc = SC.GetServices(requestType, data);
            Console.WriteLine("Result : " + JsonConvert.SerializeObject(MySc));
            Console.ReadLine();
        }
    }
}
