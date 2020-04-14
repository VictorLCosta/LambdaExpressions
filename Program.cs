using System;
using System.Collections.Generic;
using LambdaExpressions.Entities;
using System.Globalization;
using System.Linq;

namespace LambdaExpressions
{
    class Program
    {
        
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();
            Console.WriteLine("Products list");

            while (true) 
            {
                Console.Write("Product name: ");
                string name = Console.ReadLine();
                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                products.Add(new Product(name, price));

                Console.WriteLine();
                Console.Write("Insert other product[Y/N]: ");
                char op = char.Parse(Console.ReadLine());
                Console.WriteLine();

                if (op == 'N' || op == 'n') 
                {
                    break;
                }
            }

            products.ForEach(p => { p.Price += p.Price * 0.1; });
            products.Select(p => p in products); 

            foreach (Product prod in products) 
            {
                Console.WriteLine(prod);
            }
        }
    }
}
