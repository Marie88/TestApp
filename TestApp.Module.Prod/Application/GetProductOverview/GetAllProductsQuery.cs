using System.Collections.Generic;
using TestApp.BuildingBlocks.Application.Queries;

namespace TestApp.Module.Prod.Application.GetProductOverview
{
    public record GetAllProductsQuery : IQuery<IEnumerable<ProductOverviewDto>>;
}
