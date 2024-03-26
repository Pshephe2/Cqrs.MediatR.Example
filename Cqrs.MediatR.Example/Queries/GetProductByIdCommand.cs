using Cqrs.MediatR.Example.Data;
using MediatR;

namespace Cqrs.MediatR.Example.Queries
{
    public record GetProductByIdQuery(int id) : IRequest<Product>;
}
