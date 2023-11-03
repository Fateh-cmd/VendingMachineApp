using System;
using VendingMachine.Models;

namespace VendingMachine.Models
{
    public class Drink : Product
    {
        public string SpecificDrinkType { get; private set; }

        public Drink(int id, string name, decimal cost, string description, string specificDrinkType)
            : base(id, name, cost, description)
        {
            SpecificDrinkType = specificDrinkType;
        }

        public override string Examine()
        {
            return $"ID: {Id}, Name: {Name}, Cost: {Cost:C}, Description: {Description}, Drink Type: {SpecificDrinkType}";
        }

        public override string Use()
        {
            return $"Enjoy drinking the {Name}.";
        }
    }
}
