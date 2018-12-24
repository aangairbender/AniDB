using System;
using System.Collections.Generic;
using AniDB.Domain.Infrastructure;
using AniDB.Domain.ValueObjects.TableValues;

namespace AniDB.Domain.ValueObjects
{
    public abstract class TableValue<T> : TableValue
    {
        public T Value { get; set; }

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
        public new abstract string ToString();
        public abstract void FromString(string value);

        public static IDictionary<Type, string> SupportedTypes { get; } = new Dictionary<Type, string>
        {
            {typeof(IntegerTableValue), "Integer"},
            {typeof(StringTableValue), "String"},
        };
    }
}
