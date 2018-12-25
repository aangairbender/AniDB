using System;

namespace AniDB.Domain.Entities.TableValues
{
    public class IntegerTableValue : TableValue<int>
    {
        public IntegerTableValue(int value) : base(value) { }

        public override string ToString()
        {
            return Value.ToString();
        }

        public override void FromString(string value)
        {
            bool result = Int32.TryParse(value, out var newValue);
            if (result)
                Value = newValue;
            else
                throw new Exception($"Can't cast \"{value}\" to integer value");
        }
    }
}
