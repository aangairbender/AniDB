using System;
using System.Linq;
using AniDB.Domain.ValueObjects;

namespace AniDB.Domain.Entities.TableValues
{
    public class BoundedStringTableValue : TableValue<string>
    {
        public CharInterval Bounds { get; }

        public BoundedStringTableValue(string value, CharInterval bounds) : base(value)
        {
            Bounds = bounds;
        }

        public override string ToString()
        {
            return Value;
        }

        public override void FromString(string value)
        {
            if (value.All(Bounds.Contains))
                Value = value;
            else
                throw new Exception($"String contains chars out of bounds {Bounds}");
        }
    }
}
