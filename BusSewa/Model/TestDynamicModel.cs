using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusSewa.Model
{
    public class TestDynamicModel
    {
        public string from { get; set; }
        public string to { get; set; }
        public string date { get; set; }
        public string shift { get; set; }
        public string id { get; set; }
        public string ticketSrlNo { get; set; }
        public List<string> seat { get; set; }
    }
}
