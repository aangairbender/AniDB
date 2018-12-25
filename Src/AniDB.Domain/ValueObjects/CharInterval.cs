using System;
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

        public bool Contains(char c)
        {
            return c >= From && c <= To;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return From;
            yield return To;
        }

        public override string ToString()
        {
            return $"{From}-{To}";
        }

        public static bool TryParse(string s, out CharInterval result)
        {
            result = null;
            string[] parts = s.Split(new[] {'-'}, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2)
                return false;
            string from = parts[0].Trim();
            string to = parts[1].Trim();
            if (from.Length != 1 || to.Length != 1)
                return false;
            
            result = new CharInterval(from[0], to[0]);
            return true;
        }
    }
}
