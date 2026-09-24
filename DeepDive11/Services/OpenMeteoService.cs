using DeepDive11.Models;
using System.Text.Json;

namespace DeepDive11.Services
{
    public class OpenMeteoService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public OpenMeteoService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<OpenMeteoLocation?> GetLocationAsync(string location)
        {
            var client = _httpClientFactory.CreateClient("OpenMeteoGeocoding");

            string url = $"v1/search?name={location}&count=1&countryCode=DK";

            HttpResponseMessage response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();

            OpenMeteoLocationResponse? result =
                JsonSerializer.Deserialize<OpenMeteoLocationResponse>(json);

            return result?.Results?.FirstOrDefault();
        }
        public async Task<OpenMeteoWeatherResponse?> GetWeatherAsync(
         double latitude,
           double longitude)
        {
            var client = _httpClientFactory.CreateClient("OpenMeteoWeather");

            string url = FormattableString.Invariant(
                $"v1/forecast?latitude={latitude}&longitude={longitude}&current=wind_speed_10m,precipitation,weather_code&wind_speed_unit=ms"
            );

            HttpResponseMessage response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();

            OpenMeteoWeatherResponse? result =
                JsonSerializer.Deserialize<OpenMeteoWeatherResponse>(json);

            return result;
        }
        public async Task<OpenMeteoMarineResponse?> GetMarineAsync(
        double latitude,
        double longitude)
        {
            var client = _httpClientFactory.CreateClient("OpenMeteoMarine");

            string url = FormattableString.Invariant(
                $"v1/marine?latitude={latitude}&longitude={longitude}&current=wave_height,sea_surface_temperature&cell_selection=sea"
            );

            HttpResponseMessage response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();

            OpenMeteoMarineResponse? result =
                JsonSerializer.Deserialize<OpenMeteoMarineResponse>(json);

            return result;
        }
    }
}