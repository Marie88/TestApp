using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TestApp.BuildingBlocks.Application;
using TestApp.BuildingBlocks.Application.Commands;
using TestApp.Module.Prod.Domain;

namespace TestApp.Module.Prod.Application.ApproveForUse
{
    internal class ApproveForUseProductCommandHandler : ICommandHandler<ApproveForUseProductCommand>
    {
        private readonly IProductRepository _repository;

        public ApproveForUseProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }
    
        public async Task<Unit> Handle(ApproveForUseProductCommand command, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(command.ProductId);
            
            if(product == null) throw new NotFoundException("Product not found");

            product.ApproveForUse();

            await _repository.CommitAsync();

            return Unit.Value;
        }
    }
}