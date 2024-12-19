using Microsoft.AspNetCore.Mvc;

namespace Hairdresser.Controllers
{
    public class AccountController : Controller
    {

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Register(RegisterViewModel model)
        {
            return View();
        }
    }
}
