using System;
using System.Collections.Generic;
using AniDB.Domain.Infrastructure;
using AniDB.Domain.ValueObjects;

namespace AniDB.Domain.Entities
{
    public class TableRow : IEntity
    {
        public Guid Id { get; set; }

        public IReadOnlyList<TableValue> Values { get; set; }

        public TableRow() : this(new List<TableValue>())
        {
        }

        public TableRow(IReadOnlyList<TableValue> values)
        {
            Id = Guid.NewGuid();
            Values = values;
        }
    }
}
