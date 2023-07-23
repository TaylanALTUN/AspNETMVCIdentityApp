﻿using AspNETMvcIdentityApp.Web.Models;
using Microsoft.AspNetCore.Identity;

namespace AspNETMvcIdentityApp.Web.CustomValidations
{
    public class PasswordValidator : IPasswordValidator<AppUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user, string? password)
        {
            var errors = new List<IdentityError>();
            if (password!.ToLower().Contains(user.UserName!.ToLower()))
            {
                errors.Add(new IdentityError() { Code = "PasswordNoContainUserName", Description = "Şifre alanı kullanıcı adı içeremez" });
            }


            if(errors.Any())
            {
                return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
            }

            return Task.FromResult(IdentityResult.Success);

        }
    }
}
