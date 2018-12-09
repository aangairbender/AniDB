using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AniDB.Application.Infrastructure;
using AniDB.Domain.Entities;
using MediatR;

namespace AniDB.Application.UseCases.Databases.Queries.GetDatabasesList
{
    public class GetDatabasesListQueryHandler : IRequestHandler<GetDatabasesListQuery, DatabasesListModel>
    {
        private readonly IDatabaseRepository _databaseRepository;

        public GetDatabasesListQueryHandler(IDatabaseRepository databaseRepository)
        {
            _databaseRepository = databaseRepository;
        }

        public async Task<DatabasesListModel> Handle(GetDatabasesListQuery request, CancellationToken cancellationToken)
        {
            var vm = new DatabasesListModel
            {
                Databases = (await _databaseRepository.GetAll()).Select(x =>
                    new DatabaseLookupModel
                    {
                        Id = x.Id,
                        Name = x.Name
                    }).ToList()
            };

            return vm;
        }
    }
}
