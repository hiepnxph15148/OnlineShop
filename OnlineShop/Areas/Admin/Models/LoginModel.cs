using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please enter your full name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please enter the full password")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }

    }
}