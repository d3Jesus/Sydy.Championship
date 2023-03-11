using Sydy.Championship.CoreBusiness.Entities;

namespace Sydy.Championship.CoreBusiness.Interfaces
{
    public interface ITeamRepository
    {
        Task<IEnumerable<Team>> GetAsync();
        Task<Team> GetByIdAsync(int id);
        Task<Team> AddAsync(Team team);
        Task<Team> UpdateAsync(Team team);
    }
}
