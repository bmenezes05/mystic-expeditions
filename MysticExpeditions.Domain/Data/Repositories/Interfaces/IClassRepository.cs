using MysticExpeditions.Domain.Data;
using MysticExpeditions.Domain.Models;

namespace MysticExpeditions.Domain.Data.Repositories.Interfaces
{
    public interface IClassRepository : IRepository<Class>
    {
        Task<List<Class>> GetClassesAsync();
        Task<List<Class>> GetSubclassesAsync();
    }
}
