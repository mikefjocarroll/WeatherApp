using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace WeatherApp.Logic;

public class WeatherAPIService
{
    private readonly HttpClient _httpClient;
    private readonly string apiKey = "130b4230ee3695358a66932856972be8";

    public WeatherAPIService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GetWeatherAsync(string cityName)
    {
        string outputDescription = "";
        string url = $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={apiKey}";
        
        var json = await _httpClient.GetStringAsync(url);
        Console.WriteLine(json);
        WeatherResponse forecast = JsonSerializer.Deserialize<WeatherResponse>(json);
        return $"City Name: {forecast.name} / Weather Description: {forecast.weather?[0].description}" +
               $"Humidity {forecast.main?.humidity}%";
    }
    public double GetFahrenheit(double kelvin)
    {
        return (kelvin - 273.15) * 9 / 5 + 32;
    }

    public double GetCelsius(double kelvin)
    {
        return kelvin - 273.15;
    }

    public class WeatherResponse
    { 
        public string? name { get; set; }
        public main? main { get; set; }
        public List<weather>? weather { get; set; }
    }

    public class main
    {
        public float temp { get; set; }
        public float humidity { get; set; }
    }
    
    public class weather
    { 
        public string? main {get; set;}
        public string? description { get; set; }
    }
}
