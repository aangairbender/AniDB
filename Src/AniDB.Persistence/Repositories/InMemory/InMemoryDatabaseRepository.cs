using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AniDB.Application.Infrastructure;
using AniDB.Domain.Entities;

namespace AniDB.Persistence.Repositories.InMemory
{
    public class InMemoryDatabaseRepository : IDatabaseRepository
    {
        private readonly IDictionary<Guid, Database> _databases;

        public InMemoryDatabaseRepository()
        {
            _databases = new Dictionary<Guid, Database>();
        }

        public Task<Database> Get(Guid id)
        {
            return Task.Run(() => _databases[id]);
        }

        public Task<List<Database>> GetAll()
        {
            return Task.Run(() => _databases.Values.ToList());
        }

        public Task Add(Database database)
        {
            return Task.Run(() =>
            {
                _databases.Add(database.Id, database);
            });
        }

        public Task Update(Guid id, Database database)
        {
            return Task.Run(() =>
            {
                _databases[id] = database;
            });
        }

        public Task Delete(Guid id)
        {
            return Task.Run(() => { _databases.Remove(id); });
        }

        public Task<bool> ExistsWithName(string name)
        {
            return Task.Run(() => _databases.Values.Any(x => x.Name == name));
        }
    }
}
