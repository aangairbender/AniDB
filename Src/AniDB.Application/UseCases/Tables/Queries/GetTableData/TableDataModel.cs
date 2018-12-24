using System;
using System.Collections.Generic;
using System.Text;
using AniDB.Domain.Entities;

namespace AniDB.Application.UseCases.Tables.Queries.GetTableData
{
    public class TableDataModel
    {
        public ICollection<TableRow> Data { get; set; }
    }
}
