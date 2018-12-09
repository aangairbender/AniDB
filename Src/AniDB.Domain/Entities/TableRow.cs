using System.Collections.Generic;
using AniDB.Domain.Infrastructure;

namespace AniDB.Domain.Entities
{
    public class TableRow
    {
        public IReadOnlyList<TableValue> Values { get; }

        public TableRow()
        {
            Values = new List<TableValue>();
        }
    }
}
