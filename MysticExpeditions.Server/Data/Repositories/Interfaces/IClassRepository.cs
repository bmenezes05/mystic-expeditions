using MysticExpeditions.Server.Models;

namespace MysticExpeditions.Server.Data.Repositories
{
    public interface IClassRepository : IRepository<Class>
    {
        Task<List<Class>> GetClassesAsync();
        Task<List<Class>> GetSubclassesAsync();
    }
}