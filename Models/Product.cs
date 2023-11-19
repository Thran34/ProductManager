using ProductManager.Models.Helpers;

namespace ProductManager.Models
{
    public class Product : IEquatable<Product>
    {
        private decimal _weight;

        public Product(string name, Category category, decimal price, decimal weight, decimal margin)
        {
            Name = name;
            Category = category;
            Price = price;
            Weight = weight;
            Margin = margin;
        }

        public string Name { get; set; }
        public Category Category { get; set; }
        public decimal Price { get; set; }

        public decimal Weight
        {
            get => _weight;
            set
            {
                _weight = value;
                DoesWeightAffectPrice = _weight > 0;
            }
        }

        public decimal Margin { get; set; }
        public bool DoesWeightAffectPrice { get; set; }

        public bool Equals(Product? other)
        {
            if (other is null)
                return false;

            return Name == other.Name
                   && (int)Category == (int)other.Category
                   && Price == other.Price
                   && Weight == other.Weight
                   && Margin == other.Margin
                   && DoesWeightAffectPrice == other.DoesWeightAffectPrice;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, (int)Category, Price, Weight, Margin, DoesWeightAffectPrice);
        }
    }
}