using System;
using System.ComponentModel.DataAnnotations;

namespace TEDU.Web.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Bạn phải nhập tài khoản")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập mật khẩu")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập xác nhận mật khẩu")]
        [Compare("Password", ErrorMessage = "Xác nhận mật khẩu không đúng.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập địa chỉ email")]
        [EmailAddress(ErrorMessage = "Địa chỉ email không đúng định dạng.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập họ tên")]
        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

    }
}