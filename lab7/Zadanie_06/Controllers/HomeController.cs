using Microsoft.AspNetCore.Mvc;
using Zadanie_06.Services;

namespace Zadanie_06.Controllers;

public class HomeController : Controller
{
    private readonly NewsService _newsService;

    public HomeController(NewsService newsService)
    {
        _newsService = newsService;
    }

    public IActionResult Index()
    {
        var news = _newsService.GetAll();
        return View(news);
    }
}