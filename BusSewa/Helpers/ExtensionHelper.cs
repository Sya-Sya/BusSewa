using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusSewa.Helpers
{
    public static class ExtensionMethods
    {
        public static T StringToModel<T>(this string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static T DynamicObjectToModel<T>(dynamic obj)
        {
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(obj));
        }
    }
}