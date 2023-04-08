using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Application.Services.Users.Commands;

namespace Ticket.Common.Interfaces.FacadPatterns
{
    public interface IUserFacad
    {
        IRegisterUserService RegisterUserService { get; }
        ILoginUserService LoginUserService { get; }
        ILogoutUserService LogoutUserService { get; }
    }
}
