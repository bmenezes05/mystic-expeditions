using Microsoft.EntityFrameworkCore;
using MysticExpeditions.Domain.Data;
using MysticExpeditions.Domain.Data.Repositories.Interfaces;
using MysticExpeditions.Domain.Models;

namespace MysticExpeditions.Domain.Data.Repositories
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
