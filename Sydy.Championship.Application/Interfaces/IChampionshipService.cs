using Sydy.Championship.Application.ViewModels;
using Sydy.Championship.Application.ViewModels.Championship;
using Sydy.Championship.Application.ViewModels.Teams;

namespace Sydy.Championship.Application.Interfaces
{
    public interface IChampionshipService
    {
        Task<ServiceResponse<IEnumerable<GetChampionshipViewModel>>> GetChampionshipAsync(string name = "", int year = 0);
        Task<QueryStringParameter<GetChampionshipViewModel>> GetPaginatedAsync (int pageNumber, int itemsPerPage);
        Task<ServiceResponse<string>> AddAsync(AddChampionshipViewModel championship);
    }
}
