using BlazorApi.Dtos;

namespace BlazorApi.DataServices
{
    public interface IFilmsDataService
    {
        Task<FilmsReadDto> GetFilmsInfo();
    }
}