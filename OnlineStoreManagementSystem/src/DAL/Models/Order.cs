namespace DAL.Models;

public class Order
{
    public Order(Customer customer, Product product, int quantity)
    {
        Customer = customer;
        Product = product;
        Quantity = quantity;
    }

    public Customer Customer { get; set; }

    public Product Product { get; set; }

    public int Quantity { get; set; }

    public decimal TotalPrice { get; set; } = 0m;
}
