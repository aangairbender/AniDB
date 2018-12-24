using System.Collections.Generic;
using AniDB.Domain.Infrastructure;

namespace AniDB.Domain.ValueObjects
{
    public abstract class TableValue<T> : TableValue
    {
        public T Value { get; }

        public TableValue(T value)
        {
            Value = value;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }

    public abstract class TableValue : ValueObject
    {

    }
}
