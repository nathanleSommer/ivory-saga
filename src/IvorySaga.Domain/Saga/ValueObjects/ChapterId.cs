using System;
using System.Collections.Generic;
using IvorySaga.Domain.Common.Models;

namespace IvorySaga.Domain.Saga.ValueObjects;

public sealed class ChapterId : ValueObject
{
    public Guid Value { get; private set; }

    private ChapterId(Guid value)
    {
        Value = value;
    }

    public static ChapterId CreateUnique()
    {
        return new ChapterId(Guid.NewGuid());
    }

    public static ChapterId Create(Guid value)
    {
        return new ChapterId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
