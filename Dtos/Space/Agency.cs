using System.Text.Json.Serialization;

namespace BlazorApi.Dtos.Space
{
    public class Agency
    {
        [JsonPropertyName("id")]
        public int Id {get;set;}
        [JsonPropertyName("name")]
        public string Name {get;set;}
        [JsonPropertyName("description")]
        public string Description {get;set;}
    }
}