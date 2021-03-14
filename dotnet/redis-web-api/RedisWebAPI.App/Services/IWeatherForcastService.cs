using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RedisWebAPI.App.Models;

namespace RedisWebAPI.App.Services
{
    public interface IWeatherForcastService
    {
        Task<IEnumerable<WeatherForecast>> GetWeather(DateTime startDate);
    }
}