using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusSewa.Model
{
    public class CommonResponse
    {
        public enum ResponseCode
        {
            SUCCESS,
            FAILED,
            UNKNOWN,
            PENDING
        }

        public class CommonResponseModel
        {
            public ResponseCode Code { get; set; }
            public string Message { get; set; }
            public object Data { get; set; }
            public object Error { get; set; }
        }

        public class Response
        {
            public string status { get; set; }
            public string statusCode { get; set; }
        }

        public class ErrorRoot
        {
            public int status { get; set; }
            public int errorCode { get; set; }
            public string message { get; set; }
        }

        public class ConfigVal
        {
            public string Url { get; set; }
            public string password { get; set; }
            public string Username { get; set; }
        }
    }
}