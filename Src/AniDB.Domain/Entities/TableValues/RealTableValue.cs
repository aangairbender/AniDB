using System;

namespace AniDB.Domain.Entities.TableValues
{
    public class RealTableValue : TableValue<double>
    {
        public RealTableValue(double value) : base(value)
        {
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public override void FromString(string value)
        {
            bool result = double.TryParse(value, out var newValue);
            if (result)
                Value = newValue;
            else
                throw new Exception($"Can't cast \"{value}\" to real value");
        }
    }
}
