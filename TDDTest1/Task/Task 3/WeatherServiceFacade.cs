using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDTest1.Task.Task_3
{
    public class WeatherServiceFacade
    {
        private readonly WeatherClient _weatherClient;

        public WeatherServiceFacade(WeatherClient weatherClient)
        {
            _weatherClient = weatherClient ?? throw new ArgumentNullException(nameof(weatherClient));
        }

        public async Task<string> GetWeather(string city)
        {
            if (string.IsNullOrWhiteSpace(city))
            {
                throw new ArgumentException("City name cannot be null or empty.");
            }

            return await _weatherClient.GetCurrentWeatherAsync(city);
        }
    }
}
