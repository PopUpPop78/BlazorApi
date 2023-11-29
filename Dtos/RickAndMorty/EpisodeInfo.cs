using System.Text.Json.Serialization;

namespace BlazorApi.Dtos.RickAndMorty
{
    public class EpisodeInfo
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("episode")]
        public string Episode { get; set; }
        [JsonPropertyName("air_date")]
        public string AirDate {get;set;}
        [JsonPropertyName("characters")]
        public IEnumerable<CharacterInfo> Characters {get;set;}
    }
}