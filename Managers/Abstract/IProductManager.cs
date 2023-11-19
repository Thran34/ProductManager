using ProductManager.Models;

namespace ProductManager.Managers.Abstract
{
    internal interface IProductManager
    {
        IEnumerable<Product> CreateProducts();
        decimal CalculateCart(User user);
    }
}
