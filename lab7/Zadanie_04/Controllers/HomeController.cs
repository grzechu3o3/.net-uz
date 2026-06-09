using Microsoft.AspNetCore.Mvc;
using Zadanie_04.Models;

namespace Zadanie_04.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View(new UserFormModel());
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Index(UserFormModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        return View("Success", model);
    }
}