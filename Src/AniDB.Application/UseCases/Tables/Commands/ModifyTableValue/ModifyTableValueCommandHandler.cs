using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AniDB.Application.Infrastructure;
using MediatR;

namespace AniDB.Application.UseCases.Tables.Commands.ModifyTableValue
{
    public class ModifyTableValueCommandHandler : IRequestHandler<ModifyTableValueCommand, Unit>
    {
        private readonly IRepository _repository;

        public ModifyTableValueCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(ModifyTableValueCommand request, CancellationToken cancellationToken)
        {
            await _repository.ModifyTableValue(request.TableId, request.TableRowId, request.TableValueId,
                request.NewValue);
            return Unit.Value;
        }
    }
}
