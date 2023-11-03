using System.Xml.Linq;
using VendingMachine.Models;

namespace VendingMachine.Products
{
    public class Snacks : Product
    {
        public string Flavor { get; private set; }

        public Snacks(int id, string name, decimal cost, string description, string flavor)
            : base(id, name, cost, description)
        {
            Flavor = flavor;
        }

        public override string Examine()
        {
            return $"ID: {Id}, Name: {Name}, Cost: {Cost:C}, Description: {Description}, Flavor: {Flavor}";
        }

        public override string Use()
        {
            return $"Enjoy the {Name} snack!";
        }
    }
}
