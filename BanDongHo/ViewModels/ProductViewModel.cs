using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BanDongHo.Models;

namespace BanDongHo.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Tên sản shẩm")]
        [Required(ErrorMessage = "Chưa nhập tên sản phẩm")]
        public string Name { get; set; }
        [Display(Name = "Ảnh mẫu")]
        [Required(ErrorMessage = "Chưa nhập đường dẫn ảnh")]
        public string Image { get; set; }
        [Display(Name = "Mô tả")]
        [Required(ErrorMessage = "Chưa nhập mô tả")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Chưa nhập giá sản phẩm")]
        [MinPrice(20000, ErrorMessage = "Phải nhập giá từ 20.000 trở lên")]
        public string Price { get; set; }
        [Display(Name = "Nổi Bật")]
        public bool Hot { get; set; }
        [Display(Name = "Nam")]
        public bool Male { get; set; }
        public DateTime Date { get; set; }
        [Display(Name = "Loại sản phẩm")]
        [Required(ErrorMessage = "Chưa chọn loại sản phẩm")]
        public int CategoryId { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        // Foreign OM
        public Category Category { get; set; }
    }
}