using System;
using System.Collections.Generic;
using System.Text;

namespace AniDB.Domain.ValueObjects.TableValues
{
    public class StringTableValue : TableValue<string>
    {
        public StringTableValue(string value) : base(value) { }

        public override string ToString()
        {
            return Value;
        }

        public override void FromString(string value)
        {
            Value = value;
        }
    }
}
