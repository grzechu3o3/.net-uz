using Microsoft.AspNetCore.Mvc;
using Zadanie_06.Services;
using Zadanie_06.Models;

namespace Zadanie_06.Controllers;

public class AdminController : Controller
{
    private readonly NewsService _newsService;
    private const string AdminPassword = "admin123"; // hasło admina

    public AdminController(NewsService newsService)
    {
        _newsService = newsService;
    }

    // Sprawdza czy admin jest zalogowany
    private bool IsLoggedIn => HttpContext.Session.GetString("admin") == "true";

    // GET /Admin/Login
    public IActionResult Login() => View();

    // POST /Admin/Login
    [HttpPost]
    public IActionResult Login(string password)
    {
        if (password == AdminPassword)
        {
            HttpContext.Session.SetString("admin", "true");
            return RedirectToAction("Index");
        }

        ViewBag.Error = "Złe hasło!";
        return View();
    }

    // GET /Admin/Logout
    public IActionResult Logout()
    {
        HttpContext.Session.Remove("admin");
        return RedirectToAction("Login");
    }

    // GET /Admin
    public IActionResult Index()
    {
        if (!IsLoggedIn) return RedirectToAction("Login");
        return View(_newsService.GetAll());
    }

    // POST /Admin/Add
    [HttpPost]
    public IActionResult Add(string title, string content)
    {
        if (!IsLoggedIn) return RedirectToAction("Login");

        if (!string.IsNullOrWhiteSpace(title) && !string.IsNullOrWhiteSpace(content))
        {
            _newsService.Add(new NewsItem { Title = title, Content = content });
        }

        return RedirectToAction("Index");
    }

    // POST /Admin/Delete
    [HttpPost]
    public IActionResult Delete(int id)
    {
        if (!IsLoggedIn) return RedirectToAction("Login");
        _newsService.Delete(id);
        return RedirectToAction("Index");
    }
}