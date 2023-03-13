using Microsoft.EntityFrameworkCore;
using Sydy.Championship.CoreBusiness.Entities;
using Sydy.Championship.CoreBusiness.Interfaces;
using Sydy.Championship.Infrastructure.Data;

namespace Sydy.Championship.Infrastructure.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly ChampionshipDbContext _context;

        public TeamRepository(ChampionshipDbContext context)
        {
            _context = context;
        }

        public async Task<TeamModel> AddAsync(TeamModel team)
        {
            _context.Teams.Add(team);
            await _context.SaveChangesAsync();

            return team;
        }

        public async Task<bool> DeleteAsync(TeamModel team)
        {
            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<TeamModel>> GetAsync()
        {
            return await _context.Teams.ToListAsync();
        }

        public async Task<TeamModel?> GetByIdAsync(int id)
        {
            return await _context.Teams.Where(t => t.Id == id).AsNoTrackingWithIdentityResolution().FirstOrDefaultAsync();
        }

        public async Task<TeamModel?> GetByNameAsync(string name)
        {
            return await _context.Teams.Where(t => t.Name == name).AsNoTrackingWithIdentityResolution().FirstOrDefaultAsync();
        }

        public async Task<TeamModel> UpdateAsync(TeamModel team)
        {
            _context.Teams.Update(team);
            await _context.SaveChangesAsync();

            return team;
        }
    }
}
