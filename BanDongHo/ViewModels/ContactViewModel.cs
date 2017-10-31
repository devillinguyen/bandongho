using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanDongHo.ViewModels
{
    public class ContactViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}