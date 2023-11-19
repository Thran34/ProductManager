using ProductManager.Managers.Abstract;
using ProductManager.Models;
using ProductManager.Models.Helpers;

namespace ProductManager.Managers.Concrete;

internal class PriceManager : IPriceManager
{
    public decimal SumPricesOfProducts(Product product1, Product product2)
    {
        return product1.Price + product2.Price;
    }

    public void CalculateDiscounts(ref decimal cart, User user)
    {
        CalculateBasicDiscount(ref cart);
        CalculateUserRoleDiscount(ref cart, user);
        CalculateMarginAndAdditionalCosts(ref cart, user, 0);
    }

    private static void CalculateBasicDiscount(ref decimal cart)
    {
        cart = cart switch
        {
            > 5000 => (0.7m * cart),
            > 1000 => (0.8m * cart),
            > 500 => (0.85m * cart),
            > 100 => (0.9m * cart),
            _ => cart
        };

        Console.WriteLine($"Product's price with basic discount: {Math.Round(cart, 2)} zł.");
    }

    private static void CalculateUserRoleDiscount(ref decimal cart, User user)
    {
        if (user.Role != Role.User)
        {
            cart = (int)(0.9m * cart);
        }

        Console.WriteLine($"Product's price with user's role discount: {Math.Round(cart, 2)} zł.");
    }

    private static void CalculateMarginAndAdditionalCosts(ref decimal cart, User user, decimal additionalCosts)
    {
        if (user.IsApplicableForAdditionalCosts)
        {
            cart += additionalCosts;
        }

        Console.WriteLine($"Product's price with additional costs: {Math.Round(cart, 2)} zł.");

        if (user.ShouldAddMargin)
        {
            var margin = user.Products.Select(x => x.Margin).Sum();
            cart += margin;

            if (margin > 100)
                Console.WriteLine("Applying margin. Well done, you deserve a raise!");
        }
        Console.WriteLine($"Product's price with margin: {Math.Round(cart, 2)} zł.");
    }

    public void CalculateProductWeightPrice(ref decimal cart, User user)
    {
        if (user.Products.Any(x => x.DoesWeightAffectPrice))
        {
            Console.WriteLine("Products have to be weighted! Calculating weight...");

            foreach (var product in user.Products.Where(x => x.DoesWeightAffectPrice))
            {
                cart += product.Weight switch
                {
                    > 1000 when product.Category == Category.Fruit => 45,
                    > 1000 when product.Category == Category.Vegetable => 35,
                    > 500 => 15,
                    > 100 => 10,
                    > 50 => 5,
                    > 15 => 2,
                    _ => 0
                };
            }

            Console.WriteLine($"Product's price after calculating weight: {Math.Round(cart, 2)} zł.");
        }
    }
}