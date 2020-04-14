using System.Globalization;

namespace LambdaExpressions.Entities
{
    class Product
    {
        public string Name { get; private set; }
        public double Price { get; set; }

        public Product()
        {
        }

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return $"{Name.ToUpper()}, R${Price.ToString("F2", CultureInfo.InvariantCulture)}";
        }
    }
}
