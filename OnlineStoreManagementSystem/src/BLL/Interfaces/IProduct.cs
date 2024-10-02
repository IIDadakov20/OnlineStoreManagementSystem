using DAL.Models;

namespace BLL.Interfaces;

public interface IProduct
{
    void DisplayProduct(DigitalProduct product);

    bool DeductStock(Product product, int quantity);

    int GetAvailableStock(Product product);
}
