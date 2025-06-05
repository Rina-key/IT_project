using IT_project.Models;
using IT_project.Services;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult signIn([FromBody] User user)
        {
            bool chUser = _userService.checkUsers(user);
            if (chUser)
            {
                return Json(new { success = true, redirectUrl = Url.Action("Index", "Home") });
            }
            return Json(new { success = false, error = "Неверные данные" });
        }

        [HttpGet]
        //[HttpGet("login")]
        public IActionResult login()
        {
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
    }
}
