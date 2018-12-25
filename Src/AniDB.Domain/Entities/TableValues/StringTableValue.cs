namespace AniDB.Domain.Entities.TableValues
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
