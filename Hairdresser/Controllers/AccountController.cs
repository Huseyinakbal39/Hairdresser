using Hairdresser.Entities;
using Hairdresser.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Hairdresser.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly DbContext1 _databaseContext;

        public AccountController(DbContext1 databaseContext)
        {
            _databaseContext = databaseContext;
        }
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = _databaseContext.Users.SingleOrDefault(x => x.email == model.Username && x.Password == model.Password);
                if (user != null)
                {
                    if(user.Locked)
                    {
                        ModelState.AddModelError(nameof(model.Username), "User is locked");
                        return View(model);
                    }

                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
                    claims.Add(new Claim(ClaimTypes.Name, user.UserSurname ?? string.Empty));
                    claims.Add(new Claim(ClaimTypes.Role, user.Role));
                    claims.Add(new Claim("Username", user.Username));

                    ClaimsIdentity identity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    ModelState.AddModelError("", "Username or password is incorrect");
                }
            }
            return View(model);
        }
        //[AllowAnonymous]
        //public IActionResult Register()
        //{
        //    return View();
        //}
        //[AllowAnonymous]
        //[HttpPost]
        //public IActionResult Register(RegisterViewModel model)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        if(_databaseContext.Users.Any(x => x.Username.ToLower() == model.Username.ToLower()))
        //        {
        //            ModelState.AddModelError(nameof(model.Username), "User is already exists");
        //            View(model);
        //        }
        //        User user = new()
        //        {
        //            Username = model.Username,
        //            Password = model.Password,
        //        };
        //        _databaseContext.Users.Add(user);
        //        int affectedRowCount = _databaseContext.SaveChanges();

        //        if(affectedRowCount == 0)
        //        {
        //            ModelState.AddModelError("", "User can not be added");
        //        }
        //        else
        //        {
        //            return RedirectToAction(nameof(Login));
        //        }
        //    }
        //    return View(model);
        //}
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Register(RegisterVM registerVM)
        {
            if (ModelState.IsValid)
            {

                User user = new User
                {
                    Username = registerVM.firstName,
                    UserSurname = registerVM.lastName,
                    email = registerVM.email,
                    phone = registerVM.phone,
                    Password = registerVM.password,
                    Gender = registerVM.Gender
                };
                _databaseContext.Users.Add(user);
                _databaseContext.SaveChanges();
                return View(nameof(Login));
            }

            return View(registerVM);
        }

        public IActionResult Profile()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var idInt = Convert.ToInt32(id);
            User user = _databaseContext.Users.Find(idInt);
            return View(user);
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync((CookieAuthenticationDefaults.AuthenticationScheme));
            return RedirectToAction(nameof(Login));
        }

        public IActionResult MyAppointments()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var idInt = Convert.ToInt32(id);
            List<Randevu> randevu = _databaseContext.Appointments.Where(x => x.UserID == idInt).ToList();
            List<Randevularım> randevularım = new List<Randevularım>();
            foreach (var item in randevu)
            {
                randevularım.Add(new Randevularım
                {
                    CalisanAdi = _databaseContext.Calisan.Where(x => x.Id == item.calisanId).Select(x => x.Name).FirstOrDefault(),
                    IslemAdi = _databaseContext.Services.Where(x => x.Id == item.ServiceId).Select(x => x.Name).FirstOrDefault(),
                    RandevuTarihi = item.AppointmentDate
                }
                    ) ;
            }
            
         
            return View(randevularım);
        }
    }
}
