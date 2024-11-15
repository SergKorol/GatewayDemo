using Microsoft.AspNetCore.Mvc;

namespace GatewayDemo.ForecastApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController(ILogger<WeatherForecastController> logger) : ControllerBase
{
    private static string[] _summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];

    private readonly ILogger<WeatherForecastController> _logger = logger;

    [HttpGet]
    [Route("forecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = _summaries[Random.Shared.Next(_summaries.Length)]
            })
            .ToArray();
    }
    
    [HttpPost]
    [Route("summaries/add")]
    public string[] AddWeatherType([FromBody]WeatherSummaryRequest request)
    {
        var list = _summaries.ToList();
            
        list.Add(request.Summary);

        _summaries = list.ToArray();

        return _summaries;
    }
}