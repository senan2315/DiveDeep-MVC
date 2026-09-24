using System.Text.Json.Serialization;

namespace DeepDive11.Models
{
    public class OpenMeteoWeatherResponse
    {
        [JsonPropertyName("current")]
        public CurrentWeather? Current { get; set; }
    }

    public class CurrentWeather
    {
        [JsonPropertyName("wind_speed_10m")]
        public double WindSpeed { get; set; }

        [JsonPropertyName("precipitation")]
        public double Precipitation { get; set; }

        [JsonPropertyName("weather_code")]
        public int WeatherCode { get; set; }
    }
}