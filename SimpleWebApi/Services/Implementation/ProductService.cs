using Microsoft.EntityFrameworkCore;
using SimpleWebApi.Data;
using SimpleWebApi.Models;

namespace SimpleWebApi.Services.Implementation;

public class ProductService : IProductService
{

    private readonly WebApiDataContext _dataContext;

    public ProductService(WebApiDataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public List<Product> GetAll()
    {
        var products = _dataContext.Products.AsNoTracking().ToList();
        return products;
    }

    public Product? GetById(Guid productId)
    {
        var product = _dataContext.Products.AsNoTracking().FirstOrDefault(x => x.Id == productId);
        return product;
    }

    public Product Create(Product product)
    {
        var newProduct = _dataContext.Products.Add(product);
        _dataContext.SaveChanges();
        return newProduct.Entity;
    }

    public Product Update(Product product)
    {
        var updatedProduct = _dataContext.Products.Update(product);
        _dataContext.SaveChanges();
        return updatedProduct.Entity;
    }

    public void Delete(Product product)
    {
        _dataContext.Products.Remove(product);
        _dataContext.SaveChanges();
    }
}