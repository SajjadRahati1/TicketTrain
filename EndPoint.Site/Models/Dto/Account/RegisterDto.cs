using System.ComponentModel.DataAnnotations;

namespace EndPoint.Site.Models.Dto.Account
{
    public class RegisterDto
    {
        [Required]
        [Display(Name ="نام")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "نام خانوادی")]
        public string LastName { get; set; }
        [Display(Name ="نام کاربری")]
        public string Username { get; set; }
        [Required]
        [EmailAddress(ErrorMessage ="ایمیل وارد شده معتبر نمیباشد")]
        [Display(Name ="آدرس ایمیل")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(ConfirmPassword), ErrorMessage = "رمز عبور وارد شده با تکرار آن مطابقت ندارد")]
        [Display(Name ="رمز عبور")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Required]
        [Display(Name ="تکرار رمز عبور")]
        public string ConfirmPassword { get; set; }
        [Required]
        [Display(Name ="شماره همراه")]
        [MinLength(11, ErrorMessage = "شماره همراه وارد شده معتبر نمیباشد")]
        public string PhoneNumber { get; set; }

    }
}
