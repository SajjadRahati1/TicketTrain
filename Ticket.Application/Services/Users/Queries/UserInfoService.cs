using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Ticket.Application.Interfaces.Contexts;
using Ticket.Application.Interfaces.Services;
using Ticket.Common;
using Ticket.Common.Dto;
using Ticket.Domain.Entities.Users;

namespace Ticket.Application.Services.Users.Queries
{
    public interface IUserInfoService : IPublicService<string, ResultUserInfoDto>
    {

    }
    
    public class UserInfoService : IUserInfoService
    {

        private readonly IDbContext _context;
        private readonly UserManager<User> _userManager;
        public UserInfoService(IDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<ResultDto<ResultUserInfoDto>> Execute(string request)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(request);
                if (user == null)
                {
                    return new ResultDto<ResultUserInfoDto>()
                    {
                        IsSuccess = false,
                        Message = "کاربر یافت نشد",
                        MessageType = MessageType.Error
                    };
                }
                var res = await _context.Users.Where(u => u.Id == user.Id)
                 .Include(u => u.Person)
                 .Include(u => u.Wallet)
                 .Select(u => new ResultUserInfoDto()
                 {
                     Name = u.Person.FirstName + " " + u.Person.LastName,
                     BrithDate = u.Person.BirthDate.Value.ToShamsi(),
                     EmailAddress = u.Person.EmailAddress,
                     EmailVerified = u.EmailConfirmed,
                     Money = u.Wallet.Balance,
                     NationalCode = u.Person.NationalCode,
                     PhoneNumber = u.PhoneNumber,
                     PhoneNumberVerified = u.PhoneNumberConfirmed,
                     Username = u.UserName
                 }).FirstOrDefaultAsync();
                if (res != null)
                {
                    return new ResultDto<ResultUserInfoDto>()
                    {
                        IsSuccess = true,
                        Data = res
                    };
                }
                return new ResultDto<ResultUserInfoDto>()
                {
                    IsSuccess = false,
                    Message = "کاربر یافت نشد",
                    MessageType = MessageType.Error
                };
            }
            catch (Exception ex)
            {
                return new ResultDto<ResultUserInfoDto>()
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    MessageType = MessageType.BadRequest
                };
            }
            
        }
    }
    public class ResultUserInfoDto
    {
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Money { get; set; }
        public bool PhoneNumberVerified { get; set; }
        public string EmailAddress { get; set; }
        public bool EmailVerified { get; set; }

        public string Name { get; set; }
        public string NationalCode { get; set; }
        public string BrithDate { get; set; }
    }
}
