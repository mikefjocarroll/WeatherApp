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
        string url = $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={apiKey}";
        
        var json = await _httpClient.GetStringAsync(url);
        Console.WriteLine(json);
        Forecast forecast = JsonSerializer.Deserialize<Forecast>(json);
        return $"{json} / City Name: {forecast.name} / Description: {forecast.description} / Temp: {forecast.temp}";
    }
    public double GetFahrenheit(double kelvin)
    {
        return (kelvin - 273.15) * 9 / 5 + 32;
    }

    public double GetCelsius(double kelvin)
    {
        return kelvin - 273.15;
    }

    public class Forecast
    {
        public string name { get; set; }
        public string description { get; set; }
        
        public double temp { get; set; }
        
    }
    
}
