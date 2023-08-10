using Net8BlazorAuto.Shared;
using Net8BlazorAuto.Shared.Interfaces;
using System.Net.Http.Json;

namespace Net8BlazorAuto.Client.Services;

public class WeatherService : IWeatherService
{
    private readonly HttpClient httpClient;
    private readonly ILogger<WeatherService> logger;

    public WeatherService(HttpClient httpClient, ILogger<WeatherService> logger)
    {
        this.httpClient = httpClient;
        this.logger = logger;
    }

    public async Task<WeatherForecast[]> GetWeatherforecasts(bool fromServer = true)
    {
        try
        {
            var result = await httpClient.GetFromJsonAsync<WeatherForecast[]>("/api/v1/Weather");
            if (result != null)
            {
                return result;
            }
        }
        catch (Exception ex)
        {
            logger.LogError("failed getting weatherforecasts: {error}", ex.Message);
        }
        return Array.Empty<WeatherForecast>();
    }
}
