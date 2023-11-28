using System.Text.Json.Serialization;

namespace BlazorApi.Dtos.Films
{
    public class FilmInfo
    {
        [JsonPropertyName("films")]
        public IEnumerable<Film> Films { get; set; }
    }
}