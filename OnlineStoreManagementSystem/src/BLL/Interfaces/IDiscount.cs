using DAL.Models;

namespace BLL.Interfaces;

public interface IDiscount
{
    void ApplyFixedDiscount(Product product, decimal discount);

    void ApplyPercentageDiscount(Product product, decimal discount);
}
