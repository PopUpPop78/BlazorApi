using System.Text.Json.Serialization;

namespace BlazorApi.Dtos.RickAndMorty
{
    public class LocationInfo
    {
        [JsonPropertyName("name")]
        public string Name {get;set;}
        [JsonPropertyName("type")]
        public string Type {get;set;}
        [JsonPropertyName("dimension")]
        public string Dimension {get;set;}
        [JsonPropertyName("residents")]
        public IEnumerable<CharacterInfo> Characters {get;set;}
    }
}