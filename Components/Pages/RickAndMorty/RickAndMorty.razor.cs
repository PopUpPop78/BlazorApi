using BlazorApi.DataServices;
using BlazorApi.Dtos.RickAndMorty;
using Microsoft.AspNetCore.Components;

namespace BlazorApi.Components.Pages.RickAndMorty
{
    public partial class RickAndMorty
    {
        [Inject]
        public IRickAndMortyDataService RickAndMortyDataService {get;set;}
        [Inject]
        public NavigationManager navManager {get;set;}

        private IEnumerable<CharacterInfo> characters;

        protected async override Task OnInitializedAsync()
        {
            var charactersDto = await RickAndMortyDataService.GetAllCharacters();

            if(charactersDto != null)
                characters = charactersDto.Data.CharactersInfo.Characters;
        }

        private void ViewCharacter(string id)
        {
            Console.WriteLine($"Navigating to character {id}");
            navManager.NavigateTo($"/characterView/{id}");
        }
    }
}