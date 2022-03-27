using GrabberService.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using WeatherClient.Dao.Interfaces;
using WeatherClient.Domain.Interfaces;
using System.Globalization;

namespace WeatherClient.Domain
{
    class WeatherService : IWeatherService
    {
        private readonly IHttpClient httpClient;
        public WeatherService(IHttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<DayWeather> GetWeather(DateTime targetDay, string city)
        {
            var weather = await httpClient.Get<CityWeather>($"date/{targetDay.ToString(@"dd.MM.yyyy", new CultureInfo(@"ru-RU"))}/city/{city}");

            return weather?.WeatherByDays.LastOrDefault(x => x.Date.Day == targetDay.Day) ?? new DayWeather();
        }
    }
}
