using System.Xml.Linq;
using VendingMachine.Models;

public class Fruit : Product
{
    public string SpecificFruitType { get; private set; }

    public Fruit(int id, string name, decimal cost, string description, string specificFruitType)
        : base(id, name, cost, description)
    {
        SpecificFruitType = specificFruitType;
    }

    public override string Examine()
    {
        return $"ID: {Id}, Name: {Name}, Cost: {Cost:C}, Description: {Description}, Fruit Type: {SpecificFruitType}";
    }

    public override string Use()
    {
        return $"Enjoy eating the {Name} fruit.";
    }
}
