using BlazorApi.DataServices;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace BlazorApi.Components.Pages
{
    public partial class AskChatGpt
    {
        [Inject]
        public IJSRuntime JsRuntime {get;set;}        
        [Inject]
        public IChatGptDataService ChatGptDataService {get;set;}
        [Inject]
        public ILocalStorageService LocalStorageService {get;set;}
        [Inject]
        public IConfiguration Configuration {get;set;}

        private async Task Ask()
        {
            Model.Answer = "";
            await GetOpinionFromChatGtp();
        }

        public ChatGptModel Model {get;set;}

        private EditContext editContext;
        private bool isLoading = false;
        private string flash = "";

        protected async override Task OnInitializedAsync()
        {
            Model = new();
            editContext = new EditContext(Model);

            await Task.CompletedTask;
        }

        private async Task ResetValidation(KeyboardEventArgs e)
        {
            Model.Question = await JsRuntime.InvokeAsync<string>("getElementText", "txtAskChatGpt");
            editContext.Validate();
        }

        private async Task GetOpinionFromChatGtp()
        {
            try
            {
                flash = "";
                isLoading = true;

                Console.WriteLine($"Asking ChatGPT: {Model.Question}");
                var token = await LocalStorageService.GetItemAsStringAsync(Configuration["chatGptBearerCookieKey"]);
                if(string.IsNullOrWhiteSpace(token))
                {
                    Model.Answer = "There is no ChatGPT bearer token saved. Either save a token or goto https://platform.openai.com/ in order to create one";
                    return;
                }

                Model.Answer = await ChatGptDataService.GetAnswer(Model.Question, token);
            }
            finally
            {
                isLoading = false;
                flash = "flash";
                StateHasChanged();
            }
        }

        public class ChatGptModel
        {
            [System.ComponentModel.DataAnnotations.Required]
            public string Question {get;set;}
            public string Answer {get;set;}
        }
    }
}