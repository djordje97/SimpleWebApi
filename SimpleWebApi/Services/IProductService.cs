using SimpleWebApi.Models;

namespace SimpleWebApi.Services;

public interface IProductService
{
    List<Product> GetAll();

    Product? GetById(Guid productId);
    Product Create(Product product);
    Product Update(Product product);
    void Delete(Product product);
}