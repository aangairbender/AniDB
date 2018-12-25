using System;
using System.Collections.Generic;
using System.Text;
using AniDB.Domain.Infrastructure;

namespace AniDB.Domain.Entities
{
    public class TableSchema : IEntity
    {
        public Guid Id { get; set; }

        public IList<TableColumn> Columns { get; }

        public TableSchema() : this(new List<TableColumn>())
        {
        }

        public TableSchema(IList<TableColumn> columns)
        {
            Id = Guid.NewGuid();
            Columns = columns;
        }
    }
}
