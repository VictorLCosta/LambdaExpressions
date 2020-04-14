using System.Globalization;

namespace LambdaExpressions.Entities
{
    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Category Category { get; set; }

        public Product()
        {
        }

        public Product(int id, string name, double price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public Product(int id, string name, double price, Category category)
        {
            Id = id;
            Name = name;
            Price = price;
            Category = category;
        }

        public override string ToString()
        {
            return $"{Id}: {Name.ToUpper()}, R${Price.ToString("F2", CultureInfo.InvariantCulture)}\n {Category}";
        }
    }
}
