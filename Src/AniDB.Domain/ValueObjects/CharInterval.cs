using System.Collections.Generic;
using AniDB.Domain.Infrastructure;

namespace AniDB.Domain.ValueObjects
{
    public class CharInterval : ValueObject
    {
        public char From { get; }
        public char To { get; }

        public CharInterval(char from, char to)
        {
            if (from > to)
            {
                var tmp = from;
                from = to;
                to = tmp;
            }

            From = from;
            To = to;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return From;
            yield return To;
        }
    }
}
