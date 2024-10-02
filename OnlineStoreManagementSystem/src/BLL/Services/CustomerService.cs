using BLL.Interfaces;
using DAL.Models;

namespace BLL.Services;

public class CustomerService : ICustomer
{
    public void DisplayInfo(Customer customer)
    {
        Console.WriteLine($"Customer: {customer.FirstName} {customer.LastName}, Email: {customer.Email}");
    }
}
