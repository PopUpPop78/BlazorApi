using System.ComponentModel.DataAnnotations;

namespace BlazorApi.Models
{
    public class Token
    {
        [Required(ErrorMessage = "A ChatGPT bearer token is requred")]
        public string ChatGtp {get;set;}
    }
}