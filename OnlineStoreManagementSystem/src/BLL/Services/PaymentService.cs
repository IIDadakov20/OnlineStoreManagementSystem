using BLL.Interfaces;

namespace BLL.Services;

public class PaymentService : IPayment
{
    public void CreditCardPayment(decimal price)
    {
        Console.WriteLine($"Processing credit card payment of ${price}");
    }
    
    public void PayPalPayment(decimal price)
    {
        Console.WriteLine($"Processing PayPal payment of ${price}");
    }
}