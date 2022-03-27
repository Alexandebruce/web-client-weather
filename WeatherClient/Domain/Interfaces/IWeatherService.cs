using GrabberService.Models;
using System;
using System.Threading.Tasks;

namespace WeatherClient.Domain.Interfaces
{
    public interface IWeatherService
    {
        Task<DayWeather> GetWeather(DateTime targetDay, string city);
    }
}
