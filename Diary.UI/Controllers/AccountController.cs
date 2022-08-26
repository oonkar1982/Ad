using Diary.UI.DataContext;
using Diary.UI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Diary.UI.Controllers
{
    public class AccountController : Controller
    {

        private readonly ApplicationDbContext _context;

        public string ReturnUrl { get; set; }

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async  Task<ActionResult> Login(LoginModel login, string returnUrl = null)
        {

            returnUrl ??= Url.Content("~/");

            if (ModelState.IsValid)
            {
                var user = _context.ApplicationUsers.Where(f => f.Email == login.Email && f.Password == login.Password).FirstOrDefault();
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Invalid Email or Password");

                }

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Email),
                    new Claim("Roles", user.Role.ToString()),
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

               await   HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        principal,
                        new AuthenticationProperties { IsPersistent = true });

                return LocalRedirect(returnUrl);
            }
            return View();
        }
        public async Task Logout(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            ReturnUrl = returnUrl;
        }

        public async Task<ActionResult> Profile( string  email)
        {


            var user = await _context.ApplicationUsers.Where(x => x.Email.ToLower().Equals(email.ToLower())).FirstOrDefaultAsync(); 

            return View(user);
        }
    }
}
