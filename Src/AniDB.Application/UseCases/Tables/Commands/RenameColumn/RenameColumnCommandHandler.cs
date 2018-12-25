using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AniDB.Application.Infrastructure;
using MediatR;

namespace AniDB.Application.UseCases.Tables.Commands.RenameColumn
{
    public class RenameColumnCommandHandler : IRequestHandler<RenameColumnCommand, Unit>
    {
        private readonly IRepository _repository;

        public RenameColumnCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(RenameColumnCommand request, CancellationToken cancellationToken)
        {
            await _repository.RenameColumn(request.TableId, request.ColumnId, request.NewName);
            return Unit.Value;
        }
    }
}
