using BLL.Interfaces;
using DAL.Models;

namespace BLL.Services;

public class OrderService : IOrder, IDiscount
{
    private ProductService _productService = new ProductService();
    private PaymentService _paymentService = new PaymentService();

    public void ApplyFixedDiscount(Product product, decimal discount)
    {
        if (product.Price - discount < 1)
        {
            Console.WriteLine("Insufficient discount");
        }
        else
        {
            decimal finalPrice = product.Price - discount;
            Console.WriteLine($"Discount applied. Final price: {finalPrice}");
            product.Price = finalPrice;
        }
    }

    public void ApplyPercentageDiscount(Product product, decimal discount)
    {
        if(discount > 100 || discount < 1)
        {
            Console.WriteLine("Insufficient discount");
        }
        else
        {
            decimal finalPrice = product.Price - ((discount / 100) * product.Price);
            product.Price = finalPrice;
            Console.WriteLine($"Discount applied. Final price: {finalPrice}");
        }
    }

    public bool CreateOrder(Product product, int quantity)
    {
        if (_productService.DeductStock(product, quantity))
        {
            return true;
        }
        Console.WriteLine($"Insufficient stock for {product.Name}. Available: {_productService.GetAvailableStock(product)}");
        return false;
    }

    public void CompleteOrder(Customer customer, Product product, int quantity, int paymentType)
    {
        Order order = new Order(customer, product, quantity);

        if(product is PhysicalProduct physicalProduct)
        {
            order.TotalPrice = physicalProduct.Price * quantity + physicalProduct.ShippingCost; 
        }
        else
        {
            order.TotalPrice = product.Price * quantity;
        }

        ProcessPaymentMethod(paymentType, order.TotalPrice);

        Console.WriteLine($"{quantity} units of {product.Name} deducted from stock.");
        Console.WriteLine($"Order completed for {customer.FirstName} {customer.LastName}. Product processed. Total price {order.TotalPrice}");
    }

    public void ProcessPaymentMethod(int paymentType, decimal price)
    {
        if (paymentType == 1)
        {
            _paymentService.CreditCardPayment(price);
        }
        else if(paymentType == 2)
        {
            _paymentService.PayPalPayment(price);
        }
    }
}