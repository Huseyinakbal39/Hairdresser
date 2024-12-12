using Hairdresser.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hairdresser.Controllers
{
    public class TeamController : Controller
    {
        DbContext1 dbContext = new DbContext1();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AdminIndex()
        {
            var employees = dbContext.Employees.ToList();
            return View(employees);//yazarlar parametre koy
        }
        public IActionResult AdminTeamAdd()
        {
            return View();
        }

        public IActionResult AdminTeamDelete()
        {
            return View();
        }

        public IActionResult AdminTeamEdit()
        {
            return View();
        }

        public IActionResult AdminTeamDetail(int? id)
        {
            if (id is null)
            {
                TempData["msj"] = "Lütfen verileri düzgün giriniz";
                return RedirectToAction("Index");
            }
            var employees = dbContext.Employees.Find(id);
            if (employees is null)
            {
                TempData["msj"] = "Yazar Bulunamadı";
                return RedirectToAction("Index");
            }

            return View(employees);
        }
    }
}
