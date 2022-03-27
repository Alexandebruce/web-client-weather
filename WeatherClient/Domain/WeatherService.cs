using GrabberService.Models;
using System;
using System.Threading.Tasks;
using WeatherClient.Dao.Interfaces;
using WeatherClient.Domain.Interfaces;

namespace WeatherClient.Domain
{
    class WeatherService : IWeatherService
    {
        private readonly IHttpClient httpClient;
        public WeatherService(IHttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<CityWeather> GetWeather(DateTime targetDay, string city)
        {
            var weather = await httpClient.Get<CityWeather>(string.Empty);

            return null;
        }
    }
}
