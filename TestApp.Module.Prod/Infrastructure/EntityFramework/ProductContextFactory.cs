using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TestApp.Module.Prod.Infrastructure.EntityFramework
{
    internal class ProductContextFactory : IDesignTimeDbContextFactory<ProductContext>
    {
        ProductContext IDesignTimeDbContextFactory<ProductContext>.CreateDbContext(string[] args)
        {
            var connectionString = "Server=(local);Database=TestApp;Integrated Security=True;MultipleActiveResultSets=true;";

            var dbContextOptionsBuilder = new DbContextOptionsBuilder<ProductContext>();
            dbContextOptionsBuilder.UseSqlServer(connectionString);
            return new ProductContext(dbContextOptionsBuilder.Options);
        }
    }
}
