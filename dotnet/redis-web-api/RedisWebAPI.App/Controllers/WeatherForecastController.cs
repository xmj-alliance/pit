using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Microsoft.Extensions.Caching.Distributed;

using RedisWebAPI.App.Extensions;
using RedisWebAPI.App.Models;
using RedisWebAPI.App.Services;


namespace RedisWebAPI.App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IDistributedCache _cache;
        private readonly IWeatherForcastService _weatherForcastService;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            IDistributedCache cache,
            IWeatherForcastService weatherForcastService
        )
        {
            _logger = logger;
            _cache = cache;

            _weatherForcastService = weatherForcastService;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            IEnumerable<WeatherForecast> forecastResults = null;
            string recordKey = $"WeatherForecast_{DateTime.Now.ToString("yyyyMMdd_hhmm")}";
            forecastResults = await _cache.GetRecord<IEnumerable<WeatherForecast>>(recordKey);

            if (forecastResults is null)
            {
                forecastResults = await _weatherForcastService.GetWeather(DateTime.Now);
                _logger.LogInformation($"Loading from API at {DateTime.Now}");
                await _cache.SetRecord<IEnumerable<WeatherForecast>>(recordKey, forecastResults);
            }
            else
            {
                _logger.LogInformation($"Loading from CACHE at {DateTime.Now}");
            }

            return forecastResults;
        }
    }
}
