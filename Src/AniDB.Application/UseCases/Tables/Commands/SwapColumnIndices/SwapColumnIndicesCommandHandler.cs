using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AniDB.Application.Infrastructure;
using MediatR;

namespace AniDB.Application.UseCases.Tables.Commands.SwapColumnIndices
{
    public class SwapColumnIndicesCommandHandler : IRequestHandler<SwapColumnIndicesCommand, Unit>
    {
        private readonly IRepository _repository;

        public SwapColumnIndicesCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(SwapColumnIndicesCommand request, CancellationToken cancellationToken)
        {
            await _repository.SwapColumnIndices(request.TableId, request.ColumnAId, request.ColumnBId);
            return Unit.Value;
        }
    }
}
