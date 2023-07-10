using BusSewa.Helpers;
using BusSewa.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using static BusSewa.Model.CancelBooking;
using static BusSewa.Model.CommonResponse;
using static BusSewa.Model.PaymentConfiramtionModel;
using static BusSewa.Model.RefreshModel;
using static BusSewa.Model.TicketBookModel;
using static BusSewa.Model.TicketQuery;
using static BusSewa.Model.TripModel;
using static BusSewa.Model.UserDetailModel;

namespace BusSewa
{
    public class ServiceCall
    {
        public object GetServices(string name, dynamic data)
        {
            if (!string.IsNullOrEmpty(name))
            {
                dynamic response = null;
                GetCreds Values = new GetCreds();
                var Creds = Values.GetValues();

                try
                {
                    switch (name.ToLower())
                    {
                        case "getbusroutes":
                            var myBusRout = new GetBusRoutes();
                            response = myBusRout.BusRoutes(Creds);
                            break;

                        case "refreshapi":
                            var refreshBus = new RefreshApi();
                            var JsonSer = JsonConvert.SerializeObject(data);
                            var deserilized = JsonConvert.DeserializeObject<BusId>(JsonSer);
                            response = refreshBus.RefreshSeatAPI(deserilized, Creds);
                            break;

                        case "gettriplist":
                            var TripList = new GetTripList();
                            var JsonSerList =JsonConvert.SerializeObject(data);
                            var deserilizedList = JsonConvert.DeserializeObject<TripRequest>(JsonSerList);
                            response = TripList.GetTripRoutList(deserilizedList, Creds);
                            break;

                        case "booktrip":
                            var BookTrip = new BookSeat();
                            var JsonSerTrip = JsonConvert.SerializeObject(data);
                            var deserilizedTrip = JsonConvert.DeserializeObject<BookRequest>(JsonSerTrip);
                            response = BookTrip.BookSeats(deserilizedTrip, Creds);
                            break;

                        case "cancelbooktrip":
                            var CancelBookTrip = new BookingCancel();
                            var JsonSerBookTrip = JsonConvert.SerializeObject(data);
                            var deserilizedBookTrip = JsonConvert.DeserializeObject<CancelRequest>(JsonSerBookTrip);
                            response = CancelBookTrip.CancelBooking(deserilizedBookTrip, Creds);
                            break;

                        case "userdetail":
                            var GetUserDetail = new GetPassengerDetail();
                            var JsonSerDetail = JsonConvert.SerializeObject(data);
                            var deserilizedDetail = JsonConvert.DeserializeObject<UserRequest>(JsonSerDetail);
                            response = GetUserDetail.GetUserDetails(deserilizedDetail, Creds);
                            break;

                        case "confirmpmt":
                            var ConfirmPmt = new ConfirmPayment();
                            var JsonSerPmt = JsonConvert.SerializeObject(data);
                            var deserilizedPmt = JsonConvert.DeserializeObject<PaymentRequestModel>(JsonSerPmt);
                            response = ConfirmPmt.ConfirmPmt(deserilizedPmt, Creds);
                            break;

                        case "querycheck":
                            var QueryCheck = new QueryTicket();
                            var JsonSerQCheck = JsonConvert.SerializeObject(data);
                            var deserilizedQCheck = JsonConvert.DeserializeObject<RequestQuery>(JsonSerQCheck);
                            response = QueryCheck.QuerysTicket(deserilizedQCheck, Creds);
                            break;
                    }
                    return response;
                }
                catch (Exception exe)
                {
                    return new CommonResponseModel { Code = ResponseCode.FAILED, Message = "FAILED", Data = null, Error = exe };
                    throw;
                }
            }
            else
            {
                return new CommonResponseModel { Code = ResponseCode.FAILED, Message = "FAILED", Data = null, Error = "Failed to get service name" };
            }
        }
    }
}