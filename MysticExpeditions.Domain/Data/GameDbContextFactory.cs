using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MysticExpeditions.Domain.Data;

namespace MysticExpeditions.Domain.Data
{
    public class GameDbContextFactory : IDesignTimeDbContextFactory<GameDbContext>
    {
        public GameDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<GameDbContext>();
            optionsBuilder.UseSqlite("Data Source=mysticexpeditions.db");

            return new GameDbContext(optionsBuilder.Options);
        }
    }
}
