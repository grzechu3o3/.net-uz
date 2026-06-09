using Microsoft.AspNetCore.Mvc;
using Zadanie_02.Services;

namespace Zadanie_02.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherController : ControllerBase
{
    private readonly WeatherService _weatherService;

    public WeatherController(WeatherService service)
    {
        _weatherService = service;
    }

    [HttpGet("{city}")]
    public async Task<IActionResult> GetWeather(string city)
    {
        try
        {
            var weatherJson = await _weatherService.GetWeatherForCityAsync(city);
            
            if (weatherJson == null)
            {
                return NotFound(new { message = $"Nie znaleziono miasta: {city}" });
            }

            return Content(weatherJson, "application/json");
        }
        catch (HttpRequestException ex)
        {
            return StatusCode(500, new { message = "Błąd komunikacji z zewnętrznym API", details = ex.Message });
        }
    }
}