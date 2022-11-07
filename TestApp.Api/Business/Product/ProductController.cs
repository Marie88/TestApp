using Microsoft.AspNetCore.Mvc;
using TestApp.Module.Prod.Application.ApproveForUse;
using TestApp.Module.Prod.Application.DeprecateProduct;
using TestApp.Module.Prod.Application.DraftProduct;
using TestApp.Module.Prod.Application.GetProductById;
using TestApp.Module.Prod.Application.GetProductOverview;
using TestApp.Module.Prod.Application.NewProduct;
using TestApp.ModuleIntegration.EntryPoint;

namespace TestApp.Api.Business.Product
{
    [ApiController]
    public class ProductController
    {
        [HttpGet("/products")]
        public async Task<IEnumerable<ProductOverviewDto>> GetAllProducts([FromServices] IModuleDispatcher moduleDispatcher)
        {
            var query = new GetAllProductsQuery();
            var allProducts = await moduleDispatcher.Execute(query);

            return allProducts;
        }
        

        [HttpGet("/products/{id}")]
        public async Task<ProductOverviewDto> GetProductById(Guid id, [FromServices] IModuleDispatcher moduleDispatcher)
        {
            var query = new GetProductByIdQuery(id);
            var product = await moduleDispatcher.Execute(query);

            return product;
        }
        
        [HttpPost("/products")]
        public async Task NewProduct(NewProductCommand command, [FromServices] IModuleDispatcher moduleDispatcher)
        {
            await moduleDispatcher.Execute(command);
        }

        [HttpPost("/products/approve-for-use")]
        public async Task ApproveForUse(ApproveForUseProductCommand command, [FromServices] IModuleDispatcher moduleDispatcher)
        {
            await moduleDispatcher.Execute(command);
        }
        
        [HttpPost("/products/deprecate")]
        public async Task Deprecate(DeprecateProductCommand command, [FromServices] IModuleDispatcher moduleDispatcher)
        {
            await moduleDispatcher.Execute(command);
        }
        
        [HttpPost("/products/draft")]
        public async Task Draft(DraftProductCommand command, [FromServices] IModuleDispatcher moduleDispatcher)
        {
            await moduleDispatcher.Execute(command);
        }
    }
}
