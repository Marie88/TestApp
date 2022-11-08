using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace TestApp.Module.Rfc.Infrastructure.EntityFramework
{
    internal class RequestForChangeContextFactory : IDesignTimeDbContextFactory<RequestForChangeContext>
    {
        public RequestForChangeContext CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            var configuration = builder.Build();
            var connectionString = builder.Build().GetConnectionString("local");

            var dbContextOptionsBuilder = new DbContextOptionsBuilder<RequestForChangeContext>();
            dbContextOptionsBuilder.UseSqlServer(connectionString);
            return new RequestForChangeContext(dbContextOptionsBuilder.Options);
        }
    }
}
