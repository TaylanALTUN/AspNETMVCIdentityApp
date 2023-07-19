using Microsoft.AspNetCore.Identity;

namespace AspNETMvcIdentityApp.Web.Models
{
    public class AppUser:IdentityUser
    {
        public string City { get; set; }
    }
}
