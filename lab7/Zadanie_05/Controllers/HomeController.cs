using Zadanie_05.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Zadanie_05.Models;

namespace Zadanie_05.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new Kalkulator());
        }

        [HttpPost]
        public IActionResult Index(Kalkulator model)
        {
            switch (model.Operacja)
            {
                case "+":
                    model.Wynik = model.Liczba1 + model.Liczba2;
                    break;
                case "-":
                    model.Wynik = model.Liczba1 - model.Liczba2;
                    break;
                case "*":
                    model.Wynik = model.Liczba1 * model.Liczba2;
                    break;
                case "/":
                    if (model.Liczba2 != 0)
                    {
                        model.Wynik = model.Liczba1 / model.Liczba2;
                    }
                    else
                    {
                        ModelState.AddModelError("Liczba2", "Nie można dzielić przez zero!");
                    }
                    break;
            }

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}