using Hairdresser.Entities;
using Hairdresser.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hairdresser.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly DbContext1 dbContext;

        public AdminController(DbContext1 databaseContext)
        {
            dbContext = databaseContext;
        }
        public IActionResult Index()
        {
            var employees = dbContext.Calisan.ToList();
            return View(employees);//yazarlar parametre koy
        }

        public IActionResult Team()
        {
            var employees = dbContext.Calisan.ToList();
            return View(employees);//yazarlar parametre koy
        }
        public IActionResult AdminTeamAdd()
        {
            return View();
        }
        public IActionResult AddEmployee(Calisan e)
        {
            if (ModelState.IsValid)
            {
                if (dbContext.Users.Any(x => x.Username.ToLower() == e.Name.ToLower()))
                {
                    ModelState.AddModelError(nameof(e.Name), "User is already exists");
                    View(e);
                }
                User user = new()
                {
                    Username = e.Name,
                    Password = e.Password,
                    Role = "employee"
                };
                dbContext.Users.Add(user);
                dbContext.Calisan.Add(e);
                int affectedRowCount = dbContext.SaveChanges();

                if (affectedRowCount == 0)
                {
                    ModelState.AddModelError("", "User can not be added");
                }
                else
                {
                    return RedirectToAction(nameof(Team));
                }
            }
            TempData["msj"] = "Please enter a valid data";
            return RedirectToAction("AdminTeamAdd");
        }

        public IActionResult EmployeeDelete(int? id)
        {
            if (id is null)
            {
                TempData["msj"] = "Please enter valid data";
                return RedirectToAction("Team");
            }
            var employees = dbContext.Calisan.Find(id);
            if (employees is null)
            {
                TempData["msj"] = "Employee could not find";
                return RedirectToAction("Team");
            }
            User user = dbContext.Users.SingleOrDefault(x => x.Username.ToLower() == employees.Name.ToLower() && x.Password == employees.Password);
            dbContext.Users.Remove(user);
            dbContext.Calisan.Remove(employees);
            dbContext.SaveChanges();
            TempData["msj"] = employees.Name + " named employee deleted.";
            return RedirectToAction("Team");
        }
        public IActionResult EmployeeEdit(int? id)
        {
            if (id is null)
            {
                TempData["msj"] = "Please enter valid data";
                return RedirectToAction("EmployeeEdit");
            }
            var employee = dbContext.Calisan.Find(id);
            if (employee is null)
            {
                TempData["msj"] = "Employee could not find";
                return RedirectToAction("EmployeeEdit");
            }
            return View(employee);
        }
        [HttpPost]
        public IActionResult EmployeeEdit(int? id, Calisan e)
        {
            if (id is null)
            {
                TempData["msj"] = "Please enter valid data";
                return RedirectToAction("EmployeeEdit");
            }
            if (id != e.Id)
            {
                TempData["msj"] = "Id does not exist.";
                return RedirectToAction("EmployeeEdit");
            }

            if (ModelState.IsValid)
            {
                User user = dbContext.Users.SingleOrDefault(x => x.Username.ToLower() == e.Name.ToLower() && x.Password == e.Password);

                dbContext.Users.Update(user);
                dbContext.Calisan.Update(e);
                
                dbContext.SaveChanges();
                TempData["msj"] = e.Name + " named employee updated.";
                return RedirectToAction("EmployeeEdit");
            }
            TempData["msj"] = "Update failed!";
            return RedirectToAction("EmployeeEdit");
        }

        public IActionResult AdminTeamDetail(int? id)
        {
            if (id is null)
            {
                TempData["msj"] = "Please enter valid data";
                return RedirectToAction("Team");
            }
            var employees = dbContext.Calisan.Find(id);
            if (employees is null)
            {
                TempData["msj"] = "Employee could not find";
                return RedirectToAction("Team");
            }
            return View(employees);
        }
    }
}
