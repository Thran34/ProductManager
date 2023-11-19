using ProductManager.Models.Helpers;

namespace ProductManager.Models;

public class User
{
    public User(string firstName, string lastName, Role role, Product[] products)
    {
        FirstName = firstName;
        LastName = lastName;
        Role = role;
        Products = products;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Role Role { get; set; }
    public Product[] Products { get; set; }
}