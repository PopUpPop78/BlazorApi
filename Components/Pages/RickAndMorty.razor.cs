using BlazorApi.DataServices;
using BlazorApi.Dtos.RickAndMorty;
using Microsoft.AspNetCore.Components;

namespace BlazorApi.Components.Pages
{
    public partial class RickAndMorty
    {
        [Inject]
        public IRickAndMortyDataService RickAndMortyDataService {get;set;}

        private IEnumerable<Character> characters;

        protected async override Task OnInitializedAsync()
        {
            var charactersDto = await RickAndMortyDataService.GetAllCharacters();

            if(charactersDto != null)
                characters = charactersDto.Data.CharactersInfo.Characters;
        }
    }
}