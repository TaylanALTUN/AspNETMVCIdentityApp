﻿using AspNETMvcIdentityApp.Web.CustomValidations;
using AspNETMvcIdentityApp.Web.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AspNETMvcIdentityApp.Web.Extensions
{
    public static class StartupExtensions
    {
        public static void AddIdentityWithExt(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.User.AllowedUserNameCharacters = "abcdefghijklmnoprstuvwxyz1234567890_";

                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;
            }).AddPasswordValidator<PasswordValidator>().AddEntityFrameworkStores<AppDbContext>();
        }
    }
}
