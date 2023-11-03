using VendingMachine.Models;
using VendingMachine.Products;

namespace VendingMachine.Interfaces
{
    public interface IVending
    {
        Product Purchase(int productId);
        List<string> ShowAll();
        string Details(int productId);
        void InsertMoney(int amount);
        Dictionary<int, int> EndTransaction();
    }
}