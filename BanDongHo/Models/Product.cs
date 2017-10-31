using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BanDongHo.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(255)]
        public string Image { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        public bool Hot { get; set; }
        public bool Male { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public int CategoryId { get; set; }
        // Foreign OM
        public Category Category { get; set; }
    }
}