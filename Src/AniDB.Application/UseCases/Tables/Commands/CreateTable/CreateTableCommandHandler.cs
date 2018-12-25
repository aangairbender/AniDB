using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AniDB.Application.Infrastructure;
using AniDB.Domain.Entities;
using MediatR;

namespace AniDB.Application.UseCases.Tables.Commands.CreateTable
{
    public class CreateTableCommandHandler : IRequestHandler<CreateTableCommand, Unit>
    {
        private readonly IRepository _repository;

        public CreateTableCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateTableCommand request, CancellationToken cancellationToken)
        {
            bool existsWithSameName = await _repository.TableExistsWithName(request.DatabaseId, request.Name);
            if (existsWithSameName)
                throw new TableWithSameNameExistsException(request.Name);

            var columns = new List<TableColumn>();
            foreach (var column in request.Columns)
            {
                Type columnType = typeof(TableColumn<>).MakeGenericType(column.Value);
                var entity = (TableColumn)Activator.CreateInstance(columnType);
                entity.Name = column.Key;
                columns.Add(entity);
            }

            var schema = new TableSchema(columns);

            var table = new Table
            {
                Name = request.Name,
                Schema = schema
            };

            await _repository.AddTable(request.DatabaseId, table);

            return Unit.Value;
        }
    }
}
