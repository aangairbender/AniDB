using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace AniDB.Application.UseCases.Tables.Queries.GetTableData
{
    public class GetTableDataQuery : IRequest<TableDataModel>
    {
        public Guid TableId { get; set; }
    }
}
