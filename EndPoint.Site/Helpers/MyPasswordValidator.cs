﻿using Microsoft.AspNetCore.Identity;
using Ticket.Domain.Entities.Users;

namespace EndPoint.Site.Helpers
{
    public class MyPasswordValidator : IPasswordValidator<User>
    {
        //لیست 10.000 پسورد غیر امن رو در لینک زیر میتونید بدست بیارید
        //https://en.wikipedia.org/wiki/Wikipedia:10,000_most_common_passwords


        List<string> CommonPassword = new List<string>()
        {
            "123456","zxcV@34567","password","qwerty","123456789"
        };
        public Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user, string password)
        {
            if (CommonPassword.Contains(password))
            {
                var result = IdentityResult.Failed(new IdentityError
                {
                    Code = "CommonPassword",
                    Description = "پسورد شما قابل شناسایی توسط ربات های هکر است! لطفا یک پسورد قوی انتخاب کنید",
                });
                return Task.FromResult(result);
            }

            return Task.FromResult(IdentityResult.Success);
        }
    }
}
