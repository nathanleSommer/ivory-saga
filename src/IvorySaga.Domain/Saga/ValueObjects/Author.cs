using System.Collections.Generic;
using IvorySaga.Domain.Common.Models;

namespace IvorySaga.Domain.Saga.ValueObjects;

public class Author : ValueObject
{
    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    private Author(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public static Author Create(string firstName, string lastName)
    {
        return new Author(firstName, lastName);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return FirstName;
        yield return LastName;
    }
}
