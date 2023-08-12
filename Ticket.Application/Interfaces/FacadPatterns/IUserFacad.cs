using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Application.Services.Passengers.Queries;
using Ticket.Application.Services.Users.Commands;
using Ticket.Application.Services.Users.Queries;

namespace Ticket.Common.Interfaces.FacadPatterns
{
    public interface IUserFacad
    {
        IRegisterUserService RegisterUserService { get; }
        IAddPassengerService AddPassengerService { get; }
        IEditPassengerService EditPassengerService { get; }
        ILoginUserService LoginUserService { get; }
        ILogoutUserService LogoutUserService { get; }
        IConfirmEmailService ConfirmEmailService { get; }
        ITwoFactorValidService TwoFactorValidService { get; }
        ITwoFactorLoginService TwoFactorLoginService { get; }
        IVerifyPhoneNumberService VerifyPhoneNumberService { get; }
        IUserInfoService UserInfoService { get; }
        IPassengerInfoService PassengerInfoService { get; }
        IPassengersListService PassengersListService { get; }

    }
}
