using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Ticket.Application.Interfaces.Contexts;
using Ticket.Application.Interfaces.Services;
using Ticket.Common.Dto;
using Ticket.Common.Security;
using Ticket.Domain.Entities.Financial;
using Ticket.Domain.Entities.Users;

namespace Ticket.Application.Services.Users.Commands
{
    public interface IRegisterUserService : IPublicService<RequestRegisterUserDto, ResultRegisterUserDto>
    {

    }

    public class RegisterUserService : IRegisterUserService
    {
        private readonly IDbContext _context;
        private readonly UserManager<User> _userManager;

        public RegisterUserService(IDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<ResultDto<ResultRegisterUserDto>> Execute(RequestRegisterUserDto request)
        {
            try
            {
                #region چک کردن مقادیر ورودی
                //چون در کلاس Dto مقادیر چک شده است نیاز به چک در اینجا نداریم
                /* if (string.IsNullOrWhiteSpace(request.Email))
                 {
                     return new ResultDto<ResultRegisterUserDto>()
                     {
                         Data = new ResultRegisterUserDto()
                         {
                             UserId = 0,
                         },
                         IsSuccess = false,
                         Message = "پست الکترونیک را وارد نمایید"
                     };
                 }

                 if (string.IsNullOrWhiteSpace(request.FirstName))
                 {
                     return new ResultDto<ResultRegisterUserDto>()
                     {
                         Data = new ResultRegisterUserDto()
                         {
                             UserId = 0,
                         },
                         IsSuccess = false,
                         Message = "نام را وارد نمایید"
                     };
                 }
                 if (string.IsNullOrWhiteSpace(request.Password))
                 {
                     return new ResultDto<ResultRegisterUserDto>()
                     {
                         Data = new ResultRegisterUserDto()
                         {
                             UserId = 0,
                         },
                         IsSuccess = false,
                         Message = "رمز عبور را وارد نمایید"
                     };
                 }
                 if (request.Password != request.ConfirmPassword)
                 {
                     return new ResultDto<ResultRegisterUserDto>()
                     {
                         Data = new ResultRegisterUserDto()
                         {
                             UserId = 0,
                         },
                         IsSuccess = false,
                         Message = "رمز عبور و تکرار آن برابر نیست"
                     };
                 }
                 string emailRegex = @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[A-Z0-9.-]+\.[A-Z]{2,}$";

                 var match = Regex.Match(request.Email, emailRegex, RegexOptions.IgnoreCase);
                 if (!match.Success)
                 {
                     return new ResultDto<ResultRegisterUserDto>()
                     {
                         Data = new ResultRegisterUserDto()
                         {
                             UserId = 0,
                         },
                         IsSuccess = false,
                         Message = "ایمیل خودرا به درستی وارد نمایید"
                     };
                 }*/

                #endregion


                /* var passwordHasher = new PasswordHasher();
                 var hashedPassword = passwordHasher.HashPassword(request.Password);
                 */
                Person person = new Person()
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    EmailAddress = request.Email,
                    PhoneNumber = request.PhoneNumber,
                    BirthDate = DateTime.MinValue,
                    Gender = Domain.Enums.Gender.Man,
                    IsRemoved = false,
                    NationalCode = "",
                    RemoveTime = null
                };
                Wallet wallet = new Wallet()
                {
                    Balance = 0
                };
                _context.People.Add(person);
                _context.Wallets.Add(wallet);
               
                User user = new User()
                {
                    UserName = request.Username,
                    Person = person,
                    Email = request.Email,
                    Wallet = wallet,
                    PhoneNumber = request.PhoneNumber
                    //PasswordHash = hashedPassword
                };
                
                var result = await _userManager.CreateAsync(user, request.Password);

                if (result.Succeeded)
                {
                    //var ress=await _context.SaveChangesAsync();
                    var token = _userManager.GenerateEmailConfirmationTokenAsync(user).Result;


                    return new ResultDto<ResultRegisterUserDto>()
                    {
                        Data = new ResultRegisterUserDto()
                        {
                            UserId = user.Id,
                            Token = token
                        },
                        IsSuccess = true,
                        Message = "ثبت نام کاربر انجام شد",
                    };
                }
                else if (result.Errors.Any())
                {
                    string errorMessages = "";
                    foreach (var error in result.Errors)
                    {
                        errorMessages += error.Description + Environment.NewLine;
                        //ثبت در لاگ ها
                    }
                    return new ResultDto<ResultRegisterUserDto>()
                    {

                        IsSuccess = false,
                        Message = "مشکلی در ثبت نام کاربر به وجود آمده :" + Environment.NewLine + errorMessages,
                    };
                }

                return new ResultDto<ResultRegisterUserDto>()
                {

                    IsSuccess = false,
                    Message = "خطای ناشناخته",
                };

            }
            catch (Exception e)
            {
                //ثبت در لاگ ها
                string errorMessages = e.Message;
                return new ResultDto<ResultRegisterUserDto>()
                {
                    Data = new ResultRegisterUserDto()
                    {
                        UserId = 0,
                    },
                    IsSuccess = false,
                    Message = "ثبت نام انجام نشد !"
                };
            }
        }
    }
    public class RequestRegisterUserDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(ConfirmPassword), ErrorMessage = "رمز عبور وارد شده با تکرار آن مطابقت ندارد")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string ConfirmPassword { get; set; }
        [Required]
        [MinLength(11,ErrorMessage ="شماره همراه وارد شده معتبر نمیباشد")]
        public string PhoneNumber { get; set; }
    }


    public class ResultRegisterUserDto
    {
        public long UserId { get; set; }
        public string Token { get; set; }
    }


}
