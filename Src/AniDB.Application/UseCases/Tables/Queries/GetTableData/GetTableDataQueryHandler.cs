using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AniDB.Application.Infrastructure;
using MediatR;

namespace AniDB.Application.UseCases.Tables.Queries.GetTableData
{
    public class GetTableDataQueryHandler : IRequestHandler<GetTableDataQuery, TableDataModel>
    {
        private readonly IRepository _repository;

        public GetTableDataQueryHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<TableDataModel> Handle(GetTableDataQuery request, CancellationToken cancellationToken)
        {
            var tableData = await _repository.GetTableData(request.TableId);
            return new TableDataModel {Data =  tableData};
        }
    }
}
