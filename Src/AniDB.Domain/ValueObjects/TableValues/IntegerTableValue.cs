using System.Collections.Generic;
using AniDB.Domain.Infrastructure;

namespace AniDB.Domain.ValueObjects.TableValues
{
    public class IntegerTableValue : TableValue<int>
    {
        public IntegerTableValue(int value) : base(value) { }
    }
}
