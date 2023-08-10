using Microsoft.AspNetCore.Mvc;
using Net8BlazorAuto.Shared;
using Net8BlazorAuto.Shared.Interfaces;

namespace Net8BlazorAuto.Server.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class WeatherController : ControllerBase
{
    private readonly IWeatherService weatherService;

    public WeatherController(IWeatherService weatherService)
    {
        this.weatherService = weatherService;
    }

    [HttpGet]
    public async Task<ActionResult<WeatherForecast[]>> GetWeatherForecasts()
    {
        return await weatherService.GetWeatherforecasts(false);
    }
}