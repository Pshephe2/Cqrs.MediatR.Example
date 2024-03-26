namespace Cqrs.MediatR.Example.Data
{
    public class FakeDataFactory
    {
        private static List<Product> _productList;

        public FakeDataFactory()
        {
            _productList = new List<Product>()
            {
                new Product()
                {
                    Id = 1,
                    Name = "Test Product 1"
                },
                new Product()
                {
                    Id = 2,
                    Name = "Test Product 2"
                },
                new Product()
                {
                    Id = 3,
                    Name = "Test Product 3"
                }
            };
        }

        public Task<Product> AddProduct(Product product)
        {
            _productList.Add(product);
            return Task.FromResult(product);
        }

        public Task DeleteProduct(Product product)
        {
            _productList.Remove(product);
            return Task.CompletedTask;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await Task.FromResult(_productList);
        }

        public async Task<Product> GetProductById(int id)
        {
            var product = _productList.First(x => x.Id == id);
            return await Task.FromResult(product);
        }
    }
}
