using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AniDB.Application.Infrastructure;
using AniDB.Domain.Entities;
using MediatR;
using Newtonsoft.Json;

namespace AniDB.Application.UseCases.Databases.Commands.LoadSerializedDatabase
{
    public class LoadSerializedDatabaseCommandHandler : IRequestHandler<LoadSerializedDatabaseCommand, Unit>
    {
        private readonly IRepository _repository;

        public LoadSerializedDatabaseCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(LoadSerializedDatabaseCommand request, CancellationToken cancellationToken)
        {
            var jsonSerializerSettings = new JsonSerializerSettings {TypeNameHandling = TypeNameHandling.All};
            var database = JsonConvert.DeserializeObject<Database>(request.Content, jsonSerializerSettings);
            await _repository.AddDatabase(database);
            return Unit.Value;
        }
    }
}
