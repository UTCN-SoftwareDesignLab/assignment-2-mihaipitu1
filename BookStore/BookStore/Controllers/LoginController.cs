using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Services.Authentication;
using BookStore.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class LoginController : Controller
    {
        private IAuthenticationService authService;

        public LoginController(IAuthenticationService authService)
        {
            this.authService = authService;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string Username, string Password)
        {
            var user = authService.Login(Username, Password);
            if(user == null)
            {
                return StatusCode(404);
            }
            if(user.GetRole().GetRolename().Equals(Database.Constants.Roles.EMPLOYEE))
            {
                return RedirectToAction("Index", "Shop");
            }
            return RedirectToAction("Index","User");
        }
    }
}