using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nhan_Xích_Thành_Đồ_án_BE__LTW.Models.ViewModel
{
    public class LoginVM
    {
        [Required]
        [Display(Name = "Tên đăng nhập")]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Mặt khẩu")]
        public string Password { get; set; }
    }
}