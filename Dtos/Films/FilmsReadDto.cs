using System.Text.Json.Serialization;

namespace BlazorApi.Dtos.Films
{
    public class FilmsReadDto
    {
        [JsonPropertyName("data")]
        public Data Data { get; set; }
    }
}