using Cqrs.MediatR.Example.Data;
using MediatR;

namespace Cqrs.MediatR.Example.Commands.Products
{
    public record DeleteProductCommand(int id) : IRequest;
}
