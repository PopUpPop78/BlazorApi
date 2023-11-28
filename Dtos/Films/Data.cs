using System.Text.Json.Serialization;

namespace BlazorApi.Dtos.Films
{
    public class Data
    {
        [JsonPropertyName("allFilms")]
        public FilmInfo AllFilms { get; set; }
    }
}