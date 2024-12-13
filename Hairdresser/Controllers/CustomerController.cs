using Microsoft.AspNetCore.Mvc;

namespace Hairdresser.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        

    }
}
