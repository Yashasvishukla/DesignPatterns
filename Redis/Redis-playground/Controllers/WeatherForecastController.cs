using System.Collections;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace Redis_playground.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly HttpClient _client;
    private readonly IDatabase _redis;
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(HttpClient client, IConnectionMultiplexer connectionMultiplexer, ILogger<WeatherForecastController> logger)
    {
        _client = client;
        _client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("weatherCachingApp", "1.0"));
        _redis = connectionMultiplexer.GetDatabase();
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IActionResult> Get([FromQuery] double latitude, [FromQuery] double longitude)
    {
        var watch = Stopwatch.StartNew();
        // Check first in the cache
        var keyName = $"forecast:{latitude},{longitude}";
        var response = await _redis.StringGetAsync(keyName);
        
        
        if (string.IsNullOrEmpty(response))
        {
            // cache miss
            response = await GetForecast(latitude, longitude);
            
            // Set the cache
            var setResponse = await _redis.StringSetAsync(keyName, response, expiry: TimeSpan.FromSeconds(3600));
            if (!setResponse) _logger.LogError("Failed to cache the response");
        }
        
        // var forecast = JsonSerializer.Deserialize<IEnumerable<WeatherForecast>>(response!);
        watch.Stop();
        var result = new ForecastResult(watch.ElapsedMilliseconds, response!);
        return Ok(result);
    }

    private async Task<string?> GetForecast(double latitude, double longitude)
    {
        var pointsRequestQuery = $"https://api.weather.gov/points/{latitude},{longitude}";
        var result = await _client.GetFromJsonAsync<JsonObject>(pointsRequestQuery);
        var gridX = result?["properties"]?["relativeLocation"]?["properties"]?["city"]?.ToString();
        var gridY = result?["properties"]?["relativeLocation"]?["properties"]?["state"]?.ToString();
        var gridId = result?["properties"]?["gridId"]?.ToString();
        
        /*
        This URL is down at this point in time
        var forecastQuery = $"https://api.weather.gov/gridpoints/{gridId}/{gridX},{gridY}/forecast";
        var forecastResponse = await _client.GetFromJsonAsync<JsonObject>(forecastQuery);
        var periodJson = forecastResponse?["properties"]?["periods"]?.ToString();
        */
        
        return $"{gridId} - {gridX} - {gridY}";
    }
}
