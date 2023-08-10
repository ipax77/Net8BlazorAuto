using Net8BlazorAuto.Shared;
using Net8BlazorAuto.Shared.Interfaces;

namespace Net8BlazorAuto.Services;

public class WeatherService : IWeatherService
{
    private readonly ILogger<WeatherService> logger;

    public WeatherService(ILogger<WeatherService> logger)
    {
        this.logger = logger;
    }

    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public async Task<WeatherForecast[]> GetWeatherforecasts(bool fromServer = true)
    {
        logger.LogInformation("getting weather from {sender} - {date}", fromServer ? "Server" : "Client", DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"));

        await Task.Delay(1000);
        var startDate = DateOnly.FromDateTime(DateTime.Now);
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = startDate.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        }).ToArray();
    }
}