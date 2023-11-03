using System;
using VendingMachine.Models;
using VendingMachine.Services;

namespace VendingMachine.Services
{
    class Program
    {
        static void Main(string[] args)
        {
            var vendingMachine = new VendingMachineService();

            var product1 = new Snack(1, "Chips", 20m, "Tasty chips", "Salty");
            var product2 = new Fruit(2, "Apple", 10m, "Fresh apple", "Sweet");
            var product3 = new Drink(3, "Soda", 15m, "Refreshing soda", "Cola");

            vendingMachine.AddProduct(product1);
            vendingMachine.AddProduct(product2);
            vendingMachine.AddProduct(product3);

            Console.WriteLine("Welcome to the Vending Machine!");

            while (true)
            {
                Console.WriteLine("Available Products:");
                var productInfo = vendingMachine.ShowAll();
                foreach (var info in productInfo)
                {
                    Console.WriteLine(info);
                }

                Console.Write("Enter the ID of the product you want to buy (or 'q' to quit): ");
                string input = Console.ReadLine();

                if (input.ToLower() == "q")
                {
                    // Quit the program
                    break;
                }

                if (int.TryParse(input, out int productId))
                {
                    var purchasedProduct = vendingMachine.Purchase(productId);

                    if (purchasedProduct != null)
                    {
                        Console.WriteLine($"You purchased: {purchasedProduct.Name}");
                        Console.WriteLine($"Instructions: {purchasedProduct.Use()}");
                    }
                    else
                    {
                        Console.WriteLine("Product not found or not enough money.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a product ID or 'q' to quit.");
                }
            }

            var change = vendingMachine.EndTransaction();

            Console.WriteLine("Transaction ended. Change provided:");
            foreach (var denomination in change)
            {
                Console.WriteLine($"{denomination.Value} x {denomination.Key}kr");
            }
        }
    }
}
