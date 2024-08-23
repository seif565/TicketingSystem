using TicketingSystem.Domain.Primitives;

namespace TicketingSystem.Domain.ValueObjects
{
    public sealed class Governorate : ValueObject
    {
        private Governorate() { }
        private Governorate(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Name;
        }

        public static Governorate Create(string name)
        {
             return new Governorate(name);
        }
    }
}
