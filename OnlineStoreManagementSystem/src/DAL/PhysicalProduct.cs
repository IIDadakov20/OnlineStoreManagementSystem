namespace DAL;

public class PhysicalProduct : Product
{
    public PhysicalProduct(string name, decimal price, int stock, decimal shippingCost) 
        : base(name, price, stock)
    {
        ShippingCost = shippingCost;
    }
    
    public PhysicalProduct()
    {
        ShippingCost = 0m;
    }
    
    public decimal ShippingCost { get; set; }
}