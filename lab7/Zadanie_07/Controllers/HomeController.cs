using Microsoft.AspNetCore.Mvc;
using Zadanie_07.Models;

namespace FileUpload.Controllers;

public class HomeController : Controller
{
    private readonly IWebHostEnvironment _env;
    private readonly ILogger<HomeController> _logger;

    public HomeController(IWebHostEnvironment env, ILogger<HomeController> logger)
    {
        _env = env;
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View(new UploadViewModel());
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    [RequestSizeLimit(104857600)] // 100 MB
    public async Task<IActionResult> Index(UploadViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var uploadFolder = Path.Combine(_env.WebRootPath, "uploads");
        Directory.CreateDirectory(uploadFolder); 

        var uploadedFiles = new List<string>();

        foreach (var file in model.Files)
        {
            if (file.Length == 0) continue;

            var safeFileName = $"{DateTime.Now:yyyyMMdd_HHmmss}_{Path.GetFileName(file.FileName)}";
            var filePath = Path.Combine(uploadFolder, safeFileName);

            using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);

            uploadedFiles.Add(safeFileName);
            _logger.LogInformation("Wgrano plik: {FileName}, rozmiar: {Size} B", safeFileName, file.Length);
        }

        if (uploadedFiles.Count == 0)
        {
            ModelState.AddModelError("", "Żaden plik nie został wgrany");
            return View(model);
        }

        TempData["UploadedFiles"] = System.Text.Json.JsonSerializer.Serialize(uploadedFiles);
        return RedirectToAction("Success");
    }
    
    public IActionResult Success()
    {
        var json = TempData["UploadedFiles"] as string;

        var files = string.IsNullOrEmpty(json)
            ? new List<string>()
            : System.Text.Json.JsonSerializer.Deserialize<List<string>>(json)!;

        return View(files);
    }
    
    public IActionResult Files()
    {
        var uploadFolder = Path.Combine(_env.WebRootPath, "uploads");
        Directory.CreateDirectory(uploadFolder);

        var files = Directory.GetFiles(uploadFolder)
            .Select(f => new FileInfo(f))
            .OrderByDescending(f => f.CreationTime)
            .ToList();

        return View(files);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteFile(string fileName)
    {
        var uploadFolder = Path.Combine(_env.WebRootPath, "uploads");
        var filePath = Path.Combine(uploadFolder, Path.GetFileName(fileName)); 

        if (System.IO.File.Exists(filePath))
            System.IO.File.Delete(filePath);

        return RedirectToAction("Files");
    }
}