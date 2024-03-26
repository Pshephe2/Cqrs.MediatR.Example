using Cqrs.MediatR.Example.Commands.Products;
using Cqrs.MediatR.Example.Data;
using Cqrs.MediatR.Example.Notifications;
using Cqrs.MediatR.Example.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cqrs.MediatR.Example.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IPublisher _publisher;

        public ProductController(ISender sender, IPublisher publisher)
        {
            _sender = sender;
            _publisher = publisher;
        } 

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            var productToReturn = await _sender.Send(new AddProductCommand(product));
            await _publisher.Publish(new ProductAddedNotification(productToReturn));
            return CreatedAtRoute("GetProductById", new { id = productToReturn.Id }, productToReturn);
        }

        [HttpGet("{id:int}", Name = "GetProductById")]
        public async Task<IActionResult> GetProductById([FromRoute] int id)
        {
            var product = await _sender.Send(new GetProductByIdQuery(id));
            return Ok(product);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = _sender.Send(new GetAllProductsQuery());
            return Ok(products);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProduct([FromRoute]int id)
        {
            await _sender.Send(new DeleteProductCommand(id));
            return StatusCode(204, null);
        }
    }
}
