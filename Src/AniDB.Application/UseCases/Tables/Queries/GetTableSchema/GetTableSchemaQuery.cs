using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace AniDB.Application.UseCases.Tables.Queries.GetTableSchema
{
    public class GetTableSchemaQuery : IRequest<TableSchemaModel>
    {
        public Guid TableId { get; set; }
    }
}
