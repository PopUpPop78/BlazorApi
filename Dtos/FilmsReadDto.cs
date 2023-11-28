using System.Text.Json.Serialization;

namespace BlazorApi.Dtos
{
    public class FilmsReadDto
    {
        [JsonPropertyName("data")]
        public Data Data { get; set; }
    }

    public class Data
    {
        [JsonPropertyName("allFilms")]
        public FilmInfo AllFilms { get; set; }
    }

    public class FilmInfo
    {
        [JsonPropertyName("films")]
        public IEnumerable<Film> Films { get; set; }
    }

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