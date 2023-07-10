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
using static BusSewa.Model.RefreshModel;

namespace BusSewa.Services
{
    public class RefreshApi
    {
        public CommonResponseModel RefreshSeatAPI(BusId model, CredsModel Creds)
        {
            try
            {
                //string staticID = "ODc0NDU2OjA6MA==";
                var URL = Creds.URL + "refresh/" + model.id;
                HttpCall GetResponse = new HttpCall();
                string json = null;
                var GetData = GetResponse.HttpPostRequest(json, URL, Creds, "Basic", "GET");
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