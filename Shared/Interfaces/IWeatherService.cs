namespace Net8BlazorAuto.Shared.Interfaces;

public interface IWeatherService
{
    Task<WeatherForecast[]> GetWeatherforecasts(bool fromServer = true);
}