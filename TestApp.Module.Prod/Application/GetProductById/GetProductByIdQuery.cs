using TestApp.BuildingBlocks.Application.Queries;
using TestApp.Module.Prod.Application.GetProductOverview;

namespace TestApp.Module.Prod.Application.GetProductById
{
    public record GetProductByIdQuery : IQuery<ProductOverviewDto>;
}

