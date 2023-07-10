using BusSewa.Helpers;
using BusSewa.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using static BusSewa.Model.CommonResponse;
using static BusSewa.Model.TicketQuery;

namespace BusSewa.Services
{
    public class QueryTicket
    {
        public CommonResponseModel QuerysTicket(RequestQuery SQ, CredsModel Creds)
        {
            try
            {
                var valSeats = new ValidateData();
                string json = JsonConvert.SerializeObject(
                    new
                    {
                        id = SQ.id,
                        ticketSrlNo = SQ.ticketSrlNo
                    }
                    );

                var URL = Creds.URL + "queryTicket";

                //SQ.id = "asd";
                //SQ.ticketSrlNo = "as";
                var checkData = valSeats.QueryTicketValidation(SQ);
                if (checkData.Code != 0)
                {
                    return checkData;
                }
                else
                {
                    HttpCall GetResponse = new HttpCall();

                    var GetData = GetResponse.HttpPostRequest(json, URL, Creds, "Basic", "POST");
                    var checkCode = JsonConvert.DeserializeObject<SuccessQuery>(GetData);
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