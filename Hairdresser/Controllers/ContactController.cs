using Microsoft.AspNetCore.Mvc;

namespace Hairdresser.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
