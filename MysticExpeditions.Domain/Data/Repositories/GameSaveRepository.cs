using Microsoft.EntityFrameworkCore;
using MysticExpeditions.Domain.Data;
using MysticExpeditions.Domain.Data.Repositories.Interfaces;
using MysticExpeditions.Domain.Models;

namespace MysticExpeditions.Domain.Data.Repositories
{
    public class GameSaveRepository : Repository<GameSave>, IGameSaveRepository 
    {
        public GameSaveRepository(GameDbContext context) : base(context)
        {            
        }

        public async Task<GameSave> GetByIdAsync(int gameSaveId)
        {
            return await _context.GameSave
                .Include(gs => gs.Character)
                .Include(gs => gs.CurrentChapter)
                .Include(gs => gs.CurrentScenario)
                .Include(gs => gs.CurrentAdventureEvent)
                .FirstOrDefaultAsync(gs => gs.GameSaveId == gameSaveId);
        }

        public async Task<IEnumerable<GameSave>> GetAllAsync()
        {
            return await _context.GameSave
                .Include(gs => gs.Character)
                .ToListAsync();
        }

        public async Task DeleteAsync(int gameSaveId)
        {
            var gameSave = await GetByIdAsync(gameSaveId);
            if (gameSave != null)
            {
                _context.GameSave.Remove(gameSave);
                await _context.SaveChangesAsync();
            }
        }
    }
}
