using System.ComponentModel.DataAnnotations;

namespace EndPoint.Site.Models.Dto.Account
{
    public class LoginDto
    {
        [Required]
        [Display(Name ="نام کاربری")]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="رمز عبور")]
        public string Password { get; set; }

        /// <summary>
        /// لاگین با ایمیل
        /// </summary>
        public bool IsEmailAddress { get; set; } = false;

        /// <summary>
        /// مرا به خاطر بسپار
        /// </summary>
        [Display(Name = "مرا به خاطر داشته باش")]
        public bool IsPersistent { get; set; } = false;

        public string ReturnUrl { get; set; }
    }
}
