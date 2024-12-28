using Hairdresser.Entities;
using Hairdresser.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace Hairdresser.Controllers
{
    public class BookOnlineController : Controller
    {
        private readonly DbContext1 dbContext;

        public BookOnlineController(DbContext1 databaseContext)
        {
            dbContext = databaseContext;
        }

        public IActionResult Index()
        {
            ViewBag.Calisanlar = dbContext.Calisan
                .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                .ToList();

            ViewBag.Servisler = dbContext.Services
                .Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Name })
                .ToList();
            return View();
        }
        //public IActionResult Create()
        //{
            

        //    return View();
        //}

        // POST: Create Appointment
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Randevu randevu)
        {
            if (ModelState.IsValid)
            {
                var idInt = User.FindFirstValue(ClaimTypes.NameIdentifier);
                randevu.UserID = Convert.ToInt32(idInt);
                dbContext.Appointments.Add(randevu);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
                //return RedirectToAction("Index"); // Randevuların listelendiği sayfaya yönlendirme
            }

            // Tekrar dropdown verilerini View'e gönder
            ViewBag.Calisanlar = dbContext.Calisan
                .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                .ToList();

            ViewBag.Servisler = dbContext.Services
                .Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Name })
                .ToList();
            
            return View("Index");
        }  

        public IActionResult MyAppointments()
        {
            return View();

        }

    }
}
