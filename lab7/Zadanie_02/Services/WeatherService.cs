using System.Text.Json.Nodes;

namespace Zadanie_02.Services;

public class WeatherService
{
    private readonly HttpClient _client;
    
    // [================KLUCZ DO OPEN WEATHER API================]
    private readonly string _apikey = "7d5a2f5c1b755d7fa7b872e038d5c689";

    public WeatherService(HttpClient client)
    {
        _client = client;
    }

    public async Task<string> GetWeatherForCityAsync(string city)
    {
        var geoResponse = await _client.GetAsync($"geo/1.0/direct?q={city}&limit=1&appid={_apikey}");
        geoResponse.EnsureSuccessStatusCode();

        var locations = await geoResponse.Content.ReadFromJsonAsync<List<CityCoordinatesDto>>();

        if (locations == null || locations.Count == 0)
        {
            return null;
        }

        var lat = locations[0].Lat;
        var lon = locations[0].Lon;

        var weatherResponse = await _client.GetAsync($"data/2.5/weather?lat={lat}&lon={lon}&appid={_apikey}&units=metric");
        weatherResponse.EnsureSuccessStatusCode();

        var weatherJsonString = await weatherResponse.Content.ReadAsStringAsync();
        var weatherJsonNode = JsonNode.Parse(weatherJsonString);
        string correctCityName = locations[0].Name;
        
        if (locations[0].LocalNames != null && locations[0].LocalNames.ContainsKey("pl"))
        {
            correctCityName = locations[0].LocalNames["pl"]; 
        }
        weatherJsonNode["name"] = correctCityName;

        return weatherJsonNode.ToJsonString();
    }

}