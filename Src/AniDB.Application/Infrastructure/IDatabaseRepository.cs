using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AniDB.Domain.Entities;

namespace AniDB.Application.Infrastructure
{
    public interface IDatabaseRepository
    {
        Task<Database> Get(Guid id);
        Task<List<Database>> GetAll();
        Task Add(Database database);
        Task Update(Guid id, Database database);
        Task Delete(Guid id);
        Task<bool> ExistsWithName(string name);
    }
}
