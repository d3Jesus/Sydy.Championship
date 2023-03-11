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

        public async Task<Team> AddAsync(Team team)
        {
            _context.Teams.Add(team);
            await _context.SaveChangesAsync();

            return team;
        }

        public async Task<IEnumerable<Team>> GetAsync()
        {
            return await _context.Teams.ToListAsync();
        }

        public async Task<Team?> GetByIdAsync(int id)
        {
            return await _context.Teams.FindAsync(id);
        }

        public async Task<Team> UpdateAsync(Team team)
        {
            _context.Teams.Update(team);
            await _context.SaveChangesAsync();

            return team;
        }
    }
}
