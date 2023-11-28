using BlazorApi.Dtos.Films;

namespace BlazorApi.DataServices
{
    public interface IFilmsDataService
    {
        Task<FilmsReadDto> GetFilmsInfo();
    }
}