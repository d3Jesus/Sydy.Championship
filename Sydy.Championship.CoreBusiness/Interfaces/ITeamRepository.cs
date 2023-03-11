using Sydy.Championship.CoreBusiness.Entities;

namespace Sydy.Championship.CoreBusiness.Interfaces
{
    public interface ITeamRepository
    {
        Task<IEnumerable<Team>> GetAsync();
    }
}
