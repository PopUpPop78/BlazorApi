using System.Text.Json.Serialization;

namespace BlazorApi.Dtos.ChatGpt
{
    public class Choice
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }
    }
}