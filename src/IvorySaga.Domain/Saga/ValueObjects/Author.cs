using System.Collections.Generic;
using IvorySaga.Domain.Common.Models;

namespace IvorySaga.Domain.Saga.ValueObjects;

public class Author : ValueObject
{
    public string Name { get; private set; }

    private Author(string name)
    {
        Name = name;
    }

    public static Author Create(string name)
    {
        return new Author(name);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
    }
}
