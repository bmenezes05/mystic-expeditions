using Microsoft.EntityFrameworkCore;
using MysticExpeditions.Server.Data.Repositories.Interfaces;
using MysticExpeditions.Server.Models;

namespace MysticExpeditions.Server.Data.Repositories
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