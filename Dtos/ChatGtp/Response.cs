using System.Text.Json.Serialization;

namespace BlazorApi.Dtos.ChatGpt
{
    public class Response
    {
        [JsonPropertyName("choices")]
        public IEnumerable<Choice> Choices { get; set; }
    }
}