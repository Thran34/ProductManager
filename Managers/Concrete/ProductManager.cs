using ProductManager.Managers.Abstract;
using ProductManager.Models;
using ProductManager.Models.Helpers;

namespace ProductManager.Managers.Concrete;

internal class ProductManager : IProductManager
{
    public IEnumerable<Product> CreateProducts()
    {
        return new List<Product>
        {
            new Product("Fasola", Category.Vegetable, 20.12m, 10m, 50),
            new Product("Banan", Category.Vegetable, 20.99m, 20m, 40),
            new Product("Kiwi", Category.Fruit, 123, 10, 30)
        };
    }
    public decimal CalculateCart(User user)
    {
        var sumOfUserProductsPrices = Math.Round(user.Products.Select(x => x.Price).Sum(), 2);

        Console.WriteLine($"Product's base price: {sumOfUserProductsPrices} zł.");

        return sumOfUserProductsPrices;
    }
}


