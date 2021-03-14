using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RedisWebAPI.App.Models;

namespace RedisWebAPI.App.Services
{
    public class WeatherForcastService: IWeatherForcastService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public async Task<IEnumerable<WeatherForecast>> GetWeather(DateTime startDate)
        {
            var rng = new Random();
            // Mock DB processing time
            await Task.Delay(2000);
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}