using Microsoft.EntityFrameworkCore;
using TestApp.Module.Prod.Domain;


namespace TestApp.Module.Prod.Infrastructure.EntityFramework
{
    internal class ProductContext : DbContext
    {
        public DbSet<Product> Product { get; set; } = null!;

        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("prd");
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

        }
    }
}
