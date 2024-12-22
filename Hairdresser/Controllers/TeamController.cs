using Hairdresser.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hairdresser.Controllers
{
    public class TeamController : Controller
    {
        //DbContext1 dbContext = new DbContext1();
        //public IActionResult Index()
        //{
        //    var employees = dbContext.Employees.ToList();
        //    return View(employees);//yazarlar parametre koy
        //}

        //public IActionResult AdminIndex()
        //{
        //    var employees = dbContext.Employees.ToList();
        //    return View(employees);//yazarlar parametre koy
        //}
        //public IActionResult AdminTeamAdd()
        //{
        //    return View();
        //}
        //public IActionResult AddEmployee(Employee e)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        dbContext.Employees.Add(e);
        //        //  k.Add(y);
        //        dbContext.SaveChanges();
        //        TempData["msj"] = e.Name + " added to employees";
        //        return RedirectToAction("AdminIndex");
        //    }
        //    TempData["msj"] = "Please enter a valid data";
        //    return RedirectToAction("AdminTeamAdd");
        //}

        //public IActionResult EmployeeDelete(int? id)
        //{
        //    if (id is null)
        //    {
        //        TempData["msj"] = "Lütfen dataları düzgün giriniz";
        //        return RedirectToAction("AdminIndex");
        //    }
        //    var employees = dbContext.Employees.Find(id);
        //    if (employees is null)
        //    {
        //        TempData["msj"] = "Yazar Bulunamadı";
        //        return RedirectToAction("AdminIndex");
        //    }
        //    //var kayit = dbContext.Employees.Include(x => x.Kitaplar).Where(x => x.YazarID == id).ToList();//Randevu varsa burdan kontrol edilecek önce randevu silincek sonra çalışan silinecek.
        //    //if (kayit[0].Kitaplar.Count > 0)
        //    //{
        //    //    TempData["msj"] = "Yazara ait Kitaplar var. Önce Kitapları siliniz";
        //    //    return RedirectToAction("AdminIndex");
        //    //}
        //    dbContext.Employees.Remove(employees);
        //    dbContext.SaveChanges();
        //    TempData["msj"] = employees.Name + " adlı yazar silindi";
        //    return RedirectToAction("AdminIndex");
        //}
        //public IActionResult EmployeeEdit(int? id)
        //{
        //    if (id is null)
        //    {
        //        TempData["msj"] = "Lütfen dataları düzgün giriniz";
        //        return RedirectToAction("AdminIndex");
        //    }
        //    var employee = dbContext.Employees.Find(id);
        //    if (employee is null)
        //    {
        //        TempData["msj"] = "Yazar Bulunamadı";
        //        return RedirectToAction("AdminIndex");
        //    }
        //    return View(employee);
        //}
        //[HttpPost]
        //public IActionResult EmployeeEdit(int? id, Employee e)
        //{
        //    if (id is null)
        //    {
        //        TempData["msj"] = "Lütfen dataları düzgün giriniz";
        //        return RedirectToAction("AdminIndex");
        //    }
        //    if (id != e.Id)
        //    {
        //        TempData["msj"] = "id ler eşleşmiyor";
        //        return RedirectToAction("AdminIndex");
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        dbContext.Employees.Update(e);
        //        dbContext.SaveChanges();
        //        TempData["msj"] = e.Name + "adlı yazara ait güncelleme yapıldı";
        //        return RedirectToAction("AdminIndex");
        //    }
        //    TempData["msj"] = "Güncelleme işlemi başarısız";
        //    return RedirectToAction("AdminIndex");
        //}

        //public IActionResult AdminTeamDetail(int? id)
        //{
        //    if (id is null)
        //    {
        //        TempData["msj"] = "Lütfen verileri düzgün giriniz";
        //        return RedirectToAction("Index");
        //    }
        //    var employees = dbContext.Employees.Find(id);
        //    if (employees is null)
        //    {
        //        TempData["msj"] = "Yazar Bulunamadı";
        //        return RedirectToAction("Index");
        //    }
        //    return View(employees);
        //}
    }
}
