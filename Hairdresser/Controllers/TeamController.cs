using Microsoft.AspNetCore.Mvc;

namespace Hairdresser.Controllers
{
    public class TeamController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
