using System;
using System.Collections.Generic;
using AniDB.Domain.Infrastructure;

namespace AniDB.Domain.Entities
{
    public class Table : IEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public TableSchema Schema { get; set; }

        public ICollection<TableRow> Data { get; }

        public Table()
        {
            Id = Guid.NewGuid();
            Schema = new TableSchema();
            Data = new List<TableRow>();
        }

        public void AddRow(TableRow row)
        {
            Data.Add(row);
        }

    }
}
