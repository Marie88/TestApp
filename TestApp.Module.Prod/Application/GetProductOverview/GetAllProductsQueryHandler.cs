using AutoMapper;
using AutoMapper.QueryableExtensions;
using IoCore.SharedReadKernel;
using IoCore.SharedReadKernel.Product;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TestApp.BuildingBlocks.Application.Queries;

namespace TestApp.Module.Prod.Application.GetProductOverview
{
    internal class GetAllProductsQueryHandler : IQueryHandler<GetAllProductsQuery, IEnumerable<ProductOverviewDto>>
    {
        private static readonly IMapper Mapper;

        private readonly IReadModelAccess _readModelAccess;

        static GetAllProductsQueryHandler()
        {
            Mapper = ConfigureMapper();
        }

        public GetAllProductsQueryHandler(IReadModelAccess readModelAccess)
        {
            _readModelAccess = readModelAccess;
        }

        private static IMapper ConfigureMapper()
        {
            var configuration = new MapperConfiguration(configurationExpression =>
                configurationExpression.CreateMap<Product, ProductOverviewDto>());

            return configuration.CreateMapper();
        }

        public async Task<IEnumerable<ProductOverviewDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var productSummaryDtos =
                 await _readModelAccess
                 .Get<Product>()
                 .ProjectTo<ProductOverviewDto>(Mapper.ConfigurationProvider)
                 .ToListAsync(cancellationToken: cancellationToken);

            return productSummaryDtos;
        }


    }
}
