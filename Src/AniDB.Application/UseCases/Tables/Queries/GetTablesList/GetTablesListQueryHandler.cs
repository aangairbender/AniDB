using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AniDB.Application.Infrastructure;
using AniDB.Application.UseCases.Databases.Queries.GetDatabasesList;
using MediatR;

namespace AniDB.Application.UseCases.Tables.Queries.GetTablesList
{
    public class GetTablesListQueryHandler : IRequestHandler<GetTablesListQuery, TablesListModel>
    {
        private readonly IRepository _repository;

        public GetTablesListQueryHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<TablesListModel> Handle(GetTablesListQuery request, CancellationToken cancellationToken)
        {
            var vm = new TablesListModel
            {
                Tables = (await _repository.GetTables(request.DatabaseId)).Select(x =>
                    new TableLookupModel
                    {
                        Id = x.Id,
                        Name = x.Name
                    }).ToList()
            };

            return vm;
        }
    }
}
