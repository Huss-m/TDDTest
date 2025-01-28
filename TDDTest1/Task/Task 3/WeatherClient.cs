using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TDDTest1.Task.Task_3
{
   public class WeatherClient
    {
        private readonly HttpClient _httpClient;

        public WeatherClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        // Hämtar aktuellt väder för en stad
        public virtual async Task<string> GetCurrentWeatherAsync(string city)
        {
            if (string.IsNullOrWhiteSpace(city))
            {
                throw new ArgumentException("City name cannot be null or empty.");
            }

            try
            {
                // Simulerat API-anrop
                var response = await _httpClient.GetAsync($"https://api.weather.com/v3/weather/{city}");
                response.EnsureSuccessStatusCode(); // Kastar undantag om statusen inte är 2xx
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException ex)
            {
                throw new HttpRequestException($"Failed to fetch weather data for {city}.", ex);
            }
        }
    }
}
