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
                dbContext.SaveChanges();
                e.User = user;
                e.UserId = user.Id;
                user.Calisan = e;
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
            var user = dbContext.Users.Find(employees.UserId);
            if (employees is null)
            {
                TempData["msj"] = "Employee could not find";
                return RedirectToAction("Team");
            }
            if(user is null)
            {
                TempData["msj"] = "User could not find";
                return RedirectToAction("Team");
            }
            //User user = dbContext.Users.SingleOrDefault(x => x.Username.ToLower() == employees.Name.ToLower() && x.Password == employees.Password);
            dbContext.Users.Remove(user);
            dbContext.Calisan.Remove(employees);
            dbContext.SaveChanges();
            TempData["msj"] = employees.Name + " named employee deleted.";
            return RedirectToAction("Team");
        }

        public void HepsiniSil()
        {
            var employee = dbContext.Calisan.ToList();
            dbContext.Calisan.RemoveRange(employee);
            dbContext.SaveChanges();
            var users = dbContext.Users.ToList();
            dbContext.Users.RemoveRange(users);
            dbContext.SaveChanges();
        }
        public IActionResult GetMembers()
        {
            List<Calisan> memberListDB = dbContext.Calisan.ToList();
            List<Calisan> memberList = new List<Calisan>();

            foreach (Calisan Member in memberListDB)
            {
                memberList.Add(new Calisan
                {
                    Id = Member.Id,
                    Name = Member.Name,
                    Surname = Member.Surname,
                    Salary = Member.Salary,
                    Position = Member.Position,
                    Email = Member.Email,
                    Password = Member.Password,
                    User = Member.User,
                    UserId = Member.UserId,
                    PhoneNumber = Member.PhoneNumber
                });
            }
            return View(memberList);
        }
        public IActionResult EmployeeEdit(int? id)
        {
            if(id is null)
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
            if (employee.UserId is null)
            {
                TempData["msj"] = "Please enter valid data";
                return RedirectToAction("EmployeeEdit");
            }
            var user = dbContext.Users.Find(employee.UserId);
            dbContext.Users.Remove(user);
            dbContext.SaveChanges();
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
                User user = new()
                {
                    Username = e.Name,
                    Password = e.Password,
                    Role = e.Position
                };
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
                e.User = user;
                e.UserId = user.Id;
                user.Calisan = e;
                dbContext.Calisan.Update(e);
                
                dbContext.SaveChanges();
                TempData["msj"] = e.Name + " named employee updated.";
                return RedirectToAction("Team");
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

        public IActionResult Service()
        {
            var services = dbContext.Services.ToList();
            return View(services);
        }
        public IActionResult AdminServiceAdd()
        {
            return View();
        }
        public IActionResult AddService(Servis s)
        {
            if (ModelState.IsValid)
            {
                if (dbContext.Services.Any(x => x.Name.ToLower() == s.Name.ToLower()))
                {
                    ModelState.AddModelError(nameof(s.Name), "Service already exists");
                    View(s);
                }
                dbContext.Services.Add(s);
                int affectedRowCount = dbContext.SaveChanges();

                if (affectedRowCount == 0)
                {
                    ModelState.AddModelError("", "User can not be added");
                }
                else
                {
                    return RedirectToAction(nameof(Service));
                }
            }
            TempData["msj"] = "Please enter a valid data";
            return RedirectToAction("AdminServiceAdd");
        }
        public IActionResult DeleteService(int? id)
        {
            if (id is null)
            {
                TempData["msj"] = "Please enter valid data";
                return RedirectToAction("Service");
            }
            var service = dbContext.Services.Find(id);
            if (service is null)
            {
                TempData["msj"] = "Employee could not find";
                return RedirectToAction("Team");
            }
            dbContext.Services.Remove(service);
            dbContext.SaveChanges();
            TempData["msj"] = service.Name + " named service deleted.";
            return RedirectToAction("Service");
        }
        public IActionResult EditService(int? id)
        {
            if (id is null)
            {
                TempData["msj"] = "Please enter valid data";
                return RedirectToAction("EditService");
            }
            var service = dbContext.Services.Find(id);
            if (service is null)
            {
                TempData["msj"] = "Employee could not find";
                return RedirectToAction("EditService");
            }
            return View(service);
        }
        [HttpPost]
        public IActionResult EditService(int? id,Servis s)
        {
            if (id is null)
            {
                TempData["msj"] = "Please enter valid data";
                return RedirectToAction("EditService");
            }
            if (id != s.Id)
            {
                TempData["msj"] = "Id does not exist.";
                return RedirectToAction("EditService");
            }

            if (ModelState.IsValid)
            {
                dbContext.Services.Update(s);
                dbContext.SaveChanges();
                TempData["msj"] = s.Name + " named employee updated.";
                return RedirectToAction("Service");
            }
            TempData["msj"] = "Update failed!";
            return RedirectToAction("EditService");
        }

    }
}
