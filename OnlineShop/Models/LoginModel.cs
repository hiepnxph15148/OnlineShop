using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class LoginModel
    {
        [Key]
        [Display(Name="Tên đăng nhập")]
        [Required(ErrorMessage = "Please enter your full name")]
        public string UserName { get; set; }
        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Please enter the full password")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}