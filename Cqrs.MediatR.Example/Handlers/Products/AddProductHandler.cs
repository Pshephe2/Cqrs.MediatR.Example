using Cqrs.MediatR.Example.Commands.Products;
using Cqrs.MediatR.Example.Data;
using MediatR;

namespace Cqrs.MediatR.Example.Handlers.Products
{
    public class AddProductHandler : IRequestHandler<AddProductCommand, Product>
    {
        private readonly FakeDataFactory _dataFactory;

        public AddProductHandler(FakeDataFactory dataFactory) => _dataFactory = dataFactory;

        public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            return await _dataFactory.AddProduct(request.product);
        }
    }
}
