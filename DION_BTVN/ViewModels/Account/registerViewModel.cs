using System.ComponentModel.DataAnnotations;

namespace DION_BTVN.ViewModels.Account
{
    public class registerViewModel
    {
        [Required(ErrorMessage = "Tên người dùng là bắt buộc")]
        [StringLength(255, ErrorMessage = "Tên người dùng tối đa dài 255 ký tự", MinimumLength = 2)]
        public string username { get; set; }

        [Required(ErrorMessage = "Mật khẩu là bắt buộc")]
        [StringLength(100, ErrorMessage = "{0} dài từ {2} đến {1} ký tự.", MinimumLength = 6)]
        public string password { get; set; }

        [Required(ErrorMessage = "Email là bắt buộc")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ.")]
        public string email { get; set; }
    }
}
