using System.Text.Json;
using Zadanie_06.Models;

namespace Zadanie_06.Services;

public class NewsService
{
    private readonly string _filePath;

    public NewsService(IWebHostEnvironment env)
    {
        _filePath = Path.Combine(env.ContentRootPath, "data", "news.json");
        Directory.CreateDirectory(Path.GetDirectoryName(_filePath)!);
    }

    public List<NewsItem> GetAll()
    {
        if (!File.Exists(_filePath)) return new List<NewsItem>();

        var json = File.ReadAllText(_filePath);
        return JsonSerializer.Deserialize<List<NewsItem>>(json) ?? new List<NewsItem>();
    }

    public void Add(NewsItem item)
    {
        var news = GetAll();
        item.Id = news.Count > 0 ? news.Max(n => n.Id) + 1 : 1;
        news.Insert(0, item); 
        Save(news);
    }

    public void Delete(int id)
    {
        var news = GetAll();
        news.RemoveAll(n => n.Id == id);
        Save(news);
    }

    private void Save(List<NewsItem> news)
    {
        var json = JsonSerializer.Serialize(news, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_filePath, json);
    }
}