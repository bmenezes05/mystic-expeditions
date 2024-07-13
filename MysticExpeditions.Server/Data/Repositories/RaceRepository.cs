using Microsoft.EntityFrameworkCore;
using MysticExpeditions.Server.Data.Repositories.Interfaces;
using MysticExpeditions.Server.Models;

namespace MysticExpeditions.Server.Data.Repositories
{
    public class RaceRepository : Repository<Race>, IRaceRepository 
    {
        public RaceRepository(GameDbContext context) : base(context)
        {            
        }

        public async Task<List<Race>> GetRacesAsync()
        {
            return await _context.Race.ToListAsync();
        }
    }
}