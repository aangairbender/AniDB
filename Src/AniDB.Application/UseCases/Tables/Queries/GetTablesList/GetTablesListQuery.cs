using System;
using MediatR;

namespace AniDB.Application.UseCases.Tables.Queries.GetTablesList
{
    public class GetTablesListQuery : IRequest<TablesListModel>
    {
        public Guid DatabaseId { get; set; }
    }
}
