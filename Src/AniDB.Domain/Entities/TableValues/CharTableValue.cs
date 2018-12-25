using System;

namespace AniDB.Domain.Entities.TableValues
{
    public class CharTableValue : TableValue<char>
    {
        public CharTableValue(char value) : base(value)
        {
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public override void FromString(string value)
        {
            bool result = char.TryParse(value, out var newValue);
            if (result)
                Value = newValue;
            else
                throw new Exception($"Can't cast \"{value}\" to char value");
        }
    }
}
