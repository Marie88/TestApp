using System;
using TestApp.BuildingBlocks.Application.Commands;

namespace TestApp.Module.Prod.Application.DraftProduct
{
    public record DraftProductCommand (Guid ProductId) : ICommand
    {
        public Guid ProductId { get; } = ProductId;
    }
}