using BusSewa.Helpers;
using BusSewa.Model;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusSewa.Model.CommonResponse;
using static BusSewa.Model.PaymentConfiramtionModel;

namespace BusSewa.Services
{
    public class ConfirmPayment
    {
        public CommonResponseModel ConfirmPmt(PaymentRequestModel model, CredsModel Creds)
        {
            try
            {
                var valSeats = new ValidateData();
                string json = JsonConvert.SerializeObject(
                    new
                    {
                        id = model.id,
                        refId = model.refId, //Unique Identifier given by US
                        ticketSrlNo = model.ticketSrlNo
                    }
                    );

                var URL = Creds.URL + "paymentConfirm";

                //model.id = "ODc5NzYwOjgxMTkyMjU6MA=="; //model.id
                //model.refId = "Sya_Sya-102"; //model.refId
                //model.ticketSrlNo = "2219706-B"; //model.ticketSrlNo
                var checkData = valSeats.ConfirmpaymentValidation(model);
                if (checkData.Code != 0)
                {
                    return checkData;
                }
                else
                {
                    HttpCall GetResponse = new HttpCall();

                    var GetData = GetResponse.HttpPostRequest(json, URL, Creds, "Basic", "POST");
                    var checkCode = JsonConvert.DeserializeObject<PaymentResponseModel>(GetData);
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