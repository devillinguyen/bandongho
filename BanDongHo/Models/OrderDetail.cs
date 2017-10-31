using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanDongHo.Models
{
    public class OrderDetail
    {
        public long Id { get; set; }
        public int ProductId { get; set; }
        public long OrderId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        // Foreign OM
        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}