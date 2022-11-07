using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestApp.BuildingBlocks.Infrastructure.Domain.EntityFramework;
using TestApp.Module.Prod.Domain;

namespace TestApp.Module.Prod.Infrastructure.EntityFramework
{
    internal class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        protected override void ConfigureCore(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasAlternateKey(product => product.Key);
            builder.Property(product => product.Title).IsRequired();
            builder.Property(product => product.Version).IsRequired();
            builder.Property(product => product.Status).IsRequired();
        }
    }
}
