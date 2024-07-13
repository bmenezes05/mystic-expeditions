using Microsoft.EntityFrameworkCore;
using MysticExpeditions.Domain.Data;
using MysticExpeditions.Domain.Data.Repositories.Interfaces;
using MysticExpeditions.Domain.Models;

namespace MysticExpeditions.Domain.Data.Repositories
{
    public class ClassRepository : Repository<Class>, IClassRepository 
    {
        public ClassRepository(GameDbContext context) : base(context)
        {
        }

        public async Task<List<Class>> GetClassesAsync()
        {
            try
            {
                return await _context.Class.Where(c => c.ParentClassId == null).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }
        
        public async Task<List<Class>> GetSubclassesAsync()
        {
            return await _context.Class.Where(c => c.ParentClassId != null).ToListAsync();
        }
    }
}
