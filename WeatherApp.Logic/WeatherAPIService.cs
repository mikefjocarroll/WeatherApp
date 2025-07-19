namespace WeatherApp.Logic;

public class WeatherAPIService
{
    public string GetWeather()
    {
        return "You've called Get Weather";
    }
    public double GetFahrenheit(double kelvin)
    {
        return (kelvin - 273.15) * 9 / 5 + 32;
    }

    public double GetCelsius(double kelvin)
    {
        return kelvin - 273.15;
    }
}
