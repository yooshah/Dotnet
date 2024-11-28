using CustomMiddleware.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomMiddleware.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProduct _product;

        

        // Constructor with Dependency Injection
        public ProductsController(IProduct product )
        {
            _product = product;
           
        }

        [HttpGet]
        public async Task<ActionResult> GetAllData()
        {
            await Task.Delay(1000); // Simulate a delay
            var products = await _product.GetAllProduct();  // Await the result
         
            return Ok(products);  // Return the products in the responsen Ok(products);  // Return the products as response
        }

        // Asynchronous action for the Hello method
        [HttpGet("hiii")]
        public async Task<ActionResult> GetData()
        {
            await Task.Delay(2000); // Simulate some delay
            var helloMessage = await _product.Hello(); // Use 'await' to get the result
            return Ok(helloMessage); // Return the result of the Hello method
        }
    }
}
