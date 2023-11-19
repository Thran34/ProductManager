using ProductManager.Models.Helpers;

namespace ProductManager.Models;

public class Product : IEquatable<Product>
{
    public Product(string name, Category category, decimal price, decimal weight)
    {
        Name = name;
        Category = category;
        Price = price;
        Weight = weight;
    }

    public string Name { get; set; }
    public Category Category { get; set; }
    public decimal Price { get; set; }
    public decimal Weight { get; set; }

    public bool Equals(Product? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Category == other.Category && Price == other.Price && Weight == other.Weight;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Product)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine((int)Category, Price, Weight);
    }
}