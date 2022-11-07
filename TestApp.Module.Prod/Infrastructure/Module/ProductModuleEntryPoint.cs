using Autofac.Core;
using Autofac;
using TestApp.BuildingBlocks.Module;
using TestApp.Module.Prod.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using TestApp.BuildingBlocks.Infrastructure.Database;

namespace TestApp.Module.Prod.Infrastructure.Module
{
    internal class ProductModuleEntryPoint : DependencyInjectionEntryPoint
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductContext>()
                .WithParameter(
                    new ResolvedParameter(
                        (info, context) => info.ParameterType == typeof(DbContextOptions<ProductContext>),
                        (info, context) =>
                        {
                            var connectionFactory = context.Resolve<ISqlConnectionFactory>();
                            var dbContextOptionsBuilder = new DbContextOptionsBuilder<ProductContext>();

                            dbContextOptionsBuilder.UseSqlServer(connectionFactory.GetConnectionString(), b =>
                            {
                                b.MigrationsAssembly(@"TestApp.Module.Prod");
                                b.MigrationsHistoryTable("__EFMigrationsHistroy", "prd");
                            });
                               
                            return dbContextOptionsBuilder.Options;
                        }))
                .AsSelf()
                .InstancePerLifetimeScope();
        }
    }
}
