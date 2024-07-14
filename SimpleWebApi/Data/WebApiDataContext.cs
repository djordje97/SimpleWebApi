using Microsoft.EntityFrameworkCore;
using SimpleWebApi.Models;

namespace SimpleWebApi.Data;

public class WebApiDataContext : DbContext
{

    public WebApiDataContext(DbContextOptions<WebApiDataContext> options) : base(options)
    {
        
    }
    
    public DbSet<Product> Products { get; set; }
}