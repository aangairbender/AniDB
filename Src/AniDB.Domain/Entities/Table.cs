using System;
using System.Collections.Generic;
using AniDB.Domain.Infrastructure;

namespace AniDB.Domain.Entities
{
    public class Table : IEntity
    {
        public Guid Id { get; }

        public string Name { get; private set; }

        public TableSchema Schema { get; private set; }

        public IReadOnlyList<TableRow> Data { get; }

        public Table()
        {
            Id = Guid.NewGuid();
            Schema = new TableSchema();
            Data = new List<TableRow>();
        }

    }
}
