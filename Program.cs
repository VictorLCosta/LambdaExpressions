using System;
using System.Collections.Generic;
using LambdaExpressions.Entities;
using System.Linq;
using System.Globalization;

namespace LambdaExpressions
{
    class Program
    {
        static void Print<T>(string message, IEnumerable<T> collection) 
        {
            Console.WriteLine(message);
            foreach (T obj in collection) 
            {
                Console.WriteLine(obj);
            }
        }


        
        static void Main(string[] args)
        {
            Category c1 = new Category() { Id = 1, Name = "Tools", Tier = 2 };
            Category c2 = new Category() { Id = 2, Name = "Computers", Tier = 1 };
            Category c3 = new Category() { Id = 3, Name = "Electronics", Tier = 1 };

            List<Product> products = new List<Product>();
            Console.WriteLine("Products list");

            products.Add(new Product() { Id = 1, Name = "Computer", Price = 1100.0, Category = c2 });
            products.Add(new Product() { Id = 2, Name = "Hammer", Price = 90.0, Category = c1 });
            products.Add(new Product() { Id = 3, Name = "TV", Price = 1700.0, Category = c3 });
            products.Add(new Product() { Id = 4, Name = "Notebook", Price = 1300.0, Category = c2 });
            products.Add(new Product() { Id = 5, Name = "Saw", Price = 80.0, Category = c1 });
            products.Add(new Product() { Id = 6, Name = "Tablet", Price = 700.0, Category = c2 });
            products.Add(new Product() { Id = 7, Name = "Camera", Price = 700.0, Category = c3 });
            products.Add(new Product() { Id = 8, Name = "Printer", Price = 350.0, Category = c3 });
            products.Add(new Product() { Id = 9, Name = "MacBook", Price = 1800.0, Category = c2 });
            products.Add(new Product() { Id = 10, Name = "Sound Bar", Price = 700.0, Category = c3 });
            products.Add(new Product() { Id = 11, Name = "Level", Price = 70.0, Category = c1 });

            var r1 = products.Where(p => p.Category.Tier == 1 && p.Price < 900.00);
            Print("TIER 1 AND PRICE < 900.00", r1);

            Console.WriteLine();
            var r2 = products.Where(p => p.Category.Tier == 1).OrderByDescending(p => p.Price);
            Print("TIER 1 ORDER BY PRICE", r2);

            Console.WriteLine();
            var r3 = products.Sum(p => p.Price);
            Console.WriteLine("PRICES SUM: " + r3.ToString("F2", CultureInfo.InvariantCulture));

            Console.WriteLine();
            var r4 = products.Where(p => p.Category.Name == "Tools");
            Print("PRODUCTS OF TOOL GATEGORY", r4);

            Console.WriteLine();
            var r5 = products.Where(p => p.Name[0] == 'C').Select(p => new { p.Name, CategoryName = p.Category.Name });
            Print("NAMES STARTED WITH 'C'", r5);

            Console.WriteLine();
            var r6 = products.Where(p => p.Category.Id == 5).Select(p => p .Price).DefaultIfEmpty(0.0).Average();
            Console.WriteLine(r6);

            Console.WriteLine();
            var r7 = products.GroupBy(p => p.Category);
            foreach (IGrouping<Category, Product> group in r7) 
            {
                Console.WriteLine();
                Console.WriteLine("CATEGORY " + group.Key.Name.ToUpper() + ':');
                foreach (Product prods in group) 
                {
                    Console.WriteLine(prods);
                }
            }
            
        }
    }
}
