using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachine.Services;
using VendingMachine.Products;

namespace VendingMachine.Tests
{
    [TestClass]
    public class VendingMachineServiceTests
    {
        private VendingMachineService vendingMachine;

        [TestInitialize]
        public void Initialize()
        {
            // Initialize a new vending machine for each test
            vendingMachine = new VendingMachineService();
        }

        [TestMethod]
        public void Purchase_ProductAvailableAndEnoughFunds_ReturnsProduct()
        {
            // Arrange
            var product = new Snacks(1, "Chips", 2.50m, "Tasty chips", "Salty");
            vendingMachine.AddProduct(product);
            vendingMachine.InsertMoney(3.0m);

            // Act
            var purchasedProduct = vendingMachine.Purchase(1);

            // Assert
            Assert.IsNotNull(purchasedProduct);
            Assert.AreEqual(1, purchasedProduct.Id);
        }

        [TestMethod]
        public void Purchase_ProductUnavailable_ReturnsNull()
        {
            // Arrange
            vendingMachine.InsertMoney(2.0m);

            // Act
            var purchasedProduct = vendingMachine.Purchase(1);

            // Assert
            Assert.IsNull(purchasedProduct);
        }

        [TestMethod]
        public void Purchase_NotEnoughFunds_ReturnsNull()
        {
            // Arrange
            var product = new Snacks(1, "Chips", 2.50m, "Tasty chips", "Salty");
            vendingMachine.AddProduct(product);
            vendingMachine.InsertMoney(1.0m);

            // Act
            var purchasedProduct = vendingMachine.Purchase(1);

            // Assert
            Assert.IsNull(purchasedProduct);
        }

        [TestMethod]
        public void ShowAll_ProductsAvailable_ReturnsProductList()
        {
            // Arrange
            var product1 = new Snacks(1, "Chips", 2.50m, "Tasty chips", "Salty");
            var product2 = new Snacks(2, "Candy", 1.00m, "Sweet candy", "Chocolaty");
            vendingMachine.AddProduct(product1);
            vendingMachine.AddProduct(product2);

            // Act
            var productInfo = vendingMachine.ShowAll();

            // Assert
            Assert.IsNotNull(productInfo);
            Assert.AreEqual(2, productInfo.Count);
        }

        // Add more test methods as needed for other scenarios

        [TestCleanup]
        public void Cleanup()
        {
            // Clean up resources if needed
        }
    }
}
