using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using IoCore.SharedReadKernel;
using IoCore.SharedReadKernel.Product;
using Microsoft.EntityFrameworkCore;
using TestApp.BuildingBlocks.Application;
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
        var product =
            await _readModelAccess
                .Get<Product>()
                .Where(product => product.Id == request.Id)
                .SingleOrDefaultAsync();

        var productDto = Mapper.Map<Product, ProductOverviewDto>(product);

        
        if (productDto == null)
        {
            throw new NotFoundException($"Product with id {request.Id} could not be found");
        }
        
        return productDto;
    }
}