using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusSewa.Model
{
    public class RouteModel
    {
        public class Root
        {
            public int status { get; set; }
            public List<string> routes { get; set; }
        }
    }
}