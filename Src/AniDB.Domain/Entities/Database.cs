using System;
using System.Collections.Generic;
using AniDB.Domain.Infrastructure;

namespace AniDB.Domain.Entities
{
    public class Database : IEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<Table> Tables { get; }

        public Database()
        {
            Id = Guid.NewGuid();
            Tables = new List<Table>();
        }

        public void AddTable(Table table)
        {
            Tables.Add(table);
        }

    }
}
