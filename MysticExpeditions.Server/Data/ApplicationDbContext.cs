using Microsoft.EntityFrameworkCore;
using MysticExpeditions.Shared.Models;

namespace MysticExpeditions.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ExampleModel> ExampleModels { get; set; }
    }
}