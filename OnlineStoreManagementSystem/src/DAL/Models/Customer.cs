namespace DAL.Models;

public class Customer
{
    public Customer(string firstName, string lastName, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    public Customer()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
        Email = string.Empty;
    }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }
}
