using BusSewa.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusSewa.Model.CommonResponse;

namespace BusSewa.Helpers
{
    public class GetCreds
    { 
        public CredsModel GetValues()
        {
            JObject O1 = JObject.Parse(File.ReadAllText(@"D:\MyThing\.NET\BusSewa\BusSewa\Creds.json"));
            var ser = JsonConvert.SerializeObject(O1);
            var myJsonData = JsonConvert.DeserializeObject<CredsModel>(ser);

            return myJsonData;
        }
    }
}