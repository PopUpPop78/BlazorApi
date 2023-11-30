using System.ComponentModel.DataAnnotations;
using BlazorApi.Models;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorApi.Components
{
    public partial class BearerTokenSaver
    {
        [Inject]
        public ILocalStorageService LocalStorageService {get;set;}
        [Inject]
        public IConfiguration Configuration {get;set;}

        public string ModalDisplay = "none;";
        public string ModalClass = "";
        public bool ShowBackdrop = false;

        // Forms
        private EditContext editContext;
        private ValidationMessageStore store;
        public Token Token = new();

        protected override void OnInitialized()
        {
            editContext = new EditContext(Token);
            store = new ValidationMessageStore(editContext);
        }

        public void Open()
        {
            Token.ChatGtp = null;
            ModalDisplay = "block;";
            ModalClass = "Show";
            ShowBackdrop = true;
            
            editContext = new EditContext(Token);
            store = new ValidationMessageStore(editContext);

            StateHasChanged();
        }

        public void Close()
        {
            ModalDisplay = "none";
            ModalClass = "";
            ShowBackdrop = false;

            StateHasChanged();
        }

        public async Task Save()
        {            
            Console.WriteLine("Saving bearer token");
            await LocalStorageService.SetItemAsStringAsync(Configuration["chatGptBearerCookieKey"], Token.ChatGtp);

            Close();
        }
    }
}