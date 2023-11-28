using System.Text.Json.Serialization;

namespace BlazorApi.Dtos.RickAndMorty
{
    public class Character
    {
        [JsonPropertyName("id")]
        public string Id {get;set;}
        [JsonPropertyName("name")]
        public string Name {get;set;}
        [JsonPropertyName("gender")]
        public string Gender {get;set;}
        [JsonPropertyName("image")]
        public string Image {get;set;}
    }

    public class CharactersInfo
    {
        [JsonPropertyName("results")]
        public IEnumerable<Character> Characters {get;set;}
    }

    public class Data
    {
        [JsonPropertyName("characters")]
        public CharactersInfo CharactersInfo {get;set;}
    }

    public class CharactersReadAllDto
    {
        [JsonPropertyName("data")]
        public Data Data {get;set;}
    }
}