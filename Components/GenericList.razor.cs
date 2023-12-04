using BlazorApi.Dtos.RickAndMorty;
using Microsoft.AspNetCore.Components;

namespace BlazorApi.Components
{
    public partial class GenericList
    {
        [Inject]
        public NavigationManager NavManager {get;set;}

        [Parameter]
        public string Route {get;set;}
        [Parameter]
        public IEnumerable<Generic> Items {get;set;} = new List<Generic>();
        [Parameter]
        public string Title {get;set;}

        public void ViewGenericItem(Generic item)
        {
            var route = $"{Route}/{item.Id}".Replace(@"//", @"/");
            NavManager.NavigateTo(route);            
        }
    }
}