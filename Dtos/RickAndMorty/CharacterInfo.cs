using System.Text.Json.Serialization;

namespace BlazorApi.Dtos.RickAndMorty
{
    public class CharacterInfo
    {
        [JsonPropertyName("id")]
        public string Id {get;set;}
        [JsonPropertyName("name")]
        public string Name {get;set;}
        [JsonPropertyName("gender")]
        public string Gender {get;set;}
        [JsonPropertyName("image")]
        public string Image {get;set;}
        [JsonPropertyName("status")]
        public string Status {get;set;}
        [JsonPropertyName("species")]
        public string Species {get;set;}
        [JsonPropertyName("type")]
        public string Type {get;set;}
        [JsonPropertyName("origin")]
        public Generic Origin {get;set;}
        [JsonPropertyName("location")]
        public Generic Location {get;set;}
        [JsonPropertyName("episode")]
        public IEnumerable<Generic> Episodes {get;set;}

        public string EpisodesString => string.Join("\n", from x in Episodes select x.Name);
    }
}