using System;
using AniDB.Domain.ValueObjects;

namespace AniDB.Domain.Entities.TableValues
{
    public class CharIntervalTableValue : TableValue<CharInterval>
    {
        public CharIntervalTableValue(CharInterval value) : base(value)
        {
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public override void FromString(string value)
        {
            bool result = CharInterval.TryParse(value, out var newValue);
            if (result)
                Value = newValue;
            else
                throw new Exception($"Can't cast \"{value}\" to char value");
        }
    }
}
