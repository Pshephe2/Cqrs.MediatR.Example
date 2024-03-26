using Cqrs.MediatR.Example.Data;
using Cqrs.MediatR.Example.Queries;
using MediatR;

namespace Cqrs.MediatR.Example.Handlers.Products
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly FakeDataFactory _dataFactory;
        public GetProductByIdHandler(FakeDataFactory dataFactory) => _dataFactory = dataFactory;

        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await _dataFactory.GetProductById(request.id);
        }
    }
}
