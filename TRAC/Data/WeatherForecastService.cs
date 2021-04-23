using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace TRAC.Data
{
    public class WeatherForecastService
    {
        private readonly ILogger<WeatherForecastService> _logger;
        public WeatherForecastService(ILogger<WeatherForecastService> logger)
        {
            _logger = logger;
        }
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        {
            _logger.LogError($"GetForecastAsync {startDate.ToShortDateString()}");
            _logger.LogWarning($"GetForecastAsync {startDate.ToShortDateString()}");
            _logger.LogDebug($"GetForecastAsync {startDate.ToShortDateString()}");
            _logger.LogInformation($"GetForecastAsync {startDate.ToShortDateString()}");
            var rng = new Random();
            return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            }).ToArray());
        }
    }
}
