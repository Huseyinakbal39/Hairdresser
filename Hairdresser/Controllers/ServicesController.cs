using Hairdresser.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Hairdresser.Controllers
{
    public class ServicesController : Controller
    {
        private readonly DbContext1 dbContext;

        public ServicesController(DbContext1 databaseContext)
        {
            dbContext = databaseContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ManServices()
        {
            var services = dbContext.Services.ToList();
            return View(services);
        }

        public IActionResult WomanServices()
        {
            var services = dbContext.Services.ToList();
            return View(services);
        }
    }
}
