using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BanDongHo.Models
{
    public class About
    {
        public int Id { get; set; }
        [StringLength(255)]
        public string Title { get; set; }
        public string Content { get; set; }
    }
}