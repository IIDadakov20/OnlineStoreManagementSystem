namespace DAL;

public abstract class Product
{
    protected Product(string name, decimal price, int stock)
    {
        Name = name;
        Price = price;
        Stock = stock;
    }
    
    protected Product()
    {
        Name = string.Empty;
        Price = 0m;
        Stock = 0;
    }
    
    public string Name { get; }

    public decimal Price { get; }
    
    public int Stock { get; set; }
}