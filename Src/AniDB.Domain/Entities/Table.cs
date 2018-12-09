using System;
using System.Collections.Generic;
using System.Text;
using AniDB.Domain.Infrastructure;

namespace AniDB.Domain.Entities
{
    public class Table : IEntity
    {
        public Guid Id { get; }

        public string Name { get; set; }

        public IReadOnlyList<TableColumn> Columns { get; }

        public IReadOnlyList<TableRow> Rows { get; }

        public Table()
        {
            Id = Guid.NewGuid();
            Columns = new List<TableColumn>();
            Rows = new List<TableRow>();
        }

    }
}
