using Microsoft.EntityFrameworkCore;
using TestApp.Module.Rfc.Domain;
using TestApp.Module.Prod.Domain;

namespace TestApp.Module.Infrastructure.EntityFramework
{
    internal class TestAppDbContext : DbContext
    {
        public DbSet<RequestForChange> RequestsForChange { get; set; } = null!;

        public RequestForChangeContext(DbContextOptions<RequestForChangeContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("rfc");
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}