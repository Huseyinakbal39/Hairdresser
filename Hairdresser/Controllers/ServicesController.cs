using Microsoft.AspNetCore.Mvc;

namespace Hairdresser.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
