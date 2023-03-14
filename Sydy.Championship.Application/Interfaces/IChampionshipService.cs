using Sydy.Championship.Application.ViewModels;
using Sydy.Championship.Application.ViewModels.Championship;

namespace Sydy.Championship.Application.Interfaces
{
    public interface IChampionshipService
    {
        Task<ServiceResponse<IEnumerable<GetChampionshipViewModel>>> GetChampionshipAsync(string name = "", int year = 0);
        Task<QueryStringParameter<GetChampionshipViewModel>> GetPaginatedChampionshipsAsync (int pageNumber, int itemsPerPage);
        Task<QueryStringParameter<GetChampionshipViewModel>> GetPaginatedChampionshipMatchAsync (int pageNumber, int itemsPerPage, string name = "", int year = 0);
        Task<ServiceResponse<string>> AddAsync(AddChampionshipViewModel championship);
    }
}
