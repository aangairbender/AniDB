using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AniDB.Application.Infrastructure;
using MediatR;

namespace AniDB.Application.UseCases.Tables.Commands.DeleteTable
{
    public class DeleteTableCommandHandler : IRequestHandler<DeleteTableCommand, Unit>
    {
        private readonly IRepository _repository;

        public DeleteTableCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteTableCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteTable(request.TableId);
            return Unit.Value;
        }
    }
}
