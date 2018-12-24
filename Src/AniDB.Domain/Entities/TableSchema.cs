using System;
using System.Collections.Generic;
using System.Text;
using AniDB.Domain.Infrastructure;

namespace AniDB.Domain.Entities
{
    public class TableSchema : IEntity
    {
        public Guid Id { get; }

        public IReadOnlyList<TableColumn> Columns { get; }

        public TableSchema()
        {
            Id = Guid.NewGuid();
            Columns = new List<TableColumn>();
        }
    }
}
