using System;
using System.Threading.Tasks;
using TestApp.Module.Prod.Domain;

namespace TestApp.Module.Prod.Infrastructure.EntityFramework
{
    internal class ProductRepository : IProductRepository
    {
        private readonly ProductContext _dbContext;

        public ProductRepository(ProductContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Product product)
        {
           await _dbContext.Product.AddAsync(product);

           await _dbContext.SaveChangesAsync();
        }

        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            var product = await _dbContext.Product.FindAsync(id);

            return product;
        }
    }
}
