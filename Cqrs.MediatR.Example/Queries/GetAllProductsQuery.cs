using Cqrs.MediatR.Example.Data;
using MediatR;

namespace Cqrs.MediatR.Example.Queries
{
    public record GetAllProductsQuery() : IRequest<List<Product>>;
}
