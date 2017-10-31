using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanDongHo.Models
{
    public class Order
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public double Total { get; set; }
        public bool Status { get; set; }
        public DateTime DateTime { get; set; }
        // Foreign OM
        public Customer Customer { get; set; }
    }
}