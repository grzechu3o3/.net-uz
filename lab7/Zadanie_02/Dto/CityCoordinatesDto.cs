using System.Text.Json.Serialization;
using System.Collections.Generic;

public class CityCoordinatesDto
{
    [JsonPropertyName("lat")]
    public double Lat { get; set; }

    [JsonPropertyName("lon")]
    public double Lon { get; set; }
    
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("local_names")]
    public Dictionary<string, string>? LocalNames { get; set; }
}