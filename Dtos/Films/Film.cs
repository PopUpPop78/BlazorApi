using System.Text.Json.Serialization;

namespace BlazorApi.Dtos.Films
{
    public class Film
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }
        
        [JsonPropertyName("director")]
        public string Director { get; set; }
        [JsonPropertyName("releaseDate")]
        public string ReleaseData { get; set; }
    }
}