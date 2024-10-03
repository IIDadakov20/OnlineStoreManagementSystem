using DAL.Models;

namespace BLL.Interfaces;

public interface IOrder
{
    bool CreateOrder(Product product, int quantity);

    void CompleteOrder(Customer customer, Product product, int quantity, int paymentType);
}