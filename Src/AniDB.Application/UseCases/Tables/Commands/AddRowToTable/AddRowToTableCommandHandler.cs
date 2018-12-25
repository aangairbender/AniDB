using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AniDB.Application.Infrastructure;
using AniDB.Domain.Entities;
using MediatR;

namespace AniDB.Application.UseCases.Tables.Commands.AddRowToTable
{
    public class AddRowToTableCommandHandler : IRequestHandler<AddRowToTableCommand, Unit>
    {
        private readonly IRepository _repository;

        public AddRowToTableCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(AddRowToTableCommand request, CancellationToken cancellationToken)
        {
            await _repository.AddRowToTable(request.TableId, new TableRow(request.Values));
            return Unit.Value;
        }
    }
}
