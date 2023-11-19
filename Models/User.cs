using ProductManager.Models.Helpers;

namespace ProductManager.Models;

public class User
{
    private Role _role;
    public User(string firstName, string lastName, Role role, Product[] products)
    {
        FirstName = firstName;
        LastName = lastName;
        Role = role;
        Products = products;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Role Role
    {
        get => _role;
        set
        {
            _role = value;
            IsApplicableForAdditionalCosts = _role == Role.User;
            ShouldAddMargin = _role == Role.VIP;
        }
    }

    public bool IsApplicableForAdditionalCosts { get; set; }
    public bool ShouldAddMargin { get; set; }
    public Product[] Products { get; set; }
}