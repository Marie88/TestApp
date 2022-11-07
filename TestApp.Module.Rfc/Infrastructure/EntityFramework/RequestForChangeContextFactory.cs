using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp.Module.Rfc.Infrastructure.EntityFramework
{
    internal class RequestForChangeContextFactory : IDesignTimeDbContextFactory<RequestForChangeContext>
    {
        public RequestForChangeContext CreateDbContext(string[] args)
        {
            var connectionString = "Server=(local);Database=TestApp;Integrated Security=True;MultipleActiveResultSets=true;";

            var dbContextOptionsBuilder = new DbContextOptionsBuilder<RequestForChangeContext>();
            dbContextOptionsBuilder.UseSqlServer(connectionString);
            return new RequestForChangeContext(dbContextOptionsBuilder.Options);
        }
    }
}
