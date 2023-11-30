using System.Text.Json.Serialization;

namespace BlazorApi.Dtos.RickAndMorty
{
    public class Data
    {
        [JsonPropertyName("characters")]
        public CharactersInfo CharactersInfo {get;set;}
        [JsonPropertyName("character")]
        public CharacterInfo CharacterInfo {get;set;}
        [JsonPropertyName("episode")]
        public EpisodeInfo EpisodeInfo {get;set;}
        [JsonPropertyName("location")]
        public LocationInfo LocationInfo {get;set;}
    }
}