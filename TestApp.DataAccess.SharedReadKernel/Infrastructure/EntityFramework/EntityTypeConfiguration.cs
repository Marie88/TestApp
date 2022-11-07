using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IoCore.SharedReadKernel.Infrastructure.EntityFramework
{
    internal abstract class EntityTypeConfiguration<T> : IEntityTypeConfiguration<T> where T : class
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasNoKey();
            ConfigureCore(builder);
        }

        protected abstract void ConfigureCore(EntityTypeBuilder<T> builder);
    }
}