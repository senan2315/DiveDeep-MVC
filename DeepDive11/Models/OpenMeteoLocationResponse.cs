using System.Text.Json.Serialization;

namespace DeepDive11.Models
{
    public class OpenMeteoLocationResponse
    {
        [JsonPropertyName("results")]
        public List<OpenMeteoLocation>? Results { get; set; }
    }

    public class OpenMeteoLocation
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }
    }
}