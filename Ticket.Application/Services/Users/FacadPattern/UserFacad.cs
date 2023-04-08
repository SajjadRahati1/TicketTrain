using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Application.Interfaces.Contexts;
using Ticket.Application.Services.Users.Commands;
using Ticket.Common.Interfaces.FacadPatterns;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Ticket.Domain.Entities.Users;

namespace Ticket.Application.Services.Users.FacadPattern
{
    public class UserFacad :IUserFacad
    {
        private readonly IDbContext _context;
        private readonly IHostingEnvironment _environment;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public UserFacad(IDbContext context, IHostingEnvironment hostingEnvironment, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _context = context;
            _environment = hostingEnvironment;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        #region IRegisterUserService

        private IRegisterUserService _registerUser;
        public IRegisterUserService RegisterUserService
        {
            get
            {
                return _registerUser = _registerUser ?? new RegisterUserService(_context, _userManager);
            }
        }

        #endregion

        #region ILoginUserService

        private ILoginUserService _loginUser;
        public ILoginUserService LoginUserService
        {
            get
            {
                return _loginUser = _loginUser ?? new LoginUser(_userManager, _signInManager);
            }
        }
        #endregion

        #region ILogoutUserService

        private ILogoutUserService _logoutUser;
        public ILogoutUserService LogoutUserService
        {
            get
            {
                return _logoutUser = _logoutUser ?? new LogoutUser(_signInManager);
            }
        }
        #endregion

    }
}
