using MediatR;
using Cqrs.MediatR.Example.Data;

namespace Cqrs.MediatR.Example.Commands.Products
{
    public record AddProductCommand(Product product) : IRequest<Product>;

}
