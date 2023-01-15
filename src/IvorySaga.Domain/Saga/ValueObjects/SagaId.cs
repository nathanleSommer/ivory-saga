using System;
using System.Collections.Generic;
using IvorySaga.Domain.Common.Models;

namespace IvorySaga.Domain.Saga.ValueObjects
{
    public sealed class SagaId : ValueObject
    {
        public Guid Value { get; private set; }

        private SagaId(Guid value)
        {
            Value = value;
        }

        public static SagaId CreateUnique()
        {
            return new SagaId(Guid.NewGuid());
        }

        public static SagaId Create(Guid value)
        {
            return new SagaId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
