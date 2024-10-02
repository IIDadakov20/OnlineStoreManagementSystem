namespace DAL.Models;

public class DigitalProduct : Product
{
    public DigitalProduct(string name, decimal price, int stock, int fileSizeMb)
        : base(name, price, stock)
    {
        FileSizeMb = fileSizeMb;
    }
    
    public DigitalProduct()
    {
        FileSizeMb = 0;
    }
    
    public int FileSizeMb { get; set; }
}