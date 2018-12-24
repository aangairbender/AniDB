using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AniDB.Application.Infrastructure;
using AniDB.Domain.Entities;

namespace AniDB.Persistence.Repositories.InMemory
{
    public class InMemoryRepository : IRepository
    {
        private readonly IDictionary<Guid, Database> _databases;

        public InMemoryRepository()
        {
            _databases = new Dictionary<Guid, Database>();
        }

        public Task<List<Database>> GetDatabases()
        {
            return Task.Run(() => _databases.Values.ToList());
        }


        public Task<List<Table>> GetTables(Guid databaseId)
        {
            return Task.Run(() => _databases.Values.First(x => x.Id == databaseId).Tables.ToList());
        }

        public Task AddDatabase(Database database)
        {
            return Task.Run(() =>
            {
                _databases.Add(database.Id, database);
            });
        }


        public Task<bool> DatabaseExistsWithName(string name)
        {
            return Task.Run(() => _databases.Values.Any(x => x.Name == name));
        }
    }
}
