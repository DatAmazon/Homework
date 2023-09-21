using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.DbAccess
{
    public class Order
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public System.DateTime DateTime { get; set; }
    }
}
