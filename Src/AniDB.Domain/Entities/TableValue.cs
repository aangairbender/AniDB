using System;
using System.Collections.Generic;
using System.IO;
using AniDB.Domain.Entities.TableValues;
using AniDB.Domain.Infrastructure;

namespace AniDB.Domain.Entities
{
    public abstract class TableValue<T> : TableValue
    {
        public T Value { get; set; }

        protected TableValue(T value)
        {
            Value = value;
        }
    }

    public abstract class TableValue : IEntity
    {
        public new abstract string ToString();
        public abstract void FromString(string value);

        public static IDictionary<Type, string> SupportedTypes { get; } = new Dictionary<Type, string>
        {
            {typeof(IntegerTableValue), "Integer"},
            {typeof(StringTableValue), "String"},
            {typeof(CharTableValue), "Char"},
            {typeof(RealTableValue), "Real"},
            {typeof(CharIntervalTableValue), "CharInterval"},
            {typeof(BoundedStringTableValue), "BoundedString"},
        };

        public Guid Id { get; }

        protected TableValue()
        {
            Id = Guid.NewGuid();
        }
    }
}
