using BusSewa.Helpers;
using BusSewa.Model;
using Newtonsoft.Json;
using System;
using static BusSewa.Model.CommonResponse;
using static BusSewa.Model.RouteModel;

namespace BusSewa.Services
{
    public class GetBusRoutes
    {
        public CommonResponseModel BusRoutes(CredsModel creds)
        {
            try
            {
                var URL = creds.URL + "routes";
                HttpCall GetResponse = new HttpCall();
                string json = null;
                var GetData = GetResponse.HttpPostRequest(json, URL, creds, "Basic", "GET");
                var checkCode = JsonConvert.DeserializeObject<Root>(GetData);
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
            catch (Exception exe)
            {
                if (exe.InnerException != null)
                    exe = exe.InnerException;
                return new CommonResponseModel { Code = ResponseCode.FAILED, Message = "FAILED", Data = "", Error = exe.InnerException };
            }
        }
    }
}
