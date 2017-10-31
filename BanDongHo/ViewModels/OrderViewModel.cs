using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BanDongHo.ViewModels
{
    public class OrderViewModel
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        [Display(Name = "Tên khách hàng")]
        public string CustomerName { get; set; }
        [Display(Name = "Tổng tiền")]
        public double Total { get; set; }
    }
}