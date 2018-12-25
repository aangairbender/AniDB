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

        public void SwapColumns(Guid columnAId, Guid columnBId)
        {
            int indexA = -1, indexB = -1;
            for (int i = 0; i < Schema.Columns.Count; ++i)
            {
                if (Schema.Columns[i].Id == columnAId)
                    indexA = i;
                if (Schema.Columns[i].Id == columnBId)
                    indexB = i;
            }

            var tmp = Schema.Columns[indexA];
            Schema.Columns[indexA] = Schema.Columns[indexB];
            Schema.Columns[indexB] = tmp;

            foreach (var tableRow in Data)
            {
                var tmp2 = tableRow.Values[indexA];
                tableRow.Values[indexA] = tableRow.Values[indexB];
                tableRow.Values[indexB] = tmp2;
            }
        }

    }
}
