using BusSewa.Helpers;
using BusSewa.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static BusSewa.Model.CommonResponse;
using static BusSewa.Model.UserDetailModel;

namespace BusSewa.Services
{
    public class GetPassengerDetail
    {
        public CommonResponseModel GetUserDetails(UserRequest UR, CredsModel Creds)
        {
            try
            {
                var valSeats = new ValidateData();
                string json = JsonConvert.SerializeObject(
                    new
                    {
                        id = UR.id,
                        name = UR.name,
                        contactNumber = UR.contactNumber,
                        email = UR.email,
                        boardingPoint = UR.boardingPoint,
                        ticketSrlNo = UR.ticketSrlNo,
                    }
                    );

                //UR.id = "ODc4NTY3OjA6MA=="; //model.from
                //UR.name = "Sport"; //model.to
                //UR.contactNumber = "9801255555"; //model.date
                //UR.email = "saurav@gmail.com"; //model.shift
                //UR.boardingPoint = "Balaju(08:00:00 PM)"; //model.shift
                //UR.ticketSrlNo = "2219702-B"; //model.shift

                var URL = Creds.URL + "passengerInfo";

                var checkData = valSeats.UserDetailValidation(UR);
                if (checkData.Code != 0)
                {
                    return checkData;
                }
                else
                {
                    HttpCall GetResponse = new HttpCall();

                    var GetData = GetResponse.HttpPostRequest(json, URL, Creds, "Basic", "POST");
                    var checkCode = JsonConvert.DeserializeObject<UserResponse>(GetData);
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