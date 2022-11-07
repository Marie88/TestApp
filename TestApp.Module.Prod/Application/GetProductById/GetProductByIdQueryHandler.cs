using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using IoCore.SharedReadKernel;
using IoCore.SharedReadKernel.Product;
using Microsoft.EntityFrameworkCore;
using TestApp.BuildingBlocks.Application.Queries;
using TestApp.Module.Prod.Application.GetProductOverview;

namespace TestApp.Module.Prod.Application.GetProductById;

internal class GetProductByIdQueryHandler : IQueryHandler<GetProductByIdQuery, ProductOverviewDto>
{
    private static readonly IMapper Mapper;

    private readonly IReadModelAccess _readModelAccess;

    static GetProductByIdQueryHandler()
    {
        Mapper = ConfigureMapper();
    }
    
    public GetProductByIdQueryHandler(IReadModelAccess readModelAccess)
    {
        _readModelAccess = readModelAccess;
    }
    
    private static IMapper ConfigureMapper()
    {
        var configuration = new MapperConfiguration(configurationExpression =>
            configurationExpression.CreateMap<Product, ProductOverviewDto>());

        return configuration.CreateMapper();
    }
    
    public async Task<ProductOverviewDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        /*var productSummaryDto =
             _readModelAccess
                .Get<Product>()
                .ProjectTo<ProductOverviewDto>(Mapper.ConfigurationProvider);

        return productSummaryDto;*/
        return new ProductOverviewDto();
    }
}