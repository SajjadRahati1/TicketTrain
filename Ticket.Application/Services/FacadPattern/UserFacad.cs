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
using Ticket.Application.Services.Users.Queries;
using Ticket.Application.Services.Passengers.Queries;

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

        #region IAddPassengerService

        private IAddPassengerService _addPassenger;
        public IAddPassengerService AddPassengerService
        {
            get
            {
                return _addPassenger = _addPassenger ?? new AddPassengerService(_context);
            }
        }

        #endregion
        
        #region IEditPassengerService

        private IEditPassengerService _editPassenger;
        public IEditPassengerService EditPassengerService
        {
            get
            {
                return _editPassenger = _editPassenger ?? new EditPassengerService(_context);
            }
        }

        #endregion
        
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

        #region IConfirmEmailService

        private IConfirmEmailService _confirmEmail;
        public IConfirmEmailService ConfirmEmailService
        {
            get
            {
                return _confirmEmail = _confirmEmail ?? new ConfirmEmailService(_context,_userManager);
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

        #region IPassengerInfoService

        private IPassengerInfoService _passengerInfo;
        public IPassengerInfoService PassengerInfoService
        {
            get
            {
                return _passengerInfo = _passengerInfo ?? new PassengerInfoService(_context);
            }
        }
        #endregion

        #region IPassengersListService

        private IPassengersListService _passengersList;
        public IPassengersListService PassengersListService
        {
            get
            {
                return _passengersList = _passengersList ?? new PassengersListService(_context);
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

        #region ITwoFactorValidService
        private ITwoFactorValidService _twoFactorValid;
        public ITwoFactorValidService TwoFactorValidService
        {
            get
            {
                return _twoFactorValid = _twoFactorValid ?? new TwoFactorValidService(_context, _userManager);
            }
        }

        #endregion

        #region IVerifyPhoneNumberService
        private IVerifyPhoneNumberService _verifyPhoneNumber;
        public IVerifyPhoneNumberService VerifyPhoneNumberService
        {
            get
            {
                return _verifyPhoneNumber = _verifyPhoneNumber ?? new VerifyPhoneNumberService( _userManager);
            }
        }

        #endregion

        #region ITwoFactorLoginService
        private ITwoFactorLoginService _twoFactorLogin;
        public ITwoFactorLoginService TwoFactorLoginService
        {
            get
            {
                return _twoFactorLogin = _twoFactorLogin ?? new TwoFactorLoginService(_context, _signInManager);
            }
        }

        #endregion

        #region IUserInfoService
        private IUserInfoService _userInfo;
        public IUserInfoService UserInfoService
        {
            get
            {
                return _userInfo = _userInfo ?? new UserInfoService(_context,_userManager);
            }
        }

        #endregion
    }
}
