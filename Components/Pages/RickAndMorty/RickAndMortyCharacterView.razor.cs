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
        public IChatGptDataService ChatGptDataService {get;set;}
        [Inject]
        public NavigationManager NavManager {get;set;}
        [Parameter]
        public string Id {get;set;}

        private CharacterInfo character;

        protected async override Task OnInitializedAsync()
        {
            var characterDto = await RickAndMortyDataService.GetCharacter(Id);
            if(characterDto != null)
                character = characterDto.Data.CharacterInfo;
        }

        private void ViewLocation(string locationId)
        {
            Console.WriteLine($"Getting location info for {locationId}");
            NavManager.NavigateTo($"/locationView/{locationId}");            
        }

        private void ViewEpisode(string episodeId)
        {
            Console.WriteLine($"Navigating to episode {episodeId}");
            NavManager.NavigateTo($"/episodeView/{episodeId}");
        }
    }
}