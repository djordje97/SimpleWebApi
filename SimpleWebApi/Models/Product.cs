namespace SimpleWebApi.Models;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }
}