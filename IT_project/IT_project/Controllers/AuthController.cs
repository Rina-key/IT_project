using IT_project.Models;
using IT_project.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;

namespace IT_project.Controllers
{

    public class AuthController : Controller
    {
        private readonly UserService _userService;
        public AuthController(UserService userService) 
        {
            _userService = userService;
        }
        [HttpPost]
        public async Task<IActionResult> signIn([FromBody] User user)
        {
            bool chUser = _userService.checkUsers(user);

            if (chUser)
            {
                await SignInUserAsync(user);
                return Json(new { success = true, redirectUrl = Url.Action("Index", "Home") });
            }
            return Json(new { success = false, error = "Неверные данные" });
        }

        [HttpGet]
        //[HttpGet("login")]
        public IActionResult login()
        {
            if (User?.Identity?.IsAuthenticated == true)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
            
        }

        [HttpGet]
        public IActionResult register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult reg([FromBody] User user) 
        { 
            bool nUser = _userService.checkUserEmail(user.Email);
            if (!nUser) 
            {
                _userService.addUser(user);
                return Json(new { success = true, redirectUrl = Url.Action("login", "Auth") });
            }
            return Json(new { success = false, error = "Неверные данные" });
        }


        private async Task SignInUserAsync(User user)
        {
            try
            {
                var claims = new List<Claim>
                {
                    new(ClaimTypes.Name, user.username!),
                };
                var clainIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.UtcNow.AddDays(30)
                };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(clainIdentity), authProperties);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Authorization), "Authentication");
        }
    }
}
