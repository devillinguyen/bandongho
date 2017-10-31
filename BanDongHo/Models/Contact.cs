using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BanDongHo.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [StringLength(255)]
        public string Title { get; set; }
        [StringLength(255)]
        public string Company { get; set; }
        public string Address { get; set; }
        [StringLength(50)]
        public string PhoneNumber { get; set; }
    }
}