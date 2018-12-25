using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AniDB.Application.Infrastructure;
using MediatR;
using Newtonsoft.Json;

namespace AniDB.Application.UseCases.Databases.Queries.GetSerializedDatabase
{
    public class GetSerializedDatabaseQueryHandler : IRequestHandler<GetSerializedDatabaseQuery, string>
    {
        private readonly IRepository _repository;

        public GetSerializedDatabaseQueryHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(GetSerializedDatabaseQuery request, CancellationToken cancellationToken)
        {
            var database = await _repository.GetDatabase(request.DatabaseId);
            return JsonConvert.SerializeObject(database);
        }
    }
}
