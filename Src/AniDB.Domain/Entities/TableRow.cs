using System;
using System.Collections.Generic;
using AniDB.Domain.Infrastructure;

namespace AniDB.Domain.Entities
{
    public class TableRow : IEntity
    {
        public Guid Id { get; }

        public IReadOnlyList<TableValue> Values { get; }

        public TableRow()
        {
            Id = Guid.NewGuid();
            Values = new List<TableValue>();
        }
    }
}
