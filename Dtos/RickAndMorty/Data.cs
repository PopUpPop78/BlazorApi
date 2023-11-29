using System.Text.Json.Serialization;

namespace BlazorApi.Dtos.RickAndMorty
{
    public class Data
    {
        [JsonPropertyName("characters")]
        public CharactersInfo CharactersInfo {get;set;}
        [JsonPropertyName("character")]
        public CharacterInfo CharachterInfo {get;set;}
        [JsonPropertyName("episode")]
        public EpisodeInfo Episode {get;set;}
    }
}