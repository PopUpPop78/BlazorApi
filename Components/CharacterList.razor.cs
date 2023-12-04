using BlazorApi.Dtos.RickAndMorty;
using Microsoft.AspNetCore.Components;

namespace BlazorApi.Components
{
    public partial class CharacterList
    {
        [Inject]
        public NavigationManager NavManager {get;set;}

        [Parameter]
        public IEnumerable<CharacterInfo> Characters {get;set;} = new List<CharacterInfo>();

        private void ViewCharacter(string characterId)
        {
            Console.WriteLine($"Navigating to character {characterId}");
            NavManager.NavigateTo($"/characterView/{characterId}");
        }        
    }
}