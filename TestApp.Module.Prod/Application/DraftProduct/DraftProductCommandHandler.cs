using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TestApp.BuildingBlocks.Application;
using TestApp.BuildingBlocks.Application.Commands;
using TestApp.Module.Prod.Domain;

namespace TestApp.Module.Prod.Application.DraftProduct
{
    internal class DraftProductCommandHandler : ICommandHandler<DraftProductCommand>
    {
        private readonly IProductRepository _repository;

        public DraftProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }
    
        public async Task<Unit> Handle(DraftProductCommand command, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(command.ProductId);
            
            if(product == null) throw new NotFoundException("Product not found");

            product.Draft();

            await _repository.CommitAsync();

            return Unit.Value;
        }
    }
}