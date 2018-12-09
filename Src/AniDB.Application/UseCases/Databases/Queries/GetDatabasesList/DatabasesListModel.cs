using System.Collections.Generic;

namespace AniDB.Application.UseCases.Databases.Queries.GetDatabasesList
{
    public class DatabasesListModel
    {
        public IList<DatabaseLookupModel> Databases { get; set; }
    }
}
