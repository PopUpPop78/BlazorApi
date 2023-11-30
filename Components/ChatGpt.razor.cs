using BlazorApi.DataServices;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;

namespace BlazorApi.Components
{
    public partial class ChatGpt{

        [Inject]
        public IChatGptDataService ChatGptDataService {get;set;}
        [Inject]
        public ILocalStorageService LocalStorageService {get;set;}
        [Inject]
        public IConfiguration Configuration {get;set;}

        [Parameter]
        public string Question {get;set;}

        private string opinion;
        
        protected override Task OnInitializedAsync()
        {
            _ = GetOpinionFromChatGtp();

            return Task.CompletedTask;
        }

        private async Task GetOpinionFromChatGtp()
        {
            try
            {
                Console.WriteLine($"Asking ChatGPT: {Question}");
                var token = await LocalStorageService.GetItemAsStringAsync(Configuration["chatGptBearerCookieKey"]);
                if(string.IsNullOrWhiteSpace(token))
                {
                    opinion = "There is no ChatGPT bearer token saved. Either save a token or goto https://platform.openai.com/ in order to create one";
                    return;
                }

                opinion = await ChatGptDataService.GetAnswer(Question, token);
            }
            finally
            {
                StateHasChanged();
            }
        }
    }
}