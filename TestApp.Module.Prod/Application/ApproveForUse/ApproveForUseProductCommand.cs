using System;
using TestApp.BuildingBlocks.Application.Commands;

namespace TestApp.Module.Prod.Application.ApproveForUse
{
    public record ApproveForUseProductCommand (Guid ProductId) : ICommand
    {
        public Guid ProductId { get; } = ProductId;
    }
}