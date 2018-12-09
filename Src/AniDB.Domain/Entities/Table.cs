using System;
using System.Collections.Generic;
using System.Text;

namespace AniDB.Domain.Entities
{
    public class Table
    {
        public string Name { get; set; }

        public IReadOnlyList<TableColumn> Columns { get; }

        public IReadOnlyList<TableRow> Rows { get; }

        public Table()
        {
            Columns = new List<TableColumn>();
            Rows = new List<TableRow>();
        }

    }
}
