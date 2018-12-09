using System;

namespace AniDB.Application.UseCases.Databases.Queries.GetDatabasesList
{
    public class DatabaseLookupModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
