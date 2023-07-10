using BusSewa.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static BusSewa.Model.CommonResponse;

namespace BusSewa.Helpers
{
    public class HttpCall
    {
        public string HttpPostRequest(string json, string URL,CredsModel creds, string header_auth, string reqType)
        {
            var request = WebRequest.Create(URL) as HttpWebRequest;
            var username = creds.Username;
            var password = creds.Password;
            var token = string.Empty;

            request.Method = reqType;
            switch (request.Method)
            {
                case "POST":
                    request.Method = "POST";
                    break;
                case "PUT":
                    request.Method = "PUT";
                    break;
                case "DELETE":
                    request.Method = "DELETE";
                    break;
                case "GET":
                    request.Method = "GET";
                    break;
                default:
                    request.Method = "POST";
                    break;
            }

            request.ContentType = "application/json;charset=UTF-8";
            request.Accept = "application/json";
            request.ProtocolVersion = HttpVersion.Version10;
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 5.01; Windows NT 5.0)";

            if (header_auth.ToUpper() == "BASIC")
            {
                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(username + ":" + password);
                var basiccreds = System.Convert.ToBase64String(plainTextBytes);
                request.Headers.Add(HttpRequestHeader.Authorization, "Basic " + basiccreds);

            }
            else if (header_auth.ToUpper() == "BEARER")
            {
                request.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
            }

            string responseString = "";

            try
            {
                if (request.Method == "POST")
                {
                    var dataBytes = Encoding.UTF8.GetBytes(json);
                    request.ContentLength = dataBytes.Length;

                    using (var stream = request.GetRequestStream())
                    {
                        stream.Write(dataBytes, 0, dataBytes.Length);
                    }
                }

                var response = (HttpWebResponse)request.GetResponse();
                responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            }

            catch (WebException wex)
            {
                if (wex.Response != null)
                {
                    using (var errorResponse = (HttpWebResponse)wex.Response)
                    {
                        using (var reader = new StreamReader(errorResponse.GetResponseStream()))
                        {
                            responseString = reader.ReadToEnd();
                        }
                    }
                }
            }
            return responseString;
        }
    }
}