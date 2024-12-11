using Hairdresser.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hairdresser.Controllers
{
    public class LoginController : Controller
    {
        DbContext1 dbContext = new DbContext1();
        public IActionResult Index()
        {
            return View();
        }

        // Login İşlemini Yap
        [HttpPost]
        public IActionResult Login(UserModel user)
        {
            // Basit bir kullanıcı doğrulama
            if (user.Username == "g211210069@sakarya.edu.tr" && user.Password == "sau")
            {
                // Başarılı giriş
                TempData["Message"] = "Giriş başarılı!";
                return RedirectToAction("Welcome");
            }

            // Hatalı giriş
            ViewBag.ErrorMessage = "Kullanıcı adı veya şifre hatalı.";
            return RedirectToAction("Index");
        }

        // Hoşgeldiniz Sayfası
        public IActionResult Welcome()
        {
            return View();
        }

        public IActionResult Team()
        {
            var employees = dbContext.Employees.ToList();
            return View(employees);//yazarlar parametre koy
            
        }
        
        public IActionResult TeamAdd()
        {
            return View();
        }

        public IActionResult TeamDelete()
        {
            return View();
        }

        public IActionResult TeamEdit()
        {
            return View();
        }

        public IActionResult TeamDetail()
        {
            return View();
        }
    }
}
