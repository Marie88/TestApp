using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace TestApp.Module.Prod.Infrastructure.EntityFramework
{
    internal class ProductContextFactory : IDesignTimeDbContextFactory<ProductContext>
    {
        ProductContext IDesignTimeDbContextFactory<ProductContext>.CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            var configuration = builder.Build();
            var connectionString = builder.Build().GetConnectionString("local");

            var dbContextOptionsBuilder = new DbContextOptionsBuilder<ProductContext>();
            dbContextOptionsBuilder.UseSqlServer(connectionString);
            return new ProductContext(dbContextOptionsBuilder.Options);
        }
    }
}
