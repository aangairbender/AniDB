using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AniDB.Application.Infrastructure;
using AniDB.Domain.Entities;
using FluentValidation;
using MediatR;

namespace AniDB.Application.UseCases.Databases.Commands.CreateDatabase
{
    public class CreateDatabaseCommandHandler : IRequestHandler<CreateDatabaseCommand, Unit>
    {
        private readonly IDatabaseRepository _databaseRepository;

        public CreateDatabaseCommandHandler(IDatabaseRepository databaseRepository)
        {
            _databaseRepository = databaseRepository;
        }

        public async Task<Unit> Handle(CreateDatabaseCommand request, CancellationToken cancellationToken)
        {
            bool existsWithSameName = await _databaseRepository.ExistsWithName(request.Name);
            if (existsWithSameName)
                throw new DatabaseWithSameNameExistsException(request.Name);

            var entity = new Database
            {
                Name = request.Name
            };

            await _databaseRepository.Add(entity);

            return Unit.Value;
        }
    }
}
