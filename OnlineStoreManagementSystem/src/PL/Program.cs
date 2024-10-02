using BLL.Services;
using DAL.Models;

namespace PL;

public class Program
{
    static void Main(string[] args)
    {
        ProductService productService = new ProductService();
        CustomerService customerService = new CustomerService();
        OrderService orderService = new OrderService();

        ProductService.OutOfStockEvent += message =>
        {
            Console.WriteLine($"[EVENT] {message}");
        };

        Customer customer1 = new Customer("John", "Doe", "dasdsa@gmail.com");
        Customer customer2 = new Customer("Jane", "Smith", "dasdsa@gmail.com");

        PhysicalProduct laptop = new PhysicalProduct("Laptop", 1000.00m, 5, 15.50m);
        DigitalProduct ebook = new DigitalProduct("Ebook", 20.00m, 100, 15);

        customerService.DisplayInfo(customer1);
        customerService.DisplayInfo(customer2);

        productService.DisplayProduct(laptop);
        productService.DisplayProduct(ebook);

        Console.WriteLine();

        if (orderService.CreateOrder(laptop, 3))
        {
            // Apply a 50% discount to the laptop order
            orderService.ApplyPercentageDiscount(laptop, 50);
            orderService.CompleteOrder(customer1, laptop, 3);
        }

        Console.WriteLine();

        if (orderService.CreateOrder(ebook, 1))
        {
            // Apply a $50 fixed discount on ebooks
            orderService.ApplyFixedDiscount(ebook, 50);
            orderService.CompleteOrder(customer2, ebook, 1);
        }

        Console.WriteLine();

        if (orderService.CreateOrder(ebook, 1))
        {
            // Apply a $5 fixed discount on ebooks
            orderService.ApplyFixedDiscount(ebook, 5);
            orderService.CompleteOrder(customer1, ebook, 15);
        }

        Console.WriteLine();

        // Attempt to create an order with insufficient stock
        if (!orderService.CreateOrder(laptop, 30))
        {
            Console.WriteLine("Failed to create second laptop order due to insufficient stock.");
        }

        Console.WriteLine();

        // Attempt to create an order with exact stock
        if (orderService.CreateOrder(laptop, 2))
        {
            orderService.CompleteOrder(customer2, laptop, 2);
        }
    }
}