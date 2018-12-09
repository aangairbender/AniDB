using System;
using System.Collections.Generic;
using System.Text;

namespace AniDB.Domain.Infrastructure
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
