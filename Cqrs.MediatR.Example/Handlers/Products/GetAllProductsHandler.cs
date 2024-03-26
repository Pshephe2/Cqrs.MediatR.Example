using Cqrs.MediatR.Example.Data;
using Cqrs.MediatR.Example.Queries;
using MediatR;

namespace Cqrs.MediatR.Example.Handlers.Products
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, List<Product>>
    {
        private readonly FakeDataFactory _dataFactory;

        public GetAllProductsHandler(FakeDataFactory dataFactory) => _dataFactory = dataFactory;

        public async Task<List<Product>> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
        {
            var products = await _dataFactory.GetAllProducts();
            return products;
        }
    }
}
