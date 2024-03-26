using Cqrs.MediatR.Example.Commands.Products;
using Cqrs.MediatR.Example.Data;
using MediatR;

namespace Cqrs.MediatR.Example.Handlers.Products
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly FakeDataFactory _dataFactory;

        public DeleteProductHandler(FakeDataFactory dataFactory) => _dataFactory = dataFactory;

        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _dataFactory.GetProductById(request.id);
            if (product == null) return;
            await _dataFactory.DeleteProduct(product);
        }
    }
}
