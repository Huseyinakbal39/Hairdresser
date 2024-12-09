using Microsoft.AspNetCore.Mvc;

namespace Hairdresser.Controllers
{
    public class BookOnlineController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
