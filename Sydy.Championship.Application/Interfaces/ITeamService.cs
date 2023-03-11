using Sydy.Championship.Application.ViewModels;
using Sydy.Championship.Application.ViewModels.Teams;

namespace Sydy.Championship.Application.Interfaces
{
    public interface ITeamService
    {
        Task<ServiceResponse<IEnumerable<GetTeamViewModel>>> GetAsync();
        Task<ServiceResponse<GetTeamViewModel>> GetByIdAsync(int id);
        Task<ServiceResponse<GetTeamViewModel>> AddAsync(AddTeamViewModel team);
        Task<ServiceResponse<GetTeamViewModel>> UpdateAsync(GetTeamViewModel team);
    }
}
