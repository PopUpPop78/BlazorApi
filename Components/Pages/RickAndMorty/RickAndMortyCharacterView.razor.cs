using BlazorApi.DataServices;
using BlazorApi.Dtos.RickAndMorty;
using Microsoft.AspNetCore.Components;

namespace BlazorApi.Components.Pages.RickAndMorty
{
    public partial class RickAndMortyCharacterView
    {
        [Inject]
        public IRickAndMortyDataService RickAndMortyDataService {get;set;}
        [Inject]
        public NavigationManager navManager {get;set;}
        [Parameter]
        public string Id {get;set;}

        private CharacterInfo character;

        protected async override Task OnInitializedAsync()
        {
            var characterDto = await RickAndMortyDataService.GetCharacter(Id);
            if(characterDto != null)
                character = characterDto.Data.CharachterInfo;
        }

        private void ViewEpisode(string episodeId)
        {
            Console.WriteLine($"Navigating to episode {episodeId}");
            navManager.NavigateTo($"/episodeView/{episodeId}");
        }
    }
}