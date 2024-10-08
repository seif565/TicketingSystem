﻿using TicketingSystem.Domain.Primitives;

namespace TicketingSystem.Domain.ValueObjects;

public sealed class District : ValueObject
{
    private District()
    {
        
    }
    private District(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Name;
    }

    public static District Create(string name)
    {
        return new District(name);
    }
}
