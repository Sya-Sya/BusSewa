using BusSewa.Helpers;
using BusSewa.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusSewa.Model.CancelBooking;
using static BusSewa.Model.CommonResponse;

namespace BusSewa.Services
{
    public class BookingCancel
    {
        public CommonResponseModel CancelBooking(CancelRequest CR, CredsModel Creds)
        {
            try
            {
                var valSeats = new ValidateData();
                string json = JsonConvert.SerializeObject(
                    new
                    {
                        id = CR.id,
                        ticketSrlNo = CR.ticketSrlNo
                    }
                    );

                var URL = Creds.URL + "cancelQueue";

                //CR.id = "asd";
                //CR.ticketSrlNo = "as";
                var checkData = valSeats.CancelBookingValidation(CR);
                if (checkData.Code != 0)
                {
                    return checkData;
                }
                else
                {
                    HttpCall GetResponse = new HttpCall();

                    var GetData = GetResponse.HttpPostRequest(json, URL, Creds, "Basic", "POST");
                    var checkCode = JsonConvert.DeserializeObject<CancelTrip>(GetData);
                    if (checkCode.status == 1)
                    {
                        return new CommonResponseModel { Code = ResponseCode.SUCCESS, Message = "SUCCESS", Data = checkCode, Error = "" };
                    }
                    else if (checkCode.status == 2 || checkCode.status == 3 || checkCode.status == 4)
                    {
                        var error2 = JsonConvert.DeserializeObject<ErrorRoot>(GetData);
                        return new CommonResponseModel { Code = ResponseCode.FAILED, Message = "FAILED", Data = null, Error = error2 };
                    }
                    else
                    {
                        var error = JsonConvert.DeserializeObject<ErrorRoot>(GetData);
                        return new CommonResponseModel { Code = ResponseCode.PENDING, Message = "PENDING", Data = "", Error = error };
                    }
                }
            }
            catch (Exception exe)
            {
                if (exe.InnerException != null)
                    exe = exe.InnerException;
                return new CommonResponseModel { Code = ResponseCode.FAILED, Message = "FAILED", Data = "", Error = exe.InnerException };
            }
        }
    }
}