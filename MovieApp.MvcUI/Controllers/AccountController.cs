using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Business.Abstract;
using MovieApp.Data.Entity;
using MovieApp.Data.ViewModel;
using MovieApp.MvcUI.Entities;

namespace MovieApp.MvcUI.Controllers
{
    public class AccountController : Controller
    {
        //private readonly IUserService _userService;
        private readonly Microsoft.AspNetCore.Identity.UserManager<CustomIdentityUser> _userManager;

        public AccountController(Microsoft.AspNetCore.Identity.UserManager<CustomIdentityUser> userManager)
        {
            //_userService = userService;
            _userManager = userManager;
        }

        

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>  Login(LoginViewModel mmodel)
        {
                var user = new CustomIdentityUser { UserName ="mehmet0", Email = "mehmetabic@gmail.com" };
                var result = await _userManager.CreateAsync(user,"Mehmet01.");
               return LocalRedirect("");
        }
    }
}