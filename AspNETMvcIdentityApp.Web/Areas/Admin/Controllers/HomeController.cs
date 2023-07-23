using AspNETMvcIdentityApp.Web.Areas.Admin.Models;
using AspNETMvcIdentityApp.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNETMvcIdentityApp.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public HomeController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> UserList()
        {
            var userlList = await _userManager.Users.ToListAsync();

            var userModelList = userlList.Select(x => new UserViewModel()
            {
                Email = x.Email,
                Id = x.Id,
                Name = x.UserName
            }).ToList();
            return View(userModelList);
        }
    }
}
