using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HLWEB.Models
{
    public class Login
    {
        [Key]
        [StringLength(250)]
        [Display(Name ="Tên đăng nhập")]
        [Required(ErrorMessage = "Bạn cần nhập tài khoản")]
        public string UserName { get; set; }

        [StringLength(250)]
        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Bạn cần nhập mật khẩu")]
        
        public string Password { get; set; }
        
    }
}