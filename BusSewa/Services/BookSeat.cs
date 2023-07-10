using BusSewa.Helpers;
using BusSewa.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusSewa.Model.CommonResponse;
using static BusSewa.Model.TicketBookModel;

namespace BusSewa.Services
{
    public class BookSeat
    {
        public CommonResponseModel BookSeats(BookRequest BR, CredsModel Creds)
        {
            try
            {
                var valSeats = new ValidateData();
                string[] arrSeats = { BR.seat.ToString() };
                string json = JsonConvert.SerializeObject(
                    new
                    {
                        id = BR.id,
                        seat = arrSeats
                    }
                    );

                var URL = Creds.URL + "book";

                //BR.id = "ODc4NTY3OjA6MA==";
                //BR.seat = new List<string> { "1", "2" };

                var checkData = valSeats.BookingValidation(BR);
                if (checkData.Code != 0)
                {
                    return checkData;
                }
                else
                {
                    HttpCall GetResponse = new HttpCall();

                    var GetData = GetResponse.HttpPostRequest(json, URL, Creds, "Basic", "POST");
                    var checkCode = JsonConvert.DeserializeObject<BookRoot>(GetData);
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
