using System.Text.Json.Serialization;

namespace BlazorApi.Dtos
{
    public class SpaceAgenciesDto
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }
        [JsonPropertyName("results")]
        public IEnumerable<Agency> Results { get; set; }
    }
}