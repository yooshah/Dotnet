using FirstWebApi.Models;

namespace CustomMiddleware.Services
{
    public interface IProduct
    {
        Task <List<Product>> GetAllProduct();

          Task <String> Hello();


    }
}
