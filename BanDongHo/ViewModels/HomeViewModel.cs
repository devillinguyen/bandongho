using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BanDongHo.Models;

namespace BanDongHo.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        // Layout Menu
        public IEnumerable<Category> Categories { get; set; }
    }
}