using System;
using TestApp.BuildingBlocks.Application.Commands;

namespace TestApp.Module.Prod.Application.DeprecateProduct
{
    public record DeprecateProductCommand (Guid ProductId) : ICommand
    {
        public Guid ProductId { get; } = ProductId;
    }
}