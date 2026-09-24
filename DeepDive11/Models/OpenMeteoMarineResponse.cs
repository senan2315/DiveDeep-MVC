using System.Text.Json.Serialization;

namespace DeepDive11.Models
{
    public class OpenMeteoMarineResponse
    {
        [JsonPropertyName("current")]
        public CurrentMarine? Current { get; set; }
    }

    public class CurrentMarine
    {
        [JsonPropertyName("wave_height")]
        public double? WaveHeight { get; set; }

        [JsonPropertyName("sea_surface_temperature")]
        public double? WaterTemperature { get; set; }
    }
}