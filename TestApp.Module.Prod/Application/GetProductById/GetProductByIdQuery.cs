using System;
using TestApp.BuildingBlocks.Application.Queries;
using TestApp.Module.Prod.Application.GetProductOverview;

namespace TestApp.Module.Prod.Application.GetProductById
{
    public record GetProductByIdQuery(Guid Id) : IQuery<ProductOverviewDto>
    {
        public Guid Id { get; } = Id;
    }
}

