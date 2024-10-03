namespace BLL.Interfaces;

public interface IPayment
{
    void CreditCardPayment(decimal price);

    void PayPalPayment(decimal price);
}