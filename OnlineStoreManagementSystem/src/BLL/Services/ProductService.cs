using BLL.Interfaces;
using DAL.Models;
using System.Xml.Linq;

namespace BLL.Services;

public class ProductService
{
    public static event Action<string> OutOfStockEvent;

    public void DisplayProduct(DigitalProduct product)
    {
        Console.WriteLine($"Product name: {product.Name}, price: {product.Price}, file size: {product.FileSizeMb}");
    }

    public void DisplayProduct(PhysicalProduct product)
    {
        Console.WriteLine($"Product name: {product.Name}, price: {product.Price}, shipping cost: {product.ShippingCost}");
    }

    public bool DeductStock(Product product, int quantity)
    {
        if (product.Stock >= quantity)
        {
            product.Stock -= quantity;
            if (product.Stock == 0)
            {
                OutOfStockEvent?.Invoke($"{product.Name} is now out of stock!");
            }
            return true;
        }
        return false;
    }

    public int GetAvailableStock(Product product) => product.Stock;
}