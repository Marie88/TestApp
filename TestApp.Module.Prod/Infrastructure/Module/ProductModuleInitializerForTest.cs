using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestApp.BuildingBlocks.Module;
using TestApp.Module.Prod.Domain;
using TestApp.Module.Prod.Infrastructure.EntityFramework;

namespace TestApp.Module.Prod.Infrastructure.Module
{
    internal class ProductModuleInitializerForTest: IModuleInitializer
    {
        private readonly ProductContext _context;

        public ProductModuleInitializerForTest(ProductContext context)
        {
            _context = context;
        }

        public async Task Run()
        {
            await _context.Database.EnsureDeletedAsync();
            await _context.Database.MigrateAsync();

            var firstProduct = Product.Create("prod1", "Product 1", "2");
            var secondProduct = Product.Create("prod2", "Product 2", "1");
            var thirdProduct = Product.Create("prod3", "Product 3", "4");

            firstProduct.ApproveForUse();
            secondProduct.ApproveForUse();

            await _context.Product.AddRangeAsync(firstProduct, secondProduct, thirdProduct);
            await _context.SaveChangesAsync();
        }
    }
}
