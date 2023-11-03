using System;

namespace VendingMachine.Models
{
    public class Product
    {
        public int Id { get; }
        public string Name { get; }
        public decimal Cost { get; }
        public string Description { get; }

        public Product(int id, string name, decimal cost, string description)
        {
            Id = id;
            Name = name;
            Cost = cost;
            Description = description;
        }

        public virtual string Examine()
        {
            return $"ID: {Id}, Name: {Name}, Cost: {Cost:C}, Description: {Description}";
        }

        public virtual string Use()
        {
            return $"Use the {Name}.";
        }
    }

    public class Snack : Product
    {
        public string Flavor { get; set; }

        public Snack(int id, string name, decimal cost, string description, string flavor)
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
            return $"Enjoy the {Flavor} {Name} snack.";
        }
    }
}
