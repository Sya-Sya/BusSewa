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
using static BusSewa.Model.TripModel;

namespace BusSewa.Services
{
    public class GetTripList
    {
        public CommonResponseModel GetTripRoutList(TripRequest model, CredsModel Creds)
        {
            //model.from = "kathmandu"; //model.from
            //model.to = "pokhara"; //model.to
            //model.date = "2023-07-3"; //model.date
            //model.shift = "day"; //model.shift

            try
            {
                var valSeats = new ValidateData();
                string json = JsonConvert.SerializeObject(
                    new
                    {
                        from = model.from,
                        to = model.to,
                        date = model.date,
                        shift = model.shift
                    }
                    );
                var URL = Creds.URL + "trips";

                var checkData = valSeats.TripValidation(model);
                if (checkData.Code != 0)
                {
                    return checkData;
                }
                else
                {
                    HttpCall GetResponse = new HttpCall();

                    var GetData = GetResponse.HttpPostRequest(json, URL, Creds, "Basic", "POST");
                    var checkCode = JsonConvert.DeserializeObject<Base>(GetData);
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