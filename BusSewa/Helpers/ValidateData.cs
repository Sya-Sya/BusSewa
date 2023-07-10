using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusSewa.Model.CancelBooking;
using static BusSewa.Model.CommonResponse;
using static BusSewa.Model.PaymentConfiramtionModel;
using static BusSewa.Model.TicketBookModel;
using static BusSewa.Model.TicketQuery;
using static BusSewa.Model.TripModel;
using static BusSewa.Model.UserDetailModel;

namespace BusSewa.Helpers
{
    public class ValidateData
    {
        public CommonResponseModel BookingValidation(BookRequest param)
        {
            Dictionary<string, string> errorlist = new Dictionary<string, string>();

            if (param.id == null || param.id == "")
            {
                errorlist.Add("101", "ID is required");
            }
            if (param.seat == null)
            {
                errorlist.Add("102", "Seats is required");
            }
            if (errorlist.Count > 0)
            {
                return new CommonResponseModel { Code = ResponseCode.FAILED, Message = "FAILED", Error = errorlist, Data = "" };
            }
            return new CommonResponseModel { Code = ResponseCode.SUCCESS, Message = "Success", Error = "", Data = "" };
        }

        public CommonResponseModel ConfirmpaymentValidation(PaymentRequestModel param)
        {
            Dictionary<string, string> errorlist = new Dictionary<string, string>();

            if (param.id == null || param.id == "")
            {
                errorlist.Add("101", "ID is required");
            }
            if (param.refId == null || param.refId == "")
            {
                errorlist.Add("103", "Refrence Id is required");
            }
            //if (!string.IsNullOrEmpty(param.ticketSrlNo))
            //{
            //    errorlist.Add("104", "Ticket serical number is required");
            //}
            if (errorlist.Count > 0)
            {
                return new CommonResponseModel { Code = ResponseCode.FAILED, Message = "FAILED", Error = errorlist, Data = "" };
            }
            return new CommonResponseModel { Code = ResponseCode.SUCCESS, Message = "Success", Error = "", Data = "" };
        }

        public CommonResponseModel TripValidation(TripRequest param)
        {
            Dictionary<string, string> errorlist = new Dictionary<string, string>();

            if (param.from == null || param.from == "")
            {
                errorlist.Add("101", "From is required");
            }
            if (param.to == null)
            {
                errorlist.Add("102", "To is required");
            }
            if (param.date == null)
            {
                errorlist.Add("103", "Date is required");
            }
            if (param.shift == null)
            {
                errorlist.Add("104", "Shift is required");
            }
            if (errorlist.Count > 0)
            {
                return new CommonResponseModel { Code = ResponseCode.FAILED, Message = "FAILED", Error = errorlist, Data = "" };
            }
            return new CommonResponseModel { Code = ResponseCode.SUCCESS, Message = "Success", Error = "", Data = "" };
        }

        public CommonResponseModel CancelBookingValidation(CancelRequest param)
        {
            Dictionary<string, string> errorlist = new Dictionary<string, string>();

            if (param.id == null || param.id == "")
            {
                errorlist.Add("101", "ID is required");
            }
            if (param.ticketSrlNo == null || param.ticketSrlNo == "")
            {
                errorlist.Add("102", "Ticket number is required");
            }
            if (errorlist.Count > 0)
            {
                return new CommonResponseModel { Code = ResponseCode.FAILED, Message = "FAILED", Error = errorlist, Data = "" };
            }
            return new CommonResponseModel { Code = ResponseCode.SUCCESS, Message = "Success", Error = "", Data = "" };
        }

        public CommonResponseModel QueryTicketValidation(RequestQuery param)
        {
            Dictionary<string, string> errorlist = new Dictionary<string, string>();

            if (param.id == null || param.id == "")
            {
                errorlist.Add("101", "ID is required");
            }
            if (param.ticketSrlNo == null || param.ticketSrlNo == "")
            {
                errorlist.Add("102", "Ticket number is required");
            }
            if (errorlist.Count > 0)
            {
                return new CommonResponseModel { Code = ResponseCode.FAILED, Message = "FAILED", Error = errorlist, Data = "" };
            }
            return new CommonResponseModel { Code = ResponseCode.SUCCESS, Message = "Success", Error = "", Data = "" };
        }

        public CommonResponseModel UserDetailValidation(UserRequest param)
        {
            Dictionary<string, string> errorlist = new Dictionary<string, string>();

            if (param.id == null || param.id == "")
            {
                errorlist.Add("101", "ID is required");
            }
            if (param.ticketSrlNo == null || param.ticketSrlNo == "")
            {
                errorlist.Add("102", "Ticket number is required");
            }
            if (param.boardingPoint == null || param.boardingPoint == "")
            {
                errorlist.Add("102", "Boarding Point is required");
            }
            if (param.name == null || param.name == "")
            {
                errorlist.Add("102", "Name is required");
            }
            if (param.email == null || param.email == "")
            {
                errorlist.Add("102", "Email is required");
            }
            if (param.contactNumber == null || param.contactNumber == "")
            {
                errorlist.Add("102", "Contact number is required");
            }
            if (errorlist.Count > 0)
            {
                return new CommonResponseModel { Code = ResponseCode.FAILED, Message = "FAILED", Error = errorlist, Data = "" };
            }
            return new CommonResponseModel { Code = ResponseCode.SUCCESS, Message = "Success", Error = "", Data = "" };
        }
    }
}
