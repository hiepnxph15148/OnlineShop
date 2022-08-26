using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class RegisterModel
    {
        [Key]
        public long Id { get; set; }
        [Display(Name ="Tên đăng nhập")]
        [Required(ErrorMessage ="Yêu cầu nhập đầy đủ thông tin")]
   
        public string UserName { get; set; }
        [Display(Name = "Mật khẩu")]
        [StringLength(20,MinimumLength =6,ErrorMessage ="Độ dài Password ít nhất trên 6 kí tự")]   
        
        public string Password { get; set; }
        [Display(Name = "Họ Tên")]
        [Required(ErrorMessage = "Yêu cầu nhập đầy đủ thông tin")]
        public string Name { get; set; }
        [Display(Name = "Điện thoại")]
        [Required(ErrorMessage = "Yêu cầu nhập đầy đủ thông tin")]
        public string Phone { get; set; }
        [Display(Name = "Xác nhận mật khẩu")]
        [Required(ErrorMessage = "Yêu cầu nhập đầy đủ thông tin")]
        [Compare("Password",ErrorMessage ="Xác nhận mật khẩu không đúng")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Yêu cầu nhập đầy đủ thông tin")]
        public string Address { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Yêu cầu nhập đầy đủ thông tin")]
        public string Email { get; set; }

    }
}