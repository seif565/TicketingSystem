using TicketingSystem.Domain.Primitives;

namespace TicketingSystem.Domain.ValueObjects;

public sealed class City : ValueObject
{
    private City(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Name;
    }

    public static City Create(string name)
    {
        return new City(name);
    }
}
