using System.ComponentModel.DataAnnotations;

namespace BlazorApi.Models
{
    public class ChatGptModel
    {
        [Required]
        public string Question {get;set;}
        public string Answer {get;set;}
    }
}