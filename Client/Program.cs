using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Net8BlazorAuto.Client.Services;
using Net8BlazorAuto.Shared.Interfaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<IWeatherService, WeatherService>();

await builder.Build().RunAsync();
