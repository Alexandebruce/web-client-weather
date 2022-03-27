using GrabberService.Models;
using System;
using System.Threading.Tasks;

namespace WeatherClient.Domain.Interfaces
{
    public interface IWeatherService
    {
        Task<CityWeather> GetWeather(DateTime targetDay, string city);
    }
}
