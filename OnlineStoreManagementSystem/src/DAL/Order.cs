namespace DAL;

public class Order
{
    public Order(Customer customer, Product product, int quantity)
    {
        Customer = customer;
        Product = product;
        Quantity = quantity;
    }

    public required Customer Customer { get; set; }
    public required Product Product { get; set; }
    public required int Quantity { get; set; }
    public decimal TotalPrice { get; set; } = 0m;
}
