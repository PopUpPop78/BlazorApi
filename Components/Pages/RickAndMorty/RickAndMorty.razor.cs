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
        public NavigationManager NavManager {get;set;}
        [Parameter]
        public int? ActivePage {get;set;}

        private IEnumerable<CharacterInfo> characters;

        private int totalPages;
        private int totalCharacters;
        private int maxPagesView = 5;
        private int minPageView = 1;
        private string filterText = string.Empty;
        private int activePage = 1;

        protected async override Task OnInitializedAsync()
        {
            if(ActivePage != null)
            {
                activePage = ActivePage.Value;
            }
            
            await GetCharactersAndInfo();
        }

        private async Task GetCharactersAndInfo()
        {
            var charactersDto = await RickAndMortyDataService.GetAllCharacters(activePage, filterText);

            if(charactersDto != null)
            {
                characters = charactersDto.Data.CharactersInfo.Characters;
                totalPages = charactersDto.Data.CharactersInfo.Info.Pages;
                totalCharacters = charactersDto.Data.CharactersInfo.Info.Count;
            }
        }

        private string IsActive(int item)
        {
            return item == activePage ? " active" : ""; 
        }

        private void SetActive(int item)
        {
            activePage = item;
            NavManager.NavigateTo($"/rickandmorty/{activePage}");
        }

        private void ViewCharacter(string id)
        {
            Console.WriteLine($"Navigating to character {id}");
            NavManager.NavigateTo($"/characterView/{id}");
        }
    }
}