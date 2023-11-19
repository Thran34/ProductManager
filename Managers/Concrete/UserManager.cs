using ProductManager.Managers.Abstract;
using ProductManager.Models;
using ProductManager.Models.Helpers;

namespace ProductManager.Managers.Concrete;

internal class UserManager : IUserManager
{
    private readonly IProductManager _productManager;
    private readonly IPriceManager _priceManager;

    public UserManager(IProductManager productManager, IPriceManager priceManager)
    {
        _productManager = productManager;
        _priceManager = priceManager;
    }

    public User SetupUser(string firstName, string lastName, Role role)
    {
        var products = _productManager.CreateProducts().ToArray();

        var user = new User(firstName, lastName, role, products);

        return user;
    }

    public void ManageUser(User user)
    {
        var cart = _productManager.CalculateCart(user);
        _priceManager.CalculateProductWeightPrice(ref cart, user);
        _priceManager.CalculateDiscounts(ref cart, user);

        Console.WriteLine($"Total price for invoice: {Math.Round(cart, 2)} zł.");
    }
}