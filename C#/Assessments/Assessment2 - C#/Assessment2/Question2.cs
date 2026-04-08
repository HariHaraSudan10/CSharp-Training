using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Create a Class called Products with Productid, Product Name, Price. Accept 10 Products,
//sort them based on the price, and display the sorted Products

namespace Assessment2
{
    public class Products
    {
        public int Productid { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
    }
    internal class Question2
    {
        static void Main(string[] args)
        {
            List<Products> productList = new List<Products>();

            for (int i = 0; i < 10; i++)
            {
                Products product = new Products();
                Console.Write($"Enter ID of product {i+1}: ");
                product.Productid = int.Parse(Console.ReadLine());
                Console.Write($"Enter Name of product {i+1}: ");
                product.ProductName = Console.ReadLine();
                Console.Write($"Enter Price of product {i+1}: ");
                product.Price = int.Parse(Console.ReadLine());
                Console.WriteLine("-------------------------------------------------------------");
                productList.Add(product);
            }

            var sortedProducts = productList.OrderBy(product => product.Price).ToList();
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("\nSorted Products by Price:");
            Console.WriteLine("-------------------------------------------------------------");
            foreach (var product in sortedProducts)
            {
                Console.WriteLine($"ID: {product.Productid}, Name: {product.ProductName}, Price: {product.Price}");
            }
        }
    }
}