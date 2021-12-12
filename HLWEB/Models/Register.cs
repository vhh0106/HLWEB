namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;
        
    
    public partial class Register
    {
        [Key]
        public long ID { set; get; }

        [StringLength(250)]
        [Display(Name ="Tên đăng nhập")]
        [Required(ErrorMessage = "Bạn cần nhập tên đăng nhập.")]
        
        public string UserName { set; get; }
        [StringLength(250)]
        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Bạn cần nhập mật khẩu.")]
        [MinLength(6, ErrorMessage = "Mật khẩu phải có ít nhất 6 ký tự")]   
        public string Password { set; get; }
        [StringLength(250)]
        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("Password",ErrorMessage ="Xác nhận mật khẩu không đúng")]
        public string ConfirmPassword { set; get; }
        [StringLength(250)]
        [Display(Name = "Họ và tên")]
        [Required(ErrorMessage = "Yêu cầu nhập họ tên.")]
        public string Name { set; get; }
        [StringLength(250)]
        [Display(Name = "Email")]   
        [Required(ErrorMessage = "Bạn cần nhập email.")]
        
        public string Email { set; get; }
       
        [Display(Name = "Địa chỉ")]
        public string Address { set; get; }
        [StringLength(10)]
        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "Bạn cần nhập số điện thoại.")]
        public string PhoneNumber { set; get; }
        
    }
}