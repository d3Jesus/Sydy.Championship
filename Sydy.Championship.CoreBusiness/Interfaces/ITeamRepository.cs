using Sydy.Championship.CoreBusiness.Entities;

namespace Sydy.Championship.CoreBusiness.Interfaces
{
    public interface ITeamRepository
    {
        Task<IEnumerable<TeamModel>> GetAsync();
        Task<TeamModel> GetByIdAsync(int id);
        Task<TeamModel> GetByNameAsync(string name);
        Task<TeamModel> AddAsync(TeamModel team);
        Task<TeamModel> UpdateAsync(TeamModel team);
        Task<bool> DeleteAsync(TeamModel team);
    }
}
