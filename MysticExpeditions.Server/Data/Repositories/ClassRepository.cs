using Microsoft.EntityFrameworkCore;
using MysticExpeditions.Server.Models;

namespace MysticExpeditions.Server.Data.Repositories
{
    public class ClassRepository : Repository<Class>, IClassRepository 
    {
        public ClassRepository(GameDbContext context) : base(context)
        {
        }

        public async Task<List<Class>> GetClassesAsync()
        {
            return await _context.Class.Where(c => c.ParentClassId == null).ToListAsync();
        }
        
        public async Task<List<Class>> GetSubclassesAsync()
        {
            return await _context.Class.Where(c => c.ParentClassId != null).ToListAsync();
        }
    }
}