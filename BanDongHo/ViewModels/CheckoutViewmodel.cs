using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BanDongHo.Models;

namespace BanDongHo.ViewModels
{
    public class CheckoutViewmodel
    {
        [Display(Name = "Họ tên")]
        [Required(ErrorMessage = "Chưa nhập họ tên")]
        [StringLength(50, ErrorMessage = "Tên không hợp lệ, quá dài")]
        public string Name { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "Email không hợp lệ")]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Chưa nhập email")]
        [StringLength(50, ErrorMessage = "Email không hợp lệ, quá dài")]
        public string Email { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "Chưa nhập số điện thoại")]
        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Số điện thoại không hợp lệ")]
        [RegularExpression("^[0-9]{9,11}$", ErrorMessage = "Số điện thoại không hợp lệ")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Địa chỉ giao hàng")]
        [Required(ErrorMessage = "Chưa nhập địa chỉ giao hàng")]
        [StringLength(255, ErrorMessage = "Địa chỉ không hợp lệ")]
        public string Address { get; set; }
    }
}