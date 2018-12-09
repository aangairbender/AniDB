using MediatR;

namespace AniDB.Application.UseCases.Databases.Queries.GetDatabasesList
{
    public class GetDatabasesListQuery : IRequest<DatabasesListModel>
    {
    }
}
