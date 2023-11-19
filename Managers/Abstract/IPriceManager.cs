using ProductManager.Models;

namespace ProductManager.Managers.Abstract
{
    internal interface IPriceManager
    {
        decimal SumPricesOfProducts(Product product1, Product product2);
        void CalculateDiscounts(ref decimal cart, User user);
        void CalculateProductWeightPrice(ref decimal cart, User user);
    }
}
