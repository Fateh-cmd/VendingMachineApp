using System;
using System.Collections.Generic;
using VendingMachine.Interfaces;
using VendingMachine.Models;

namespace VendingMachine.Services
{
    public class VendingMachineService : IVending
    {
        private List<Product> products;
        private decimal moneyPool;

        public VendingMachineService()
        {
            products = new List<Product>();
            moneyPool = 0;
        }

        public Product Purchase(int productId)
        {
            Product product = products.Find(p => p.Id == productId);

            if (product != null && product.Cost <= moneyPool)
            {
                moneyPool -= product.Cost;
                products.Remove(product);
                return product;
            }

            return null;
        }

        public List<string> ShowAll()
        {
            List<string> productInfo = new List<string>();
            foreach (Product product in products)
            {
                productInfo.Add($"ID: {product.Id}, Name: {product.Name}, Cost: {product.Cost:N2} kr");
            }


            return productInfo;
        }

        public string Details(int productId)
        {
            Product product = products.Find(p => p.Id == productId);

            if (product != null)
            {
                return product.Examine();
            }

            return "Product not found.";
        }

        public void InsertMoney(decimal amount)
        {
            if (IsValidDenomination(amount))
            {
                moneyPool += amount;
            }
            else
            {
                throw new InvalidOperationException("Invalid denomination. Please insert valid money.");
            }
        }

        public void InsertMoney(int amount)
        {
            // Convert the integer amount to a decimal before inserting it
            decimal decimalAmount = Convert.ToDecimal(amount);

            if (IsValidDenomination(decimalAmount))
            {
                moneyPool += decimalAmount;
            }
            else
            {
                throw new InvalidOperationException("Invalid denomination. Please insert valid money.");
            }
        }



        public Dictionary<int, int> EndTransaction()
        {
            Dictionary<int, int> change = CalculateChange(moneyPool);
            moneyPool = 0;
            return change;
        }

        private bool IsValidDenomination(decimal amount)
        {
            decimal[] validDenominations = { 1, 5, 10, 20, 50, 100, 500, 1000 };
            return Array.Exists(validDenominations, d => d == amount);
        }

        private Dictionary<int, int> CalculateChange(decimal amount)
        {
            Dictionary<int, int> change = new Dictionary<int, int>();

            int[] denominations = { 1000, 500, 100, 50, 20, 10, 5, 1 };

            foreach (int denomination in denominations)
            {
                int count = (int)(amount / denomination);
                if (count > 0)
                {
                    change[denomination] = count;
                    amount %= denomination;
                }
            }

            return change;
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public void AddProducts(List<Product> productList)
        {
            products.AddRange(productList);
        }

        Product IVending.Purchase(int productId)
        {
            throw new NotSupportedException("Products cannot be purchased directly.");
        }

        
    }
}
