using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AniDB.Application.Infrastructure;
using MediatR;

namespace AniDB.Application.UseCases.Tables.Queries.GetTableSchema
{
    public class GetTableSchemaQueryHandler : IRequestHandler<GetTableSchemaQuery, TableSchemaModel>
    {
        private readonly IRepository _repository;

        public GetTableSchemaQueryHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<TableSchemaModel> Handle(GetTableSchemaQuery request, CancellationToken cancellationToken)
        {
            var tableSchema = await _repository.GetTableSchema(request.TableId);
            return new TableSchemaModel {Schema = tableSchema};
        }
    }
}
