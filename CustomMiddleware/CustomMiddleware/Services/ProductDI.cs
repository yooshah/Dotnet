using CustomMiddleware.Services;
using FirstWebApi.Models;

public class ProductDI : IProduct
{
    private List<Product> _products = new List<Product>()
    {
        new Product { Name = "Ashik", Id = 1, Description = "yooouu" },
        new Product { Name = "Suhail", Id = 2, Description = "developer" },
        new Product { Name = "Arsal", Id = 3, Description = "Weedlver" },
    };

    public async Task<List<Product>> GetAllProduct()
    {
        await Task.Delay(400); // Simulate a delay like querying a database
        return _products;
    }

    public async Task<string> Hello()
    {
        await Task.Delay(1000); // Simulate a delay
        return "HAAAA";
    }
}
